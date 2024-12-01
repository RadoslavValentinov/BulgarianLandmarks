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

        public IActionResult Index()
        {
            var setAll = service.AllFacts().Result;

            return View(setAll);
        }


        [HttpGet]
        public async Task<IActionResult> AddFacts()
        {
            var model = new FactOfCountry()
            {
                Category = await service.AllCategory()
            };

            return View(model);
        }


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


        public async Task<IActionResult> Delete(int Id)
        {
            await service.Delete(Id);

            return RedirectToAction("Index");
        }
    }
}
