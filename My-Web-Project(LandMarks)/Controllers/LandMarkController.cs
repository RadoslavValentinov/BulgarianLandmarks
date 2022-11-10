using Microsoft.AspNetCore.Mvc;

namespace MyWebProject.Controllers
{
    public class LandMarkController : Controller
    {
        public async Task<IActionResult> LandMarkByTown(int id)
        {
            return View();
        }

        public async Task<IActionResult> AllLandmark()
        {
            return View();
        }
    }
}
