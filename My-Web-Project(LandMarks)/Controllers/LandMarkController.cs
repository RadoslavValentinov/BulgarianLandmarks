using Microsoft.AspNetCore.Mvc;

namespace My_Web_Project_LandMarks_.Controllers
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
