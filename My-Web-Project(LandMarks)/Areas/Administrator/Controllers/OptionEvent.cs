using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebProject.Core.Models.CultureEventModel;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;

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



        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var culEvent = await events.AllEvent();

            return View(culEvent);
        }


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


        [HttpGet]
        public IActionResult AddEvent()
        {
            var model = new CultureEventViewModelByTownId();

            return View(model);
        }

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


        public async Task<IActionResult> Delete(int id)
        {
            await events.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
