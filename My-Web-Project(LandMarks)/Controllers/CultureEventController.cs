using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Graph.Models;
using MyWebProject.Core.Models.CultureEventModel;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;

namespace My_Web_Project_LandMarks_.Controllers
{

    public class CultureEventController : Controller
    {
        private readonly ICultureEventService service;
        private readonly UserManager<Users> user;
        private readonly IRepository repo;

        public CultureEventController(ICultureEventService _service,
            UserManager<Users> _user,
            IRepository _repo)
        {
            service = _service;
            user = _user;
            repo = _repo;
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



        /// <summary>
        /// A method to get the changed user and add event
        /// collections to the current user.
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns> Message to seccssusfuly added</returns>

        [Authorize]
        public async Task<IActionResult> AddEventByUserCollection(int eventId, string choiceBtn)
        {

            var currentEvent = await repo.GetByIdAsync<Cultural_events>(eventId);
           
            if (currentEvent != null)
            {
                if (choiceBtn == "Може би" && choiceBtn != null
                    && string.IsNullOrEmpty(choiceBtn))
                {
                    currentEvent.Maybe = true;
                }
                else if (choiceBtn == "Ще присъствам" && choiceBtn != null
                    && string.IsNullOrEmpty(choiceBtn))
                {
                    currentEvent.Going = true;
                }

                var currentUser = user.FindByNameAsync(User!.Identity!.Name!.ToUpper()).Result;
                var checkCollection = currentEvent.UserName.FirstOrDefault(x => x.UserName == currentUser.UserName);

                currentUser!.CulturalEvents.Add(currentEvent);

                await repo.SaveChangesAsync();

                return View("GetAllEvent");

            }


            return View("GetAllEvent");
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
