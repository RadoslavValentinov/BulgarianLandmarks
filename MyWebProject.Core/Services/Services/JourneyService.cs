using Ganss.Xss;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyWebProject.Core.Models.JourneyModel;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;

namespace MyWebProject.Core.Services.Services
{
    public class JourneyService : IJourneyServise
    {
        private readonly IRepository repo;
        private readonly ILogger<JourneyService> logger;

        public JourneyService(IRepository _repo,
            ILogger<JourneyService> _logger)
        {
            repo = _repo;
            logger = _logger;
        }


        /// <summary>
        /// Creates a new journey.
        /// </summary>
        /// <param name="model">The model containing the journey data.</param>
        /// <returns>The created journey model.</returns>
        /// <exception cref="NullReferenceException">Thrown when any required field is null or whitespace.</exception>
        [Area("Administrator")]
        public async Task<JourneyViewModel> Create(JourneyViewModel model)
        {
            var sanitizer = new HtmlSanitizer();

            string name = sanitizer.Sanitize(model.Name);
            string description = sanitizer.Sanitize(model.Description);
            string date = sanitizer.Sanitize(model.StartDate);
            string image = sanitizer.Sanitize(model.Urladdress);

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(date)
            || string.IsNullOrWhiteSpace(image))
            {
                throw new NullReferenceException("The field cannot be empty");
            }

            try
            {
                var journey = new Journeys()
                {
                    Id = model.Id,
                    Name = name,
                    Description = description,
                    Rating = model.Rating,
                    StartDate = date,
                    Day = model.Day,
                    Price = model.Price,
                };

                var pic = new Pictures()
                {
                    UrlImgAddres = image,
                    Journey = journey
                };

                journey.pictures.Add(pic);

                await repo.AddAsync(journey);
                await repo.SaveChangesAsync();
            }
            catch (NullReferenceException ne)
            {
                logger.LogError(string.Format("Journey not added in database"), ne);
                throw new NullReferenceException("The field cannot be empty");
            }

            return model;
        }


        /// <summary>
        /// Deletes a journey by its id.
        /// </summary>
        /// <param name="id">The id of the journey to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the journey is not found.</exception>
        [Area("Administrator")]
        public async Task Delete(int id)
        {
            var setersss = await repo.AllReadonly<Journeys>()
                    .Where(z => z.Id == id)
                    .Include(x => x.pictures)
                    .ToListAsync();

            if (setersss.Count == 0)
            {
                throw new ArgumentOutOfRangeException("Item to delete not found!");
            }

            try
            {
                await repo.DeleteAsync<Journeys>(setersss[0].Id);
                await repo.SaveChangesAsync();
            }
            catch (ArgumentOutOfRangeException ae)
            {
                logger.LogError(string.Format("Journey not deleted"), ae);
            }
        }


        /// <summary>
        /// Edits an existing journey.
        /// </summary>
        /// <param name="model">The model containing the updated journey data.</param>
        /// <returns>The updated journey model.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the journey is not found or the model is not valid.</exception>
        [Area("Administrator")]
        public async Task<JourneyViewModel> Edit(JourneyViewModel model)
        {
            var sanitizer = new HtmlSanitizer();

            string name = sanitizer.Sanitize(model.Name);
            string description = sanitizer.Sanitize(model.Description);
            string date = sanitizer.Sanitize(model.StartDate);
            string image = sanitizer.Sanitize(model.Urladdress);

            var current = await repo.GetByIdAsync<Journeys>(model.Id);

            if (current == null)
            {
                throw new InvalidOperationException("Model not added, some property is not valid");
            }

            try
            {
                if (model.Urladdress != null)
                {
                    var pict = await repo.AllReadonly<Pictures>().FirstAsync(x => x.JourneyId == model.Id && x.IsActiv == true);
                    pict.UrlImgAddres = image;

                    current.Name = name;
                    current.Description = description;
                    current.Rating = model.Rating;
                    current.StartDate = date;
                    current.Day = model.Day;
                    current.Price = model.Price;
                    current.pictures.Add(pict);
                }
                else
                {
                    current.Name = name;
                    current.Description = description;
                    current.Rating = model.Rating;
                    current.StartDate = date;
                    current.Day = model.Day;
                    current.Price = model.Price;
                }

                repo.Update<Journeys>(current);
                await repo.SaveChangesAsync();
            }
            catch (InvalidOperationException ie)
            {
                logger.LogError(string.Format("Model not added, some property is not valid"), ie);
            }

            return model;
        }


        /// <summary>
        /// Retrieves all active journeys.
        /// </summary>
        /// <returns>A collection of active journeys.</returns>
        public async Task<IEnumerable<JourneyGetAllViewModel>> GetAll()
        {
            var all = await repo.AllReadonly<Journeys>()
                .Where(z => z.IsActiv == true)
                .Select(x => new JourneyGetAllViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Rating = x.Rating,
                    StartDate = x.StartDate,
                    Day = x.Day,
                    Price = x.Price,
                    pictures = x.pictures.Where(p => p.JourneyId == x.Id).ToList(),
                })
                .ToListAsync();

            return all;
        }


        /// <summary>
        /// Retrieves a journey by its id.
        /// </summary>
        /// <param name="id">The id of the journey.</param>
        /// <returns>The journey model.</returns>
        public async Task<JourneyGetAllViewModel> GetById(int id)
        {
            return await repo.AllReadonly<Journeys>()
                .Where(x => x.Id == id && x.IsActiv == true)
                .Select(a => new JourneyGetAllViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    Rating = a.Rating,
                    StartDate = a.StartDate,
                    Day = a.Day,
                    Price = a.Price,
                    pictures = a.pictures.Where(a => a.JourneyId == id).ToList(),
                })
                .FirstAsync();
        }


        /// <summary>
        /// Retrieves a journey by its id and returns a new model.
        /// </summary>
        /// <param name="id">The id of the journey.</param>
        /// <returns>The journey model with additional data.</returns>
        public async Task<JourneyViewModel> GetByIdNewModel(int id)
        {
            var pict = await repo.AllReadonly<Pictures>().FirstAsync(x => x.JourneyId == id);

            return await repo.AllReadonly<Journeys>()
                .Where(x => x.Id == id && x.IsActiv == true)
                .Select(a => new JourneyViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    Rating = a.Rating,
                    StartDate = a.StartDate,
                    Day = a.Day,
                    Price = a.Price,
                    Urladdress = pict.UrlImgAddres,
                }).FirstAsync();
        }
    }
}