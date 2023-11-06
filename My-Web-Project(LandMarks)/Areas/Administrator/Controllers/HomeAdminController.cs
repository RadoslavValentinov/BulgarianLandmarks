using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace My_Web_Project_LandMarks_.Areas.Administrator.Controllers
{
    [Authorize]
    [Area("Administrator")]
    public class HomeAdminController : Controller
    {
        /// <summary>
        /// View all controlers(options) access to admin area
        /// to create , added, edit and removed.
        /// </summary>
        /// <returns>All options controllers</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
