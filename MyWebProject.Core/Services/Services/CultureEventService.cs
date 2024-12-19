using Ganss.Xss;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyWebProject.Core.Models.CultureEventModel;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;


namespace MyWebProject.Core.Services.Services
{

    public class CultureEventService : ICultureEventService
    {
        private readonly IRepository repo;
        private readonly ILogger<CultureEventService> logger;
        private readonly UserManager<Users>? user;

        public CultureEventService(IRepository _repo,
            ILogger<CultureEventService> _logger)
        {
            repo = _repo;
            logger = _logger;
        }



        public async Task<IEnumerable<AllCultureEventViewModel>> AllEvent()
        {
            var all = await repo.AllReadonly<Cultural_events>()
                .Where(z => z.IsActiv == true)
                .Select(c => new AllCultureEventViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Date = c.Date,
                    Hour = c.Hour,
                    Town = c.Town.Name,
                    ImageURL = c.ImageURL,
                })
                .ToListAsync();

            return all;
        }

        [Area("Administrator")]
        public async Task<CultureEventViewModelByTownId> Create(CultureEventViewModelByTownId model)
        {
            var sanitizer = new HtmlSanitizer();

            string NameEvent = sanitizer.Sanitize(model.Name);
            string DescriptionEvent = sanitizer.Sanitize(model.Description);
            string DateEvent = sanitizer.Sanitize(model.Date);
            string HourEvent = sanitizer.Sanitize(model.Hour);
            string image = sanitizer.Sanitize(model.ImageURL);


            var currenttown = repo.AllReadonly<Town>()
                  .Where(x => x.Name == model.TownName).ToList();


            if (currenttown.Count == 0)
            {
                throw new ArgumentException("Town connot by null");
            }



            try
            {

                var newEvent = new Cultural_events()
                {
                    Name = NameEvent,
                    Description = DescriptionEvent,
                    Date = DateEvent,
                    Hour = HourEvent,
                    TownId = currenttown[0].Id,
                    ImageURL = image
                };

                await repo.AddAsync(newEvent);
                await repo.SaveChangesAsync();

            }
            catch (ArgumentException ar)
            {
                logger.LogError(string.Format("Model not added succssesfuly"), ar);
            }

            return model;
        }

        [Area("Administrator")]
        public async Task Delete(int id)
        {
            var currentEvent = await repo.GetByIdAsync<Cultural_events>(id);

            if (currentEvent == null)
            {
                throw new NullReferenceException("Deleted Event Not Found");
            }

            repo.Delete(currentEvent);
            await repo.SaveChangesAsync();
        }

        [Area("Administrator")]
        public async Task<CultureEventViewModelByTownId> Edit(CultureEventViewModelByTownId model)
        {
            var sanitizer = new HtmlSanitizer();

            string NameEvent = sanitizer.Sanitize(model.Name);
            string DescriptionEvent = sanitizer.Sanitize(model.Description);
            string DateEvent = sanitizer.Sanitize(model.Date);
            string HourEvent = sanitizer.Sanitize(model.Hour);
            string image = sanitizer.Sanitize(model.ImageURL);

            try
            {
                var currenttown = repo.AllReadonly<Town>()
                   .Where(x => x.Name == model.TownName).ToList();

                if (currenttown.Count() == 0)
                {
                    throw new NullReferenceException("Town Not Found!");
                }

                if (string.IsNullOrWhiteSpace(model.Name) || string.IsNullOrWhiteSpace(model.Description) ||
                    string.IsNullOrWhiteSpace(model.Date) || string.IsNullOrWhiteSpace(model.Hour) || string.IsNullOrWhiteSpace(model.ImageURL))
                {
                    throw new NullReferenceException("The model is not valid");
                }

                var currentEvent = await repo.GetByIdAsync<Cultural_events>(model.Id);
                currentEvent.Name = NameEvent;
                currentEvent.Description = DescriptionEvent;
                currentEvent.Date = DateEvent;
                currentEvent.Hour = HourEvent;
                currentEvent.Town = currenttown[0];
                currentEvent.ImageURL = image;


                repo.Update(currentEvent);
                await repo.SaveChangesAsync();

            }
            catch (ArgumentNullException an)
            {
                logger.LogError(string.Format("Not changed sevad"), an);
            }

            return model;
        }

        public async Task<CultureEventViewModelByTownId> EventByTownId(int id)
        {


            try
            {
                var allEvent = await repo.AllReadonly<Cultural_events>()
                .Where(x => x.Id == id)
                .Select(a => new CultureEventViewModelByTownId()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    Date = a.Date,
                    Hour = a.Hour,
                    TownName = a.Town.Name,
                    ImageURL = a.ImageURL
                }).FirstAsync();

                return allEvent;
            }
            catch (Exception)
            {
                throw new ArgumentNullException("Not Fount Events");
            }
        }
    }
}