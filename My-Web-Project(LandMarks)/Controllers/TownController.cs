using Microsoft.AspNetCore.Mvc;

namespace My_Web_Project_LandMarks_.Controllers
{
    public class TownController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
