using Ganss.Xss;
using Microsoft.EntityFrameworkCore;
using MyWebProject.Core.Models.SearchEngineModel;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;
using System.Collections;

namespace MyWebProject.Core.Services.Services
{
    public class HomeServices : IHomeService
    {
        public readonly IRepository repo;

        public HomeServices(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<Pictures>> AllPicture()
        {
            var result = await repo.All<Pictures>()
               .Where(x => x.TownId == null && x.LandMarkId == null && x.JourneyId == null)
               .ToListAsync();

            return result;
        }

        public async Task<IEnumerable> ShearchItem(string item)
        {
            var sanitizer = new HtmlSanitizer();
            string srcitem = sanitizer.Sanitize(item.ToLower());

            var searchTown = await repo.AllReadonly<Town>()
                .Where(x=> x.Name.ToLower() == srcitem || x.Description.Contains(srcitem))
                 .Select(x => new SearchViewModel()
                 {
                     Name = x.Name,
                     Description = x.Description
                 })
                .ToListAsync();

            if (searchTown != null)
            {
                return searchTown;
            }

            var searchLandmark = await repo.AllReadonly<LandMark>()
                .Where(l => l.Name.ToLower() == srcitem || l.Description.Contains(srcitem))
                .Select(x=> new SearchViewModel()
                {
                    Name = x.Name,
                    Description = x.Description
                })
                .ToListAsync();

            if (searchLandmark != null)
            {
                return searchLandmark;
            }

            var searchEvent = await repo.AllReadonly<Cultural_events>()
                .Where(e=> e.Name.ToLower() == srcitem || e.Description.Contains(srcitem))
                 .Select(x => new SearchViewModel()
                 {
                     Name = x.Name,
                     Description = x.Description
                 })
                .ToListAsync();

            if (searchEvent != null)
            {
                return searchEvent;
            }

            return "";
        }
    }
}
