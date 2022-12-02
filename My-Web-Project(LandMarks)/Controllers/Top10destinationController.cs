using Microsoft.AspNetCore.Mvc;
using MyWebProject.Core.Services.IServices;

namespace My_Web_Project_LandMarks_.Controllers
{
    public class Top10destinationController : Controller
    {
        private readonly ITop10Destination service;

        public Top10destinationController(ITop10Destination _service)
        {
            service= _service;  
        }


        public async Task<IActionResult> Get10Landmark()
        {
            var model = await service.Get10TopLandMark();

            return View(model);
        }
    }
}
