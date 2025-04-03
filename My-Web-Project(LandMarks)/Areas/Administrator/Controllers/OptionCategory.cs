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



        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        /// <returns>View with a collection of all categories.</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allCategory = await service.AllCategory();
            return View(allCategory);
        }


        /// <summary>
        /// Loads the view to create a new category.
        /// </summary>
        /// <returns>View with a form to create a new category.</returns>
        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateCategoryViewModel();
            return View(model);
        }



        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="model">The model containing the category data.</param>
        /// <returns>Redirects to the Index action if successful, otherwise reloads the create view.</returns>
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



        /// <summary>
        /// Loads the view to edit an existing category.
        /// </summary>
        /// <param name="id">The id of the category to edit.</param>
        /// <returns>View with a form to edit the category.</returns>
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


        /// <summary>
        /// Edits an existing category.
        /// </summary>
        /// <param name="model">The model containing the updated category data.</param>
        /// <returns>Redirects to the Index action if successful, otherwise reloads the edit view.</returns>
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


        /// <summary>
        /// Deletes a category by its id.
        /// </summary>
        /// <param name="id">The id of the category to delete.</param>
        /// <returns>Redirects to the Index action.</returns>
        public async Task<IActionResult> Delete(int id)
        {
            await service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}