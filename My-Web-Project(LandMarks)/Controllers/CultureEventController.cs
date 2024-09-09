using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Graph.Models;
using MyWebProject.Core.Models.CultureEventModel;
using MyWebProject.Core.Services.IServices;

namespace My_Web_Project_LandMarks_.Controllers
{

    public class CultureEventController : Controller
    {
        private readonly ICultureEventService service;

        public CultureEventController(ICultureEventService _service)
        {
            service = _service;
        }


        /// <summary>
        /// The method returns a city by the given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>city by the given Id</returns>
        [HttpGet]
        public async Task<IActionResult> EventByTownId(int id)
        {
            var model = await service.EventByTownId(id);

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> AddEventByUserCollection(int eventId)
        {

            var currentEvent = await service.EventByTownId(eventId);

            var model = new CultureEventViewModelByTownId(){
                Id = currentEvent.Id,
                Name = currentEvent.Name,
                Description = currentEvent.Description,
                Date = currentEvent.Date,
                Hour = currentEvent.Hour,
                TownName = currentEvent.TownName,
                UserEvents = User?.Identity?.Name,
            };


            await service.AddUserEventCollection(model);



            return ViewBag("Your choise to event succssessfuly added!");
        }


        /// <summary>
        /// The method takes all cities
        /// </summary>
        /// <returns>All Towns collection</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllEvent()
        {
            var model = await service.AllEvent();

            return View(model);
        }


    }
}
