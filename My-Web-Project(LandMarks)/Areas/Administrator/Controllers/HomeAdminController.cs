using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace My_Web_Project_LandMarks_.Areas.Administrator.Controllers
{
    [Authorize]
    [Area("Administrator")]
    public class HomeAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
