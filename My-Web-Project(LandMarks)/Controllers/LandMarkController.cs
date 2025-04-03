using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebProject.Core.Models.LandMarkModel;
using MyWebProject.Core.Services.IServices;

namespace My_Web_Project_LandMarks_.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class LandMarkController : Controller
    {
        private readonly ILandmarkService service;

        public LandMarkController(ILandmarkService _service)
        {
            service = _service;
        }

        /// <summary>
        /// The method searches for a landmark by the given id.
        /// </summary>
        /// <param name="id">The id of the landmark.</param>
        /// <returns>Returns a landmark with the given id.</returns>
        [HttpGet]
        public async Task<IActionResult> LandMarkById(int id)
        {
            if (!await service.ExistById(id))
            {
                ModelState.AddModelError("", "Not Correct data");
            }

            var model = await service.GetById(id);

            return View(model);
        }

        /// <summary>
        /// The method retrieves all landmarks.
        /// </summary>
        /// <returns>Collection of landmarks.</returns>
        [HttpGet]
        public async Task<IActionResult> AllLandmark()
        {
            var allLandMark = await service.GetAllLandmark();

            if (allLandMark == null)
            {
                return View();
            }

            return View(allLandMark);
        }

        /// <summary>
        /// The method loads a view for the user to add a landmark 
        /// as the model loads the categories preloaded dropdown menu.
        /// </summary>
        /// <returns>View of field to write of user.</returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddUserSuggestions()
        {
            var model = new AddLandMarkViewModel()
            {
                Category = await service.AllCategory()
            };

            return View(model);
        }

        /// <summary>
        /// The method increases the rating of a landmark by its id.
        /// </summary>
        /// <param name="id">The id of the landmark.</param>
        /// <returns>Redirects to the AllLandmark action.</returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> UpRatting(int id)
        {
            var result = await service.UpRattingPoint(id);

            return RedirectToAction("AllLandmark");
        }

        /// <summary>
        /// Adds the user-suggested landmark to the pending admin approval table.
        /// </summary>
        /// <param name="model">The model containing the landmark data.</param>
        /// <returns>Redirects to the AllLandmark action.</returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddUserSuggestions(AddLandMarkViewModel model)
        {
            model.UserName = User.Identity?.Name;
            await service.AddLandMarkOfUsers(model);

            return RedirectToAction("AllLandmark");
        }
    }
}