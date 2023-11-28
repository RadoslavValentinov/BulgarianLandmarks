using Ganss.Xss;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebProject.Core.Models.Category;
using MyWebProject.Core.Models.CultureEventModel;
using MyWebProject.Core.Models.FactOfBulgaria;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace MyWebProject.Core.Services.Services
{
    public class FactsService : IFactsService
    {
        private readonly IRepository repo;

        public FactsService(IRepository _repo)
        {
            repo = _repo;
        }


        [Area("Administrator")]
        public async Task<FactOfCountry> AddFacts(FactOfCountry model)
        {
            var exist = await repo.AllReadonly<Category>()
                .FirstOrDefaultAsync(c => c.Id == model.CategoryId);

            var sanitizer = new HtmlSanitizer();

            string description = sanitizer.Sanitize(model.Description);

            if (exist == null || string.IsNullOrWhiteSpace(description))
            {
                throw new NullReferenceException("The model Property is Requared not by Empty");
            }

            var fact = new InterestingFacts()
            {
                Id = model.Id,
                Description = description,
                CategoryId= model.CategoryId
            };


            try
            {
                await repo.AddAsync(fact);
                await repo.SaveChangesAsync();
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("No added fact");
            }

            return model;
        }

        public async Task<IEnumerable<AllFactsViewModel>> AllFacts()
        {

            var facts = await repo.AllReadonly<InterestingFacts>()
               .Include(x=>x.Category)
               .Select(f => new AllFactsViewModel()
               {
                   Id = f.Id,
                   Description = f.Description,
                   Category = f.Category.Name
               }) 
               .ToListAsync();

            return facts;
        }

        [Area("Administrator")]
        public async Task Delete(int Id)
        {
            var deletedFact = await repo.GetByIdAsync<InterestingFacts>(Id);

            try
            {
                repo.Delete<InterestingFacts>(deletedFact);
                await repo.SaveChangesAsync();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Not deleted this fact");
            }
        }


        [Area("Administrator")]
        public async Task<FactOfCountry> EditFact(FactOfCountry model)
        {
            try
            {
                var sanitizer = new HtmlSanitizer();

                string description = sanitizer.Sanitize(model.Description);

                if (string.IsNullOrWhiteSpace(description))
                {
                    throw new NullReferenceException("The model Property is Requared not by Empty");
                }

                var editedFact = await repo.GetByIdAsync<InterestingFacts>(model.Id);
                editedFact.Description = description;
                editedFact.CategoryId = model.CategoryId;


                repo.Update(editedFact);
                await repo.SaveChangesAsync();
            }
            catch (ArgumentException)
            {
                new ArgumentException("Model is not vaid");
            }

            return model;
        }

        public async Task<FactOfCountry> GetFactById(int id)
        {

            return await repo.AllReadonly<InterestingFacts>()
                .Where(x => x.Id == id)
                .Select(z => new FactOfCountry
                {
                    Id = z.Id,
                    Description = z.Description,
                    CategoryId = z.CategoryId,
                })
                .FirstAsync();
        }


        public async Task<IEnumerable<CategoryViewModel>> AllCategory()
        {
            var all = await repo.AllReadonly<Category>()
                .Select(x => new CategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToListAsync();

            return all;
        }
    }
}
