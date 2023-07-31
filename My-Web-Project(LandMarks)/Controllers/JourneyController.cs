using Microsoft.AspNetCore.Mvc;
using MyWebProject.Core.Services.IServices;

namespace My_Web_Project_LandMarks_.Controllers
{
    public class JourneyController : Controller
    {
        private readonly IJourneyServise service;

        public JourneyController(IJourneyServise _service)
        {
            service= _service;  
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var model = await service.GetAll();

            return View(model);
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetById(int id)
        {
            var model = await service.GetById(id);

            return View(model);
        }


    }
}
