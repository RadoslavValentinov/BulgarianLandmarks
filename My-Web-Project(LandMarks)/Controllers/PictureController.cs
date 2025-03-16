using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebProject.Core.Models.PictureModel;
using MyWebProject.Core.Services.IServices;


namespace My_Web_Project_LandMarks_.Controllers
{
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class PictureController : Controller
    {

        private readonly IPictureService service;



        public PictureController(IPictureService _service)
        {
            service = _service;
        }




        /// <summary>
        /// The method aims to increase the likeCount property of a picture 
        /// selected by a user. (Only for registered users). 
        /// The method receives the ID of a picture.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Increase picture likeCount</returns>
        [Authorize]
        public  async Task<IActionResult> UpLikeCount(int id)
        {
            var upCount = await service.UpLikeCount(id);

            return RedirectToActionPreserveMethod("Index","Home");
        }



        /// <summary>
        ///  Method get all picture upload by users from database and send to view
        /// </summary>
        /// <returns>View index </returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllPictureByUsers()
        {
            var model = await service.AllPictureUploadByUsers();
            return View(model);
        }


        /// <summary>
        /// Add picture by user Only URL address
        /// </summary>
        /// <returns>create page model</returns>
        /// 
        [HttpGet]
        [Authorize]
        public IActionResult AddPicture()
        {
            var model = new AddPictureByUser();

            return View(model);
        }


        /// <summary>
        ///   Send to service method  model and add picture by pictureUser scheme in database 
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Redirect to index page</returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPicture(AddPictureByUser model)
        {
            if (ModelState.IsValid)
            {
                await service.AddPictureByUser(model);

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }



        /// <summary>
        /// Get picture upload by user and create byte array and send to service method.
        /// Added byte array picture in database(UserPicture scheme)
        /// </summary>
        /// <param name="model"></param>
        /// <param name="pictureFile"></param>
        /// <returns>message to succssessfuly upload picture</returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPictureByArray(AddPictureByUser model, IFormFile pictureFile)
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

                await service.PictureByByteArray(model);

                return RedirectToAction("Index", "Home");
            }

            return View("AddPicture");
        }
    }
}
