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

        public IActionResult Index()
        {
            var getAll = town.AllTowns().Result;

            return View(getAll);
        }

    
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




        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateTownViewModel();

            return View(model);
        }

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


        public async Task<IActionResult> Delete(int Id)
        {
            await town.Delete(Id);

            return RedirectToAction("Index");
        }
    }
}
