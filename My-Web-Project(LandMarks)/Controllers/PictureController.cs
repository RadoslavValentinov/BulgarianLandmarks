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


    }
}
