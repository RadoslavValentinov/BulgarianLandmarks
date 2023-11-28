using Microsoft.AspNetCore.Mvc;
using MyWebProject.Core.Services.IServices;

namespace My_Web_Project_LandMarks_.Controllers
{
    public class JourneyController : Controller
    {
        private readonly IJourneyServise service;

        public JourneyController(IJourneyServise _service)
        {
            service = _service;
        }


        /// <summary>
        /// The method returns a collection of all journeys
        /// accessed by a service
        /// </summary>
        /// <returns>Collection of all journeys</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var model = await service.GetAll();

            return View(model);
        }


        /// <summary>
        /// The method returns the received trip idand passes it through a service method
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Рeturns a trip with the given id</returns>
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var model = await service.GetById(id);

            return View(model);
        }


    }
}
