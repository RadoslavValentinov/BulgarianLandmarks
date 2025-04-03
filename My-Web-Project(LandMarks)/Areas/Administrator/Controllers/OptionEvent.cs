using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebProject.Core.Models.CultureEventModel;
using MyWebProject.Core.Services.IServices;

namespace My_Web_Project_LandMarks_.Areas.Administrator.Controllers
{
    [Authorize]
    [Area("Administrator")]
    [AutoValidateAntiforgeryToken]
    public class OptionEvent : Controller
    {
        private readonly ICultureEventService events;

        public OptionEvent(ICultureEventService _events)
        {
            events = _events;
        }


        /// <summary>
        /// Retrieves all cultural events.
        /// </summary>
        /// <returns>View with a collection of all cultural events.</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var culEvent = await events.AllEvent();
            return View(culEvent);
        }


        /// <summary>
        /// Loads the view to edit an existing cultural event.
        /// </summary>
        /// <param name="Id">The id of the cultural event to edit.</param>
        /// <returns>View with a form to edit the cultural event.</returns>
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var getEvent = events.EventByTownId(Id).Result;
            var model = new CultureEventViewModelByTownId()
            {
                Id = Id,
                Name = getEvent.Name,
                Description = getEvent.Description,
                Date = getEvent.Date,
                Hour = getEvent.Hour,
                TownName = getEvent.TownName,
                ImageURL = getEvent.ImageURL,
            };
            return View(model);
        }


        /// <summary>
        /// Edits an existing cultural event.
        /// </summary>
        /// <param name="model">The model containing the updated cultural event data.</param>
        /// <returns>Redirects to the Index action if successful, otherwise reloads the edit view.</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(CultureEventViewModelByTownId model)
        {
            if (ModelState.IsValid)
            {
                await events.Edit(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        /// <summary>
        /// Loads the view to add a new cultural event.
        /// </summary>
        /// <returns>View with a form to add a new cultural event.</returns>
        [HttpGet]
        public IActionResult AddEvent()
        {
            var model = new CultureEventViewModelByTownId();
            return View(model);
        }


        /// <summary>
        /// Adds a new cultural event.
        /// </summary>
        /// <param name="model">The model containing the cultural event data.</param>
        /// <returns>Redirects to the Index action if successful, otherwise reloads the add event view.</returns>
        [HttpPost]
        public async Task<IActionResult> AddEvent(CultureEventViewModelByTownId model)
        {
            if (ModelState.IsValid)
            {
                await events.Create(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        /// <summary>
        /// Deletes a cultural event by its id.
        /// </summary>
        /// <param name="id">The id of the cultural event to delete.</param>
        /// <returns>Redirects to the Index action.</returns>
        public async Task<IActionResult> Delete(int id)
        {
            await events.Delete(id);
            return RedirectToAction("Index");
        }
    }
}