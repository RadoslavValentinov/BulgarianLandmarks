﻿using Microsoft.EntityFrameworkCore;
using MyWebProject.Core.Models.Top10;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;

namespace MyWebProject.Core.Services.Services
{
    public class MysteryPlace : IMysteryPlace
    {
        private readonly IRepository repo;

        public MysteryPlace(IRepository _repo)
        {
            repo= _repo;
        }

        public async Task<IEnumerable<MisteryModelView>> MysteryPlaces()
        {
     
           var mysterymodel = await repo.AllReadonly<LandMark>()
               .Where(x=>x.TownId == null && x.VideoURL != null)
               .Select(m => new MisteryModelView()
               {
                   Id = m.Id,
                   Name = m.Name,
                   Description = m.Description,
                   Rating = m.Rating,
                   VideoUrl = m.VideoURL ?? null!,
                   Pictures = m.Pictures.Where(p => p.LandMarkId == m.Id).ToList()
               })
               .OrderBy(x=>x.Name)
               .ToListAsync(); 

            return mysterymodel;
        }
    }
}
