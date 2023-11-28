using Microsoft.EntityFrameworkCore;
using My_Web_Project_LandMarks_.Infrastructure.Data.Common;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Infrastructure.Data.Models;

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
    }
}
