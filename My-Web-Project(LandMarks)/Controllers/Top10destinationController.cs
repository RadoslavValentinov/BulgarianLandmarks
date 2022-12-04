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
            service= _service;
            mpService= _mpService;
        }


        public async Task<IActionResult> Get10Landmark()
        {
            var model = await service.Get10TopLandMark();

            return View(model);
        }


        public async Task<IActionResult> MysteryPlaces()
        {
            var model = await mpService.MysteryPlaces();

            return View(model);
        }

    }
}
