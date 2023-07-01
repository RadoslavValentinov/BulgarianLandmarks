using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyWebProject.Core.Models;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;

namespace My_Web_Project_LandMarks_.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly SignInManager<Users> signInManager;
        private readonly UserManager<Users> userManager;
        private readonly IRepository repo;
       
        public UserController(SignInManager<Users> _signInManager,
            UserManager<Users> _userManager,
            IRepository _repo)
        {
            signInManager = _signInManager;
            userManager = _userManager;
            repo = _repo;
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

            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var results = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (results.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid login");

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
                IsActiv = true,
                Email = model.Email,
                EmailConfirmed = true
            };

            await userManager.AddToRoleAsync(user, "User");
            var registerUser = await userManager.CreateAsync(user, model.Password);

            if (registerUser.Succeeded)
            {
                return RedirectToAction("Login", "User");
            }

            foreach (var error in registerUser.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        ///// <summary>
        ///// this method get info for user
        ///// and load page field
        ///// </summary>
        ///// <returns>
        ///// all info of the current user
        ///// </returns>

        [HttpGet]
        public IActionResult ManageUserPage()
        {
            var model = new UserManegePageViewModel();

            var userGet = userManager.GetUserId(HttpContext.User);
            var currerntUsers = userManager.FindByIdAsync(userGet).Result;

            if (currerntUsers != null)
            {
                model = new UserManegePageViewModel()
                {
                    UserName = currerntUsers.UserName,
                    Avatar = currerntUsers.Avatar,
                    FirstName = currerntUsers.FirstName,
                    LastName = currerntUsers.LastName,
                };

                return View(model);
            }

            return View(model);
        }


        /// <summary>
        /// Methot get current User information and 
        /// update FirstName,Lastname and Email of on form in View.
        /// second form update user password
        /// </summary>
        /// <param name="model"></param>
        /// <returns>return message to update info from current user </returns>

        [HttpPost]
        public async Task<IActionResult> ManageUserPage(UserManegePageViewModel model)
        {
            if (!string.IsNullOrEmpty(model.ConfirmPassword) && !string.IsNullOrEmpty(model.OldPassword) && !string.IsNullOrEmpty(model.newPassword))
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var userInfo = userManager.GetUserId(HttpContext.User);
                        var userUpdate = userManager.FindByIdAsync(userInfo).Result;

                        if (userUpdate != null)
                        {
                            var result = await userManager.ChangePasswordAsync(userUpdate, model.OldPassword, model.newPassword);
                            if (result.Succeeded)
                            {
                                ViewBag.Message = $"{userUpdate.UserName}  Your password cuccessfully!";
                                return RedirectToAction("Index", "Home");
                            }

                            ModelState.AddModelError("", "Your new password not corectly");
                        }

                    }
                    catch (ArgumentException ae)
                    {
                        new ArgumentException("Not found current User", ae.Message);
                    }

                    return View(model);
                }


            }
            if (!string.IsNullOrEmpty(model.FirstName) || !string.IsNullOrEmpty(model.UserName) || !string.IsNullOrEmpty(model.LastName) || !string.IsNullOrEmpty(model.Email))
            {

                if (ModelState.IsValid)
                {
                    try
                    {
                        var userId = userManager.GetUserId(HttpContext.User);
                        var user = userManager.FindByIdAsync(userId).Result;

                        if (!string.IsNullOrEmpty(model.UserName))
                        {
                            user.UserName = model.UserName;
                        }
                        if (!string.IsNullOrEmpty(model.FirstName))
                        {
                            user.FirstName = model.FirstName;
                        }
                        if (!string.IsNullOrEmpty(model.LastName))
                        {
                            user.LastName = model.LastName;
                        }
                        if (!string.IsNullOrEmpty(model.Email))
                        {
                            user.Email = model.Email;
                        }

                        await userManager.UpdateAsync(user);
                    }
                    catch (ArgumentException ae)
                    {
                        new ArgumentException("Not found current User", ae.Message);
                    }
                }
            }

            ViewBag.Message = "Your information is upadeted.";
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
