using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebProject.Core.Models.FactOfBulgaria;
using MyWebProject.Core.Services.IServices;

namespace My_Web_Project_LandMarks_.Areas.Administrator.Controllers
{
    [Authorize]
    [Area("Administrator")]
    [AutoValidateAntiforgeryToken]
    public class OptionFacts : Controller
    {
        private IFactsService service;

        public OptionFacts(IFactsService _service)
        {
            service = _service;
        }


        /// <summary>
        /// Retrieves all facts.
        /// </summary>
        /// <returns>View with a collection of all facts.</returns>
        public IActionResult Index()
        {
            var setAll = service.AllFacts().Result;
            return View(setAll);
        }


        /// <summary>
        /// Loads the view to add a new fact.
        /// </summary>
        /// <returns>View with a form to add a new fact.</returns>
        [HttpGet]
        public async Task<IActionResult> AddFacts()
        {
            var model = new FactOfCountry()
            {
                Category = await service.AllCategory()
            };
            return View(model);
        }


        /// <summary>
        /// Adds a new fact.
        /// </summary>
        /// <param name="model">The model containing the fact data.</param>
        /// <returns>Redirects to the Index action if successful, otherwise reloads the add fact view.</returns>
        [HttpPost]
        public async Task<IActionResult> AddFacts(FactOfCountry model)
        {
            if (ModelState.IsValid)
            {
                await service.AddFacts(model);
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Model is not valid");
            return View(model);
        }


        /// <summary>
        /// Loads the view to edit an existing fact.
        /// </summary>
        /// <param name="id">The id of the fact to edit.</param>
        /// <returns>View with a form to edit the fact.</returns>
        [HttpGet]
        public async Task<IActionResult> EditFact(int id)
        {
            var cuurent = await service.GetFactById(id);
            var model = new FactOfCountry()
            {
                Id = id,
                Description = cuurent.Description,
                CategoryId = cuurent.CategoryId
            };
            return View(model);
        }


        /// <summary>
        /// Edits an existing fact.
        /// </summary>
        /// <param name="model">The model containing the updated fact data.</param>
        /// <returns>Redirects to the Index action if successful, otherwise reloads the edit fact view.</returns>
        [HttpPost]
        public async Task<IActionResult> EditFact(FactOfCountry model)
        {
            if (ModelState.IsValid)
            {
                await service.EditFact(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        /// <summary>
        /// Deletes a fact by its id.
        /// </summary>
        /// <param name="Id">The id of the fact to delete.</param>
        /// <returns>Redirects to the Index action.</returns>
        public async Task<IActionResult> Delete(int Id)
        {
            await service.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}