using Ganss.Xss;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyWebProject.Core.Models.AdminHomeModel;
using MyWebProject.Core.Models.CultureEventModel;
using MyWebProject.Core.Models.PictureModel;
using MyWebProject.Core.Models.SearchEngineModel;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;
using System.Collections;

namespace MyWebProject.Core.Services.Services
{
    public class HomeServices : IHomeService
    {
        private readonly IRepository repo;
        private readonly ILogger<HomeServices> logger;


        public HomeServices(IRepository _repo,
            ILogger<HomeServices> _logger)
        {
            repo = _repo;
            logger = _logger;
        }


        public async Task<IEnumerable<AddPictureViewModel>> AllPictureOfUserUpload()
        {
            var allPicture = await repo.AllReadonly<Pictures>()
                .Where(x => x.UserName != null)
                .Select(x => new AddPictureViewModel()
                {
                    Id = x.Id,
                    UrlImgAddres = x.UrlImgAddres,
                    LandMark = x.LandMarkId,
                    Town = x.TownId,
                    Journey = x.JourneyId,
                    PictureData = x.ArrayPicture,
                    LikeCount = x.LikeCount,
                    UserName = x.UserName

                }).ToListAsync();

            return allPicture;
        }



        [Authorize]
        [Area("Administrator")]
        public AdminHomeModelAllData AllData(AdminHomeModelAllData model)
        {
            model.CountOfUsers =  repo.All<Users>().Where(z => z.IsActiv == true).Count();
            model.NotActivUsers =  repo.All<Users>().Where(z => z.IsActiv == false).Count();

            model.CountOfEvents = repo.All<Cultural_events>().Where(z => z.IsActiv == true).Count();
            model.NotActiveEvents = repo.All<Cultural_events>().Where(z => z.IsActiv == false).Count();

            model.CountOfFacts = repo.All<InterestingFacts>().Where(z => z.IsActive == true).Count();
            model.NotActiveFacts = repo.All<InterestingFacts>().Where(z => z.IsActive == false).Count();

            model.CountOfCategory = repo.All<Category>().Where(z => z.IsActive == true).Count();
            model.NotActiveCategory = repo.All<Category>().Where(z => z.IsActive == false).Count();

            model.CountOfJourney = repo.All<Journeys>().Where(z => z.IsActiv == true).Count();
            model.NotActiveJourney = repo.All<Journeys>().Where(z => z.IsActiv == false).Count();

            model.CountOfTown = repo.All<Town>().Where(z => z.IsActive == true).Count();
            model.NotActiveTown = repo.All<Town>().Where(z => z.IsActive == false).Count();

            model.CountOfLandmarks = repo.All<LandMark>().Where(z => z.IsActiv == true).Count();
            model.NotActivLandMark = repo.All<LandMark>().Where(z => z.IsActiv == false).Count();

            model.CountOfPictures = repo.All<Pictures>().Where(z => z.IsActiv == true).Count();
            model.NotActivPictures = repo.All<Pictures>().Where(z => z.IsActiv == false).Count();

            return model;
        }



        public async Task<IEnumerable<Pictures>> AllPicture()
        {
            var result = await repo.All<Pictures>()
               .Where(x => x.TownId == null && x.LandMarkId == null && x.JourneyId == null)
               .Where(z => z.IsActiv == true)
               .ToListAsync();

            return result;
        }


        public async Task<IEnumerable<PicturesViewModel>> AllUserPictures(string userName)
        {
            var result = await repo.All<Pictures>()
              .Where(x => x.UserName == userName && x.IsActiv == true)
              .Select(s => new PicturesViewModel()
              {
                  Id = s.Id,
                  UrlImgAddres = s.UrlImgAddres,
                  PictureData = s.ArrayPicture,
                  LikeCount = s.LikeCount
              })
              .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<AllCultureEventViewModel>> AllUserEvents(string userName)
        {
            var result = await repo.All<Cultural_events>()
              .Where(x => x.AllUsers.Any(c => c.UserName == userName))
              .Select(s => new AllCultureEventViewModel()
              {
                  Id = s.Id,
                  Name = s.Name,
                  Description = s.Description,
                  Date = s.Date,
                  Hour = s.Hour,
                  Town = s.Town.Name,
                  ImageURL = s.ImageURL,
                  Going = s.Going,
                  Maybe = s.Maybe
              })
              .ToListAsync();

            return result;
        }


        public async Task<IEnumerable> ShearchItem(string item)
        {
            List<SearchViewModel> search = new List<SearchViewModel>();

            try
            {
                var sanitizer = new HtmlSanitizer();
                string srcitem = sanitizer.Sanitize(item.ToLower());


                var searchTown = await repo.All<Town>()
                    .Where(x => x.Name.Contains(srcitem) && x.IsActive == true)              
                     .Select(x => new SearchViewModel()
                     {
                         Name = x.Name,
                         Description = x.Description,
                         CategoryName = "Town"
                     })
                    .ToListAsync();

                if (searchTown.Count() != 0)
                {
                    foreach (var town in searchTown)
                    {
                        search.Add(town);
                    }
                }

                var searchLandmark = await repo.AllReadonly<LandMark>()
                    .Where(l => l.Name.Contains(srcitem) || l.Description.Contains(srcitem) && l.IsActiv == true)
                    .Select(x => new SearchViewModel()
                    {
                        Name = x.Name,
                        Description = x.Description,
                        CategoryName = "LandMark",
                    })
                    .ToListAsync();

                if (searchLandmark.Count() != 0)
                {
                    foreach (var land in searchLandmark)
                    {
                        search.Add(land);
                    }
                }

                var searchEvent = await repo.AllReadonly<Cultural_events>()
                    .Where(e => e.Name.Contains(srcitem) || e.Description.Contains(srcitem) && e.IsActiv == true)
                     .Select(x => new SearchViewModel()
                     {
                         Name = x.Name,
                         Description = x.Description,
                         CategoryName = "Event"
                     })
                    .ToListAsync();

                if (searchEvent.Count() != 0)
                {
                    foreach (var events in searchEvent)
                    {
                        search.Add(events);
                    }
                }

                var searchJourney = await repo.AllReadonly<Journeys>()
                    .Where(e => e.Name.Contains(srcitem) || e.Description.Contains(srcitem) && e.IsActiv == true)
                     .Select(x => new SearchViewModel()
                     {
                         Name = x.Name,
                         Description = x.Description,
                         CategoryName = "Journey"
                     })
                    .ToListAsync();

                if (searchJourney.Count() != 0)
                {
                    foreach (var jour in searchJourney)
                    {
                        search.Add(jour);
                    }
                }

            }
            catch (Exception ex)
            {
                logger.LogError(string.Format("Not Found search item"), ex);
            }

            return search;
        }
    }
}
