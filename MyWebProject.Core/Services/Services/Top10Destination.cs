﻿using Microsoft.EntityFrameworkCore;
using MyWebProject.Core.Models.LandMarkModel;
using MyWebProject.Core.Models.Top10;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;

namespace MyWebProject.Core.Services.Services
{
    public class Top10Destination : ITop10Destination
    {
        private readonly IRepository repo;

        public Top10Destination(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<LandMarkViewModelAll>> AllLandMarkByTown()
        {
            var results = await repo.AllReadonly<LandMark>()
                .Where(x => x.TownId != null && x.Rating >= 9)
                .Select(l => new LandMarkViewModelAll()
                {
                    Id = l.Id,
                    Name = l.Name,
                    Description = l.Description,
                    Rating = l.Rating,
                    TownName = l.Town!.Name,
                    Pictures = l.Pictures.Where(p => p.LandMarkId == l.Id)
                    .ToList(),
                })
                .OrderBy(x => x.Name)
                .ToListAsync();

            return results;
        }

        public async Task<IEnumerable<Top10ViewModelLandMark>> Get10TopLandMark()
        {
            var results = await repo.AllReadonly<LandMark>()
                .Where(x => x.Rating >= 9.2m && x.Rating <= 10m)
                .Select(d => new Top10ViewModelLandMark
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description,
                    Rating = d.Rating,
                    TownName = d.Town!.Name,
                    Category = d.Category.Name,
                    Pictures = d.Pictures.Where(z => z.LandMarkId == d.Id)
                    .ToList(),
                })
                .OrderByDescending(x => x.Rating)
                .Take(10)
                .ToListAsync();

            return results;
        }
    }
}
