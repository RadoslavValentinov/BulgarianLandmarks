using Ganss.Xss;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebProject.Core.Models.JourneyModel;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;
using System;
using System.Text.Encodings.Web;

namespace MyWebProject.Core.Services.Services
{
    public class JourneyService : IJourneyServise
    {
        private readonly IRepository repo;

        public JourneyService(IRepository _repo)
        {
            repo = _repo;
        }


        [Area("Administrator")]
        public async Task<JourneyViewModel> Create(JourneyViewModel model)
        {
            var sanitizer = new HtmlSanitizer();

            string name = sanitizer.Sanitize(model.Name);
            string description = sanitizer.Sanitize(model.Description);
            string date = sanitizer.Sanitize(model.StartDate);
            string image = sanitizer.Sanitize(model.Urladdress);

            try
            {
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(date)
                    || string.IsNullOrWhiteSpace(image))
                {
                    throw new NullReferenceException("The field connot empty");
                }

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
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Journry not added in database");
            }

            return model;
        }

        [Area("Administrator")]
        public async Task Delete(int id)
        {
            try
            {
                var setersss = await repo.AllReadonly<Journeys>()
                    .Where(z => z.Id == id)
                    .Include(x => x.pictures)
                    .ToListAsync();


                await repo.DeleteAsync<Journeys>(setersss[0].Id);
                await repo.SaveChangesAsync();
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException("Journey not deleted");
            }
        }

        [Area("Administrator")]
        public async Task<JourneyViewModel> Edit(JourneyViewModel model)
        {
            var sanitizer = new HtmlSanitizer();

            string name = sanitizer.Sanitize(model.Name);
            string description = sanitizer.Sanitize(model.Description);
            string date = sanitizer.Sanitize(model.StartDate);
            string image = sanitizer.Sanitize(model.Urladdress);

            try
            {
                var current = await repo.GetByIdAsync<Journeys>(model.Id);

                if (model.Urladdress != null)
                {
                    var pict = await repo.AllReadonly<Pictures>().FirstAsync(x => x.JourneyId == model.Id);
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
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Model not added some property is not valid");
            }


            return model;
        }

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
                    pictures = x.pictures.Where(p => p.JourneyId == x.Id)
                   .ToList(),
                })
                .ToListAsync();

            return all;
        }

        public async Task<JourneyGetAllViewModel> GetById(int id)
        {
            return await repo.AllReadonly<Journeys>()
                .Where(x => x.Id == id)
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

        public async Task<JourneyViewModel> GetByIdNewModel(int id)
        {
            var pict = await repo.AllReadonly<Pictures>().FirstAsync(x => x.JourneyId == id);

            return await repo.AllReadonly<Journeys>()
                .Where(x => x.Id == id)
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
