using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyWebProject.Core.Models.CultureEventModel;
using MyWebProject.Core.Services.IServices;

namespace My_Web_Project_LandMarks_.Controllers
{
    public class CultureEventController : Controller
    {
        private readonly ICultureEventService service;

        public CultureEventController(ICultureEventService _service)
        {
            service= _service;
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EventByTownId(int id)
        {
            var model = await service.EventByTownId(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvent()
        {
            var model = await service.AllEvent();

            return View(model);
        }


    }
}
