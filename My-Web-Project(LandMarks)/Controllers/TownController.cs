using Microsoft.AspNetCore.Mvc;
using MyWebProject.Core.Models.Town;
using MyWebProject.Core.Services.IServices;

namespace My_Web_Project_LandMarks_.Controllers
{
    public class TownController : Controller
    {
        public readonly ITownService service;

        public TownController(ITownService _service)
        {
            service = _service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var rest = await service.AllTowns();

            return View(rest);
        }

        [HttpGet]
        public async Task<IActionResult> GetTown(int id) 
        {
            var rest = await service.TownsById(id);

            //var model = new TownViewModelGetTown();

            if (rest != null)
            {
                return View(rest);
            }

            return View();
        }

    }
}
