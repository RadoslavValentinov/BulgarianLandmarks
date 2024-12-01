using Microsoft.AspNetCore.Mvc;
using MyWebProject.Core.Services.IServices;

namespace My_Web_Project_LandMarks_.Controllers
{
    public class Top10destinationController : Controller
    {
        private readonly ITop10Destination service;
        private readonly IMysteryPlace mpService;

        public Top10destinationController(ITop10Destination _service,
            IMysteryPlace _mpService)
        {
            service = _service;
            mpService = _mpService;
        }

        /// <summary>
        /// The method returns a collection of landmarks with a rating above 9, taking the top 10
        /// </summary>
        /// <returns>Collection</returns>
        public async Task<IActionResult> Get10Landmark()
        {
            var model = await service.Get10TopLandMark();

            return View(model);
        }

        /// <summary>
        /// The method returns a collection of landmarks with a rating above 
        /// 9 that have an address added to a video about the landmark
        /// </summary>
        /// <returns>Collection of landmarks</returns>
        public async Task<IActionResult> MysteryPlaces()
        {
            var model = await mpService.MysteryPlaces();

            return View(model);
        }


        /// <summary>
        /// The method returns a collection of landmarks and their 
        /// associated cities with a rating greater than 9
        /// </summary>
        /// <returns>Collection of landmarks</returns>
        public async Task<IActionResult> AllLandMarkByTown()
        {
            var model = await service.AllLandMarkByTown();

            return View(model);
        }

    }
}
