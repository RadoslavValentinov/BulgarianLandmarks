using Ganss.Xss;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyWebProject.Core.Models.Town;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;

namespace MyWebProject.Core.Services.Services
{
    public class TownService : ITownService
    {
        private readonly IRepository repo;
        private readonly ILogger<TownService> logger;

        public TownService(IRepository _repo,
            ILogger<TownService> _logger)
        {
            repo = _repo;
            logger = _logger;
        }


        /// <summary>
        /// Retrieves a town by its id.
        /// </summary>
        /// <param name="id">The id of the town.</param>
        /// <returns>The town model.</returns>
        public async Task<TownViewModelGetTown> TownsById(int id)
        {
            return await repo.AllReadonly<Town>()
                .Where(i => i.Id == id && i.IsActive == true)
                .Select(x => new TownViewModelGetTown
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Landmarks = x.Landmarks.Where(q => q.TownId == x.Id).ToList(),
                    cultural_Events = x.cultural_Events.Where(a => a.Town.Id == x.Id).ToList(),
                    Picture = x.Picture.Where(p => p.TownId == x.Id && x.cultural_Events.Any(x => x.TownId == p.TownId)).ToList()
                })
                .FirstAsync();
        }


        /// <summary>
        /// Retrieves all active towns.
        /// </summary>
        /// <returns>A collection of active towns.</returns>
        public async Task<IEnumerable<TownViewModelAll>> AllTowns()
        {
            return await repo.AllReadonly<Town>()
                .Where(z => z.IsActive == true)
                .Include(p => p.Picture)
                .Include(x => x.Landmarks)
                .Include(p => p.cultural_Events)
                .Select(t => new TownViewModelAll()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    Picture = t.Picture.Where(x => x.TownId == t.Id && x.LandMarkId == null && x.JourneyId == null).ToList(),
                    Landmarks = t.Landmarks.Where(l => l.TownId == t.Id).ToList(),
                    cultural_Events = t.cultural_Events.Where(c => c.TownId == t.Id).ToList()
                })
                .ToListAsync();
        }


        /// <summary>
        /// Creates a new town.
        /// </summary>
        /// <param name="model">The model containing the town data.</param>
        /// <returns>The created town model.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the name or description is null or whitespace.</exception>
        [Area("Administrator")]
        public async Task<CreateTownViewModel> CreateTown(CreateTownViewModel model)
        {
            var sanitizer = new HtmlSanitizer();

            string name = sanitizer.Sanitize(model.Name);
            string description = sanitizer.Sanitize(model.Description);

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentNullException("Field is required and cannot be empty");
            }

            try
            {
                var newTown = new Town()
                {
                    Id = model.Id,
                    Name = name,
                    Description = description
                };

                await repo.AddAsync(newTown);
                await repo.SaveChangesAsync();
            }
            catch (DbUpdateException de)
            {
                logger.LogError(string.Format("Model is not valid"), de);
            }

            return model;
        }


        /// <summary>
        /// Deletes a town by its id.
        /// </summary>
        /// <param name="id">The id of the town to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the town is not found.</exception>
        [Area("Administrator")]
        public async Task Delete(int id)
        {
            var currenttown = await repo.AllReadonly<Town>()
              .Where(x => x.Id == id)
              .Include(p => p.Picture)
              .Include(l => l.Landmarks)
              .Include(c => c.cultural_Events)
              .ToListAsync();

            if (currenttown.Count == 0)
            {
                throw new ArgumentOutOfRangeException("Id is not found");
            }

            try
            {
                await repo.DeleteAsync<Town>(currenttown[0].Id);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(string.Format("Not deleted this town"), ex);
            }
        }


        /// <summary>
        /// Retrieves a town by its name.
        /// </summary>
        /// <param name="name">The name of the town.</param>
        /// <returns>The town model.</returns>
        public async Task<TownViewModelGetTown> TownsByName(string name)
        {
            var sanitizer = new HtmlSanitizer();

            string nameTown = sanitizer.Sanitize(name);

            return await repo.AllReadonly<Town>()
                .Where(i => i.Name == nameTown && i.IsActive == true)
                .Select(x => new TownViewModelGetTown
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Landmarks = x.Landmarks.Where(q => q.TownId == x.Id).ToList(),
                    cultural_Events = x.cultural_Events.Where(a => a.Town.Id == x.Id).ToList(),
                    Picture = x.Picture.Where(p => p.TownId == x.Id && x.cultural_Events.Any(x => x.TownId == p.TownId)).ToList(),
                })
                .FirstAsync();
        }


        /// <summary>
        /// Edits an existing town.
        /// </summary>
        /// <param name="model">The model containing the updated town data.</param>
        /// <returns>The updated town model.</returns>
        /// <exception cref="NullReferenceException">Thrown when the town is not found.</exception>
        [Area("Administrator")]
        public async Task<TownViewModelGetTown> Edit(TownViewModelGetTown model)
        {
            var sanitizer = new HtmlSanitizer();

            string name = sanitizer.Sanitize(model.Name);
            string description = sanitizer.Sanitize(model.Description);

            var editTown = await repo.GetByIdAsync<Town>(model.Id);

            if (editTown == null)
            {
                throw new NullReferenceException("The pattern cannot be null");
            }

            try
            {
                editTown.Name = name;
                editTown.Description = description;

                repo.Update(editTown);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(string.Format("Not save changes to town"), ex);
            }

            return model;
        }
    }
}