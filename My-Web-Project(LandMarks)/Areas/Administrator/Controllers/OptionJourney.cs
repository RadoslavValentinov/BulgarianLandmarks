using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebProject.Core.Models.JourneyModel;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Infrastructure.Data.Models;

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

        public async Task<IActionResult> Index()
        {
            var all = await journey.GetAll();  

            return View(all);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var model = new JourneyViewModel();

            return View(model);
        }

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

        public async Task<IActionResult> Delete(int id)
        {
            await journey.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
