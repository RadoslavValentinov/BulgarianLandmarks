using Microsoft.AspNetCore.Mvc;
using MyWebProject.Core.Services.IServices;

namespace My_Web_Project_LandMarks_.Controllers
{
    public class LandMarkController : Controller
    {
        private readonly ILandmarkService service;

        public LandMarkController(ILandmarkService _service)
        {
            service= _service;
        }


        public async Task<IActionResult> LandMarkById(int id)
        {
            if (!await service.ExistById(id))
            {
                ModelState.AddModelError("","Not Corect data");
            }

            var model = await service.GetById(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AllLandmark()
        {
            var allLandMark = await service.GetAllLandmark();

            if (allLandMark ==null)
            {
                return View();
            }

            return View(allLandMark);
        }
    }
}
