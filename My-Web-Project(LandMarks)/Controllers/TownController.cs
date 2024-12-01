using Microsoft.AspNetCore.Mvc;
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


        /// <summary>
        /// The method selects six cities from the database
        /// </summary>
        /// <returns>Collection of towns</returns>
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var rest = await service.AllTowns();

            return View(rest);
        }


        /// <summary>
        /// The method searches for a city by the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns“Returns the city its cultural events and attractions, if available</returns>
        [HttpGet]
        public async Task<IActionResult> GetTown(int id)
        {
            var rest = await service.TownsById(id);

            if (rest != null)
            {
                return View(rest);
            }

            return View();
        }

    }
}