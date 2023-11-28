﻿using MyWebProject.Core.Models.Category;
using MyWebProject.Core.Models.FactOfBulgaria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebProject.Core.Services.IServices
{
    public interface IFactsService
    {
        Task<IEnumerable<AllFactsViewModel>> AllFacts();

        Task<FactOfCountry> GetFactById(int id);

        Task<FactOfCountry> AddFacts(FactOfCountry model);

        Task<FactOfCountry> EditFact(FactOfCountry model);

        Task Delete(int Id);

        Task<IEnumerable<CategoryViewModel>> AllCategory();
    }
}
