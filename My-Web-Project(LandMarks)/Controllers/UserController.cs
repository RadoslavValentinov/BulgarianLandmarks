using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using My_Web_Project_LandMarks_.Core.Models;
using My_Web_Project_LandMarks_.Infrastructure.Data.Models;

namespace My_Web_Project_LandMarks_.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly SignInManager<Users> signInManager;
        private readonly UserManager<Users> userManager;

        public UserController(SignInManager<Users> _signInManager,
            UserManager<Users> _userManager
            )
        {
            signInManager = _signInManager;
            userManager = _userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user  = await userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var results = await signInManager.PasswordSignInAsync(user,model.Password,false,false);

                if (results.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }
            }

            ModelState.AddModelError("","Invalid login");

            return View(model);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            var model = new RegisterViewModel();

            return View(model);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new Users()
            {
                UserName = model.FirstName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
            };

            var registerUser = await userManager.CreateAsync(user,model.Password);

            if (registerUser.Succeeded)
            {
                return RedirectToAction("Login","User");
            }

            foreach (var error in registerUser.Errors)
            {
                ModelState.AddModelError("",error.Description);
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index","Home");
        }
    }
}
