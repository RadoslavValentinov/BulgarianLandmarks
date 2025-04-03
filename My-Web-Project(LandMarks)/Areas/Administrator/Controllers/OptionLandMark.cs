using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_Web_Project_LandMarks_.Controllers;
using MyWebProject.Core.Models.LandMarkModel;
using MyWebProject.Core.Services.IServices;

namespace My_Web_Project_LandMarks_.Areas.Administrator.Controllers
{
    [Authorize]
    [Area("Administrator")]
    [AutoValidateAntiforgeryToken]
    public class OptionLandMark : Controller
    {
        private readonly ILandmarkService landmarks;
        private ILogger<LandMarkController> logger;


        public OptionLandMark(ILandmarkService _landmarks,
        ILogger<LandMarkController> _logger)
        {
            landmarks = _landmarks;
            logger = _logger;
        }


        /// <summary>
        /// Retrieves all landmarks.
        /// </summary>
        /// <returns>View with a collection of all landmarks.</returns>
        public IActionResult Index()
        {
            var model = landmarks.GetAllLandmark().Result;
            return View(model);
        }


        /// <summary>
        /// Retrieves all landmarks added by users.
        /// </summary>
        /// <returns>View with a collection of landmarks added by users.</returns>
        public IActionResult GetByUser()
        {
            var model = landmarks.GetAllByUser().Result;
            return View(model);
        }


        /// <summary>
        /// Retrieves pictures for a specific landmark by its id.
        /// </summary>
        /// <param name="Id">The id of the landmark.</param>
        /// <returns>View with the landmark's pictures.</returns>
        public IActionResult SlidePicture(int Id)
        {
            var lendMarkPicture = landmarks.GetById(Id).Result;
            var model = new LandMarkViewModelAll()
            {
                Id = lendMarkPicture.Id,
                Name = lendMarkPicture.Name,
                Description = lendMarkPicture.Description,
                Rating = lendMarkPicture.Rating,
                TownName = lendMarkPicture.TownName,
                Pictures = lendMarkPicture.Pictures
            };
            return View(model);
        }


        /// <summary>
        /// Adds a new landmark suggested by a user.
        /// </summary>
        /// <param name="newModel">The model containing the landmark data.</param>
        /// <returns>Redirects to the Index action if successful, otherwise logs an error.</returns>
        [HttpGet]
        public async Task<IActionResult> AddLandMarkByUser(AddLandMarkViewModel newModel)
        {
            if (ModelState.IsValid)
            {
                await landmarks.AddLandMark(newModel);
                return RedirectToAction("Index");
            }

            logger.LogError(new ArgumentException(), "The model is not valid");
            return RedirectToAction("Index");
        }
        

        /// <summary>
        /// Loads the view to add a new landmark.
        /// </summary>
        /// <returns>View with a form to add a new landmark.</returns>
        [HttpGet]
        public async Task<IActionResult> AddLandMark()
        {
            var model = new AddLandMarkViewModel()
            {
                Category = await landmarks.AllCategory()
            };
            return View(model);
        }


        /// <summary>
        /// Adds a new landmark.
        /// </summary>
        /// <param name="model">The model containing the landmark data.</param>
        /// <returns>Redirects to the Index action if successful, otherwise logs an error and reloads the add landmark view.</returns>
        [HttpPost]
        public async Task<IActionResult> AddLandMark(AddLandMarkViewModel model)
        {
            if (ModelState.IsValid)
            {
                await landmarks.AddLandMark(model);
                return RedirectToAction("Index");
            }

            logger.LogError(new ArgumentException(), "The model is not valid");
            return View(model);
        }


        /// <summary>
        /// Loads the view to edit an existing landmark.
        /// </summary>
        /// <param name="Id">The id of the landmark to edit.</param>
        /// <returns>View with a form to edit the landmark.</returns>
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var currentLandmark = landmarks.GetById(Id).Result;
            var model = new LandMarkViewModelAll()
            {
                Id = currentLandmark.Id,
                Name = currentLandmark.Name,
                Description = currentLandmark.Description,
                Rating = currentLandmark.Rating,
                TownName = currentLandmark.TownName,
                VideoUrl = currentLandmark.VideoUrl,
            };
            return View(model);
        }


        /// <summary>
        /// Edits an existing landmark.
        /// </summary>
        /// <param name="model">The model containing the updated landmark data.</param>
        /// <returns>Redirects to the Index action if successful, otherwise logs an error and reloads the edit view.</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(LandMarkViewModelAll model)
        {
            if (ModelState.IsValid)
            {
                await landmarks.Edit(model);
                return RedirectToAction("Index");
            }

            logger.LogError(new ArgumentException(), "The Landmark model not updated");
            return View(model);
        }


        /// <summary>
        /// Deletes a landmark by its id.
        /// </summary>
        /// <param name="Id">The id of the landmark to delete.</param>
        /// <returns>Redirects to the Index action.</returns>
        public async Task<IActionResult> Delete(int Id)
        {
            await landmarks.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}