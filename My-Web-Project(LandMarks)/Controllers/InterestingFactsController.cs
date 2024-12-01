﻿using Microsoft.AspNetCore.Mvc;
using MyWebProject.Core.Services.IServices;

namespace My_Web_Project_LandMarks_.Controllers
{
    public class InterestingFactsController : Controller
    {
        private IFactsService service;

        public InterestingFactsController(IFactsService _service)
        {
            service = _service;
        }


        /// <summary>
        /// The method returns a collection of all interesting Facts
        /// </summary>
        /// <returns>Collection of all interesting Facts</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllFacts()
        {
            var allfacts = await service.AllFacts();

            if (allfacts == null)
            {
                return View();
            }

            return View(allfacts);
        }
    }
}
