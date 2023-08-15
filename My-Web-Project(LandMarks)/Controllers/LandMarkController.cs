using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebProject.Core.Models.LandMarkModel;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Infrastructure.Data.Models;

namespace My_Web_Project_LandMarks_.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class LandMarkController : Controller
    {
        private readonly ILandmarkService service;
        

        public LandMarkController(ILandmarkService _service)
        {
            service = _service;
        }


        [HttpGet]
        public async Task<IActionResult> LandMarkById(int id)
        {
            if (!await service.ExistById(id))
            {
                ModelState.AddModelError("", "Not Correct data");
            }

            var model = await service.GetById(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AllLandmark()
        {
            var allLandMark = await service.GetAllLandmark();

            if (allLandMark == null)
            {
                return View();
            }

            return View(allLandMark);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddUserSuggestions()
        {
            var model = new LandMarkByUserAdded()
            {
                Category = await service.AllCategory()
            };

            return View(model);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddUserSuggestions(LandMarkByUserAdded model)
        {
            await service.AddLandMarkOfUsers(model);

            return RedirectToAction("AllLandmark");
        }
    }
}
