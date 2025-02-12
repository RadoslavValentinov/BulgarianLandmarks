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

        public async Task<IActionResult> Index()
        {
            var model = await service.AllPicture();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ByUserPicture()
        {
            var model = await service.AllPictureByUser();

            return View(model);
        }


        [HttpGet]
        public IActionResult AddPicture()
        {
            var model = new AddPictureViewModel();

            return View(model);
        }


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


        public async Task<IActionResult> Delete(int Id)
        {
            await service.Delete(Id);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteByUser(int Id)
        {
            await service.DeleteByUser(Id);

            return RedirectToAction("Index");
        }
    }
}
