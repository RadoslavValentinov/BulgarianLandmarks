using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebProject.Core.Models.PictureModel;
using MyWebProject.Core.Services.IServices;

namespace My_Web_Project_LandMarks_.Areas.Administrator.Controllers
{
    [Authorize]
    [Area("Administrator")]
    [AutoValidateAntiforgeryToken]
    public class OptionPictures : Controller
    {
        private readonly IPictureService service;

        public OptionPictures(IPictureService _service)
        {
            service = _service;
        }


        /// <summary>
        /// Retrieves all pictures.
        /// </summary>
        /// <returns>View with a collection of all pictures.</returns>
        public async Task<IActionResult> Index()
        {
            var model = await service.AllPicture();
            return View(model);
        }


        /// <summary>
        /// Retrieves all pictures uploaded by users.
        /// </summary>
        /// <returns>View with a collection of pictures uploaded by users.</returns>
        [HttpGet]
        public async Task<IActionResult> ByUserPicture()
        {
            var model = await service.AllPictureByUser();
            return View(model);
        }


        /// <summary>
        /// Loads the view to add a new picture.
        /// </summary>
        /// <returns>View with a form to add a new picture.</returns>
        [HttpGet]
        public IActionResult AddPicture()
        {
            var model = new AddPictureViewModel();
            return View(model);
        }


        /// <summary>
        /// Adds a new picture uploaded by a user.
        /// </summary>
        /// <param name="id">The id of the picture uploaded by the user.</param>
        /// <returns>Redirects to the Index action if successful.</returns>
        [Authorize]
        public async Task<IActionResult> AddPictureByUser(int id)
        {
            var pictureFile = await service.GetByUserId(id);
            var model = new AddPictureViewModel()
            {
                Id = pictureFile.Id,
                UrlImgAddres = pictureFile.UrlImgAddres!,
                PictureData = pictureFile.PictureData,
                UserName = pictureFile.UserName,
            };

            if (pictureFile.PictureData != null && pictureFile.PictureData.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    memoryStream.Write(model.PictureData!, 0, model.PictureData!.Length);
                    model.PictureData = memoryStream.ToArray();
                }
            }

            await service.AddPicture(model);
            return RedirectToAction("Index");
        }
        

        /// <summary>
        /// Adds a new picture.
        /// </summary>
        /// <param name="model">The model containing the picture data.</param>
        /// <param name="pictureFile">The picture file to upload.</param>
        /// <returns>Redirects to the Index action if successful, otherwise reloads the add picture view.</returns>
        [HttpPost]
        public async Task<IActionResult> AddPicture(AddPictureViewModel model, IFormFile pictureFile)
        {
            if (ModelState.IsValid)
            {
                if (pictureFile != null && pictureFile.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await pictureFile.CopyToAsync(memoryStream);
                        model.PictureData = memoryStream.ToArray();
                    }
                }

                await service.AddPicture(model);

                var all = service.AllPictureByUser();
                var findUser = all.Result.Where(x => x.UserName == model.UserName).ToList();
                if (findUser.Count > 0)
                {
                    await service.DeleteByUser(findUser[0].Id);
                }

                return RedirectToAction("Index");
            }
            return View(model);
        }


        /// <summary>
        /// Loads the view to edit an existing picture.
        /// </summary>
        /// <param name="Id">The id of the picture to edit.</param>
        /// <returns>View with a form to edit the picture.</returns>
        [HttpGet]
        public IActionResult EditPicture(int Id)
        {
            var getPicture = service.GetById(Id).Result;
            var model = new AddPictureViewModel()
            {
                Id = getPicture.Id,
                UrlImgAddres = getPicture.UrlImgAddres,
                LandMark = getPicture.LandMark,
                Town = getPicture.Town,
                Journey = getPicture.Journey,
            };
            return View(model);
        }


        /// <summary>
        /// Edits an existing picture.
        /// </summary>
        /// <param name="model">The model containing the updated picture data.</param>
        /// <returns>Redirects to the Index action if successful, otherwise reloads the edit picture view.</returns>
        [HttpPost]
        public async Task<IActionResult> EditPicture(AddPictureViewModel model)
        {
            if (ModelState.IsValid)
            {
                await service.EditPicture(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        /// <summary>
        /// Deletes a picture by its id.
        /// </summary>
        /// <param name="Id">The id of the picture to delete.</param>
        /// <returns>Redirects to the Index action.</returns>
        public async Task<IActionResult> Delete(int Id)
        {
            await service.Delete(Id);
            return RedirectToAction("Index");
        }


        /// <summary>
        /// Deletes a picture uploaded by a user by its id.
        /// </summary>
        /// <param name="Id">The id of the picture to delete.</param>
        /// <returns>Redirects to the Index action.</returns>
        public async Task<IActionResult> DeleteByUser(int Id)
        {
            await service.DeleteByUser(Id);
            return RedirectToAction("Index");
        }
    }
}