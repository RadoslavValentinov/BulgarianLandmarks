﻿using Microsoft.AspNetCore.Authorization;
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



        public  async Task<IActionResult> UpLikeCount(int id)
        {
            var upCount = await service.UpLikeCount(id);

            return RedirectToActionPreserveMethod("Index","Home");
        }

        [AllowAnonymous]
        public async Task<IActionResult> AllPictureByUsers()
        {
            var model = await service.AllPictureUploadByUsers();
            return View(model);
        }


        [HttpGet]
        [Authorize]
        public IActionResult AddPicture()
        {
            var model = new AddPictureByUser();

            return View(model);
        }

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
