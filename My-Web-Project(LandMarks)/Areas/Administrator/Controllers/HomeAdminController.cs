using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebProject.Core.Models.AdminHomeModel;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Core.Services.Services;

namespace My_Web_Project_LandMarks_.Areas.Administrator.Controllers
{
    [Authorize]
    [Area("Administrator")]
    public class HomeAdminController : Controller
    {

        private readonly IHomeService service;

        public HomeAdminController(IHomeService _service)
        {
            service = _service;
        }





        /// <summary>
        /// View all controlers(options) access to admin area
        /// to create , added, edit and removed.
        /// </summary>
        /// <returns>All options controllers</returns>
        public IActionResult Index()
        {
            var model =new AdminHomeModelAllData();
            var setData =  service.AllData(model);


            return View(model);
        }
    }
}
