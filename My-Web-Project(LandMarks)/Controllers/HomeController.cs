using Microsoft.AspNetCore.Mvc;
using My_Web_Project_LandMarks_.Models;
using MyWebProject.Core.Services.IServices;
using System.Diagnostics;

namespace My_Web_Project_LandMarks_.Controllers
{
    public class HomeController : Controller
    {
        public readonly IHomeService service;

        public HomeController(IHomeService _service)
        {
            service= _service;
        }

        public async Task<IActionResult> Index()
        {
            var result = await service.AllPicture();

            return View(result);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}