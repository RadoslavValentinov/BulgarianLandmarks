using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebProject.Core.Models.Category;
using MyWebProject.Core.Services.IServices;


namespace My_Web_Project_LandMarks_.Areas.Administrator.Controllers
{
    [Authorize]
    [Area("Administrator")]
    [AutoValidateAntiforgeryToken]
    public class OptionCategory : Controller
    {
        private readonly ICategoryService service;

        public OptionCategory(ICategoryService _service)
        {
            service = _service;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allCategory = await service.AllCategory();

            return View(allCategory);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateCategoryViewModel();

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                await service.CreateCategory(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var current = await service.GetById(id);

            var model = new CategoryViewModel()
            {
                Id = current.Id,
                Name = current.Name
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                await service.EditCategory(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }


        public async Task<IActionResult> Delete(int id)
        {
            await service.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
