using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebProject.Core.Models.JourneyModel;
using MyWebProject.Core.Services.IServices;

namespace My_Web_Project_LandMarks_.Areas.Administrator.Controllers
{
    [Authorize]
    [Area("Administrator")]
    [AutoValidateAntiforgeryToken]
    public class OptionJourney : Controller
    {
        private readonly IJourneyServise journey;

        public OptionJourney(IJourneyServise _journey)
        {
            journey = _journey;
        }


        /// <summary>
        /// Retrieves all journeys.
        /// </summary>
        /// <returns>View with a collection of all journeys.</returns>
        public async Task<IActionResult> Index()
        {
            var all = await journey.GetAll();
            return View(all);
        }


        /// <summary>
        /// Loads the view to create a new journey.
        /// </summary>
        /// <returns>View with a form to create a new journey.</returns>
        [HttpGet]
        public IActionResult Create()
        {
            var model = new JourneyViewModel();
            return View(model);
        }


        /// <summary>
        /// Creates a new journey.
        /// </summary>
        /// <param name="model">The model containing the journey data.</param>
        /// <returns>Redirects to the Index action if successful, otherwise reloads the create view.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(JourneyViewModel model)
        {
            if (ModelState.IsValid)
            {
                await journey.Create(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        /// <summary>
        /// Loads the view to edit an existing journey.
        /// </summary>
        /// <param name="Id">The id of the journey to edit.</param>
        /// <returns>View with a form to edit the journey.</returns>
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var currentJourney = journey.GetByIdNewModel(Id).Result;
            var model = new JourneyViewModel()
            {
                Id = Id,
                Name = currentJourney.Name,
                Description = currentJourney.Description,
                Rating = currentJourney.Rating,
                StartDate = currentJourney.StartDate,
                Day = currentJourney.Day,
                Price = currentJourney.Price,
                Urladdress = currentJourney.Urladdress
            };
            return View(model);
        }


        /// <summary>
        /// Edits an existing journey.
        /// </summary>
        /// <param name="model">The model containing the updated journey data.</param>
        /// <returns>Redirects to the Index action if successful, otherwise reloads the edit view.</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(JourneyViewModel model)
        {
            if (ModelState.IsValid)
            {
                await journey.Edit(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        /// <summary>
        /// Deletes a journey by its id.
        /// </summary>
        /// <param name="id">The id of the journey to delete.</param>
        /// <returns>Redirects to the Index action.</returns>
        public async Task<IActionResult> Delete(int id)
        {
            await journey.Delete(id);
            return RedirectToAction("Index");
        }
    }
}