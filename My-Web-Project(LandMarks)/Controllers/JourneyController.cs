using Microsoft.AspNetCore.Mvc;

namespace My_Web_Project_LandMarks_.Controllers
{
    public class JourneyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
