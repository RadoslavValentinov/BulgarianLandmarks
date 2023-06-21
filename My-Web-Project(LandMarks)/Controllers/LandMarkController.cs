using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebProject.Core.Models.LandMarkModel;
using MyWebProject.Core.Services.IServices;

namespace My_Web_Project_LandMarks_.Controllers
{
    public class LandMarkController : Controller
    {
        private readonly ILandmarkService service;
        private ILogger<LandMarkController> logger;

        public LandMarkController(ILandmarkService _service, 
            ILogger<LandMarkController> logger)
        {
            service = _service;
            this.logger = logger;
        }


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
        public async Task<IActionResult> AddLandMark()
        {
            var model = new AddLandMarkViewModel()
            {
                Category =await service.AllCategory()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddLandMark(AddLandMarkViewModel model)
        {
            if (ModelState.IsValid)
            {
                await service.AddLandMark(model);

                return  RedirectToAction("AllLandmark","LandMark"); 
            }

            logger.LogError(model.Name,"Not added you parameters");

            return View(model);
        }
    }
}
