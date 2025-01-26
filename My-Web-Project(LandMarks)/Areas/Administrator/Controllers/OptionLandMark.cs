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

        public IActionResult Index()
        {
            var model = landmarks.GetAllLandmark().Result;

            return View(model);
        }


        public IActionResult GetByUser()
        {
            var model = landmarks.GetAllByUser().Result;

            return View(model);
        }


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



        [HttpGet]
        public async Task<IActionResult> AddLandMark()
        {
            var model = new AddLandMarkViewModel()
            {
                Category = await landmarks.AllCategory()
            };
            return View(model);
        }


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


        public async Task<IActionResult> Delete(int Id)
        {
            await landmarks.Delete(Id);

            return RedirectToAction("Index");
        }
    }
}
