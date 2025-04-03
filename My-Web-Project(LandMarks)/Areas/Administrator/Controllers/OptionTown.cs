using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebProject.Core.Models.Town;
using MyWebProject.Core.Services.IServices;

namespace My_Web_Project_LandMarks_.Areas.Administrator.Controllers
{
    [Authorize]
    [Area("Administrator")]
    [AutoValidateAntiforgeryToken]
    public class OptionTown : Controller
    {
        private readonly ITownService town;

        public OptionTown(ITownService _town)
        {
            town = _town;
        }


        /// <summary>
        /// Retrieves all towns.
        /// </summary>
        /// <returns>View with a collection of all towns.</returns>
        public IActionResult Index()
        {
            var getAll = town.AllTowns().Result;
            return View(getAll);
        }


        /// <summary>
        /// Retrieves all pictures for a specific town by its id.
        /// </summary>
        /// <param name="Id">The id of the town.</param>
        /// <returns>View with the town's pictures.</returns>
        public IActionResult SeeAllPicture(int Id)
        {
            var lendMarkPicture = town.TownsById(Id).Result;
            var model = new TownViewModelAll()
            {
                Id = lendMarkPicture.Id,
                Name = lendMarkPicture.Name,
                Description = lendMarkPicture.Description,
                Picture = lendMarkPicture.Picture,
                Landmarks = lendMarkPicture.Landmarks,
                cultural_Events = lendMarkPicture.cultural_Events
            };
            return View(model);
        }


        /// <summary>
        /// Retrieves all landmarks for a specific town by its id.
        /// </summary>
        /// <param name="Id">The id of the town.</param>
        /// <returns>View with the town's landmarks.</returns>
        public IActionResult SeeAllLandMarks(int Id)
        {
            var lendMarkPicture = town.TownsById(Id).Result;
            var model = new TownViewModelAll()
            {
                Id = lendMarkPicture.Id,
                Name = lendMarkPicture.Name,
                Description = lendMarkPicture.Description,
                Picture = lendMarkPicture.Picture,
                Landmarks = lendMarkPicture.Landmarks,
                cultural_Events = lendMarkPicture.cultural_Events
            };
            return View(model);
        }


        /// <summary>
        /// Retrieves all events for a specific town by its id.
        /// </summary>
        /// <param name="Id">The id of the town.</param>
        /// <returns>View with the town's events.</returns>
        public IActionResult SeeAllEvents(int Id)
        {
            var lendMarkPicture = town.TownsById(Id).Result;
            var model = new TownViewModelAll()
            {
                Id = lendMarkPicture.Id,
                Name = lendMarkPicture.Name,
                Description = lendMarkPicture.Description,
                Picture = lendMarkPicture.Picture,
                Landmarks = lendMarkPicture.Landmarks,
                cultural_Events = lendMarkPicture.cultural_Events
            };
            return View(model);
        }


        /// <summary>
        /// Loads the view to create a new town.
        /// </summary>
        /// <returns>View with a form to create a new town.</returns>
        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateTownViewModel();
            return View(model);
        }


        /// <summary>
        /// Creates a new town.
        /// </summary>
        /// <param name="model">The model containing the town data.</param>
        /// <returns>Redirects to the Index action if successful, otherwise reloads the create view.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateTownViewModel model)
        {
            if (ModelState.IsValid)
            {
                await town.CreateTown(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        /// <summary>
        /// Loads the view to edit an existing town.
        /// </summary>
        /// <param name="Id">The id of the town to edit.</param>
        /// <returns>View with a form to edit the town.</returns>
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var editdTown = town.TownsById(Id).Result;
            var model = new TownViewModelGetTown()
            {
                Id = editdTown.Id,
                Name = editdTown.Name,
                Description = editdTown.Description,
            };
            return View(model);
        }


        /// <summary>
        /// Edits an existing town.
        /// </summary>
        /// <param name="model">The model containing the updated town data.</param>
        /// <returns>Redirects to the Index action if successful, otherwise reloads the edit view.</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(TownViewModelGetTown model)
        {
            if (ModelState.IsValid)
            {
                await town.Edit(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        /// <summary>
        /// Deletes a town by its id.
        /// </summary>
        /// <param name="Id">The id of the town to delete.</param>
        /// <returns>Redirects to the Index action.</returns>
        public async Task<IActionResult> Delete(int Id)
        {
            await town.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}