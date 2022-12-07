using Microsoft.AspNetCore.Mvc;
using MyWebProject.Core.Models.LandMarkModel;
using MyWebProject.Core.Services.IServices;

namespace My_Web_Project_LandMarks_.Controllers
{
    public class LandMarkController : Controller
    {
        private readonly ILandmarkService service;

        public LandMarkController(ILandmarkService _service)
        {
            service = _service;
        }


        public async Task<IActionResult> LandMarkById(int id)
        {
            if (!await service.ExistById(id))
            {
                ModelState.AddModelError("", "Not Corect data");
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
        public async Task<IActionResult> AddLandMark()
        {
            var model = new AddLandMarkViewModel() 
            {
                Categories = await service.AllCategory()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddLandMark(AddLandMarkViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = service.AllCategory();

            var land = await service.AddLandMark(model);
            if (land > 1)
            {
                return RedirectToAction("Home", "Index");
            }

           
            return View(model);
        }
    }
}
