using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebProject.Core.Models;
using MyWebProject.Core.Services.IServices;

namespace My_Web_Project_LandMarks_.Areas.Administrator.Controllers
{
    [Authorize]
    [Area("Administrator")]
    [AutoValidateAntiforgeryToken]
    public class UsersOptions : Controller
    {
        private readonly IUserService service;


        public UsersOptions(IUserService _service)
        {
            service = _service;
        }



        [HttpGet]
        public async Task<IActionResult> AllUsers(UserviewModel model)
        {
            var users = await service.GetAllUsers(model);

            return View(users);
        }
    }
}
