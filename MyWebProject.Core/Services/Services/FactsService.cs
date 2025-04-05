using Ganss.Xss;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyWebProject.Core.Models.Category;
using MyWebProject.Core.Models.FactOfBulgaria;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;

namespace MyWebProject.Core.Services.Services
{
    public class FactsService : IFactsService
    {
        private readonly IRepository repo;
        private readonly ILogger<FactsService> logger;

        public FactsService(IRepository _repo,
            ILogger<FactsService> _logger)
        {
            repo = _repo;
            logger = _logger;
        }


        /// <summary>
        /// Adds a new fact to the database.
        /// </summary>
        /// <param name="model">The model containing the fact data.</param>
        /// <returns>The added fact model.</returns>
        /// <exception cref="NullReferenceException">Thrown when the category does not exist or the description is null or whitespace.</exception>
        [Area("Administrator")]
        public async Task<FactOfCountry> AddFacts(FactOfCountry model)
        {
            var exist = await repo.AllReadonly<Category>()
                .FirstOrDefaultAsync(c => c.Id == model.CategoryId);

            var sanitizer = new HtmlSanitizer();

            string description = sanitizer.Sanitize(model.Description);

            if (exist == null || string.IsNullOrWhiteSpace(description))
            {
                throw new NullReferenceException("The model Property is required and cannot be empty");
            }

            var fact = new InterestingFacts()
            {
                Id = model.Id,
                Description = description,
                CategoryId = model.CategoryId
            };

            try
            {
                await repo.AddAsync(fact);
                await repo.SaveChangesAsync();
            }
            catch (ArgumentException ae)
            {
                logger.LogError(string.Format("Fact not added"), ae);
            }

            return model;
        }


        /// <summary>
        /// Retrieves all active facts.
        /// </summary>
        /// <returns>A collection of active facts.</returns>
        public async Task<IEnumerable<AllFactsViewModel>> AllFacts()
        {
            var facts = await repo.AllReadonly<InterestingFacts>()
               .Include(x => x.Category)
               .Where(z => z.IsActive == true)
               .Select(f => new AllFactsViewModel()
               {
                   Id = f.Id,
                   Description = f.Description,
                   Category = f.Category.Name
               })
               .ToListAsync();

            return facts;
        }


        /// <summary>
        /// Deletes a fact by its id.
        /// </summary>
        /// <param name="Id">The id of the fact to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the fact is not found.</exception>
        [Area("Administrator")]
        public async Task Delete(int Id)
        {
            var deletedFact = await repo.GetByIdAsync<InterestingFacts>(Id);

            try
            {
                repo.Delete<InterestingFacts>(deletedFact);
                await repo.SaveChangesAsync();
            }
            catch (ArgumentNullException an)
            {
                logger.LogError(string.Format("Fact not deleted, please try again later"), an);
            }
        }


        /// <summary>
        /// Edits an existing fact.
        /// </summary>
        /// <param name="model">The model containing the updated fact data.</param>
        /// <returns>The updated fact model.</returns>
        /// <exception cref="NullReferenceException">Thrown when the description is null or whitespace.</exception>
        [Area("Administrator")]
        public async Task<FactOfCountry> EditFact(FactOfCountry model)
        {
            try
            {
                var sanitizer = new HtmlSanitizer();

                string description = sanitizer.Sanitize(model.Description);

                if (string.IsNullOrWhiteSpace(description))
                {
                    throw new NullReferenceException("The model Property is required and cannot be empty");
                }

                var editedFact = await repo.GetByIdAsync<InterestingFacts>(model.Id);
                editedFact.Description = description;
                editedFact.CategoryId = model.CategoryId;

                repo.Update(editedFact);
                await repo.SaveChangesAsync();
            }
            catch (ArgumentException ae)
            {
                logger.LogError(string.Format("Model is not valid"), ae);
            }

            return model;
        }


        /// <summary>
        /// Retrieves a fact by its id.
        /// </summary>
        /// <param name="id">The id of the fact.</param>
        /// <returns>The fact model.</returns>
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


        /// <summary>
        /// Retrieves all active categories.
        /// </summary>
        /// <returns>A collection of active categories.</returns>
        public async Task<IEnumerable<CategoryViewModel>> AllCategory()
        {
            var all = await repo.AllReadonly<Category>()
                .Where(z => z.IsActive == true)
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