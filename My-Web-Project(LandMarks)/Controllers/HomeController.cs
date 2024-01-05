﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Graph.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using My_Web_Project_LandMarks_.Models;
using MyWebProject.Core.Models.SearchEngineModel;
using MyWebProject.Core.Services.IServices;
using NuGet.Packaging.Signing;
using System.Diagnostics;

namespace My_Web_Project_LandMarks_.Controllers
{
    public class HomeController : Controller
    {
        public readonly IHomeService service;

        public HomeController(IHomeService _service)
        {
            service = _service;
        }


        /// <summary>
        /// The method takes a collection of all the photos in the database
        /// </summary>
        /// <returns>collection of photos</returns>
        public async Task<IActionResult> Index()
        {
            var result = await service.AllPicture();

            return View(result);
        }


        [HttpPost]
        public IActionResult Search(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return View();
            }
            else
            {
                var result = service.ShearchItem(search).Result;

                return View(result);
            }

        }


        /// <summary>
        /// Loads a view with information about the support contacts
        /// </summary>
        /// <returns>Тhrows a view</returns>
        public IActionResult ContactUs()
        {
            return View();
        }


        /// <summary>
        /// Loads a privacy policy page currently copied from another site
        /// </summary>
        /// <returns>Privacy policy page</returns>
        public IActionResult Privacy()
        {
            return View();
        }


        /// <summary>
        /// Error view
        /// </summary>
        /// <returns>Error view model</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}