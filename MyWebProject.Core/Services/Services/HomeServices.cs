﻿using Ganss.Xss;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

        public async Task<IEnumerable<Pictures>> AllPicture()
        {
            var result = await repo.All<Pictures>()
               .Where(x => x.TownId == null && x.LandMarkId == null && x.JourneyId == null)
               .ToListAsync();

            return result;
        }


        public async Task<IEnumerable<PicturesViewModel>> AllUserPicctures(string userName)
        {
            var result = await repo.All<Pictures>()
              .Where(x => x.UserName == userName)
              .Select(s => new PicturesViewModel()
              {
                  Id = s.Id,
                  UrlImgAddres = s.UrlImgAddres
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
                    .Where(x => x.Name.Contains(srcitem))
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
                    .Where(l => l.Name.Contains(srcitem) || l.Description.Contains(srcitem))
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
                    .Where(e => e.Name.Contains(srcitem) || e.Description.Contains(srcitem))
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
                    .Where(e => e.Name.Contains(srcitem) || e.Description.Contains(srcitem))
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
