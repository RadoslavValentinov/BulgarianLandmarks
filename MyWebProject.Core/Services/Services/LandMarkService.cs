﻿using Ganss.Xss;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyWebProject.Core.Models.Category;
using MyWebProject.Core.Models.LandMarkModel;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;

namespace MyWebProject.Core.Services.Services
{
    public class LandMarkService : ILandmarkService
    {
        private readonly IRepository repo;
        private readonly ILogger<LandMarkService> logger;

        public LandMarkService(IRepository _repo,
            ILogger<LandMarkService> _logger)
        {
            repo = _repo;
            logger = _logger;
        }


        [Area("Administrator")]
        public async Task<LandMarkByUserAdded> AddLandMarkOfUsers(LandMarkByUserAdded model)
        {

            var sanitizer = new HtmlSanitizer();

            string name = sanitizer.Sanitize(model.Name);
            string description = sanitizer.Sanitize(model.Description);
            string videoUrl = sanitizer.Sanitize(model.VideoURL ?? null!);
            string image = sanitizer.Sanitize(model.ImageURL ?? null!);

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
            {
                throw new NullReferenceException("Name and Description connot by Null or Empty");
            }

            try
            {

                var land = new Landmark_suggestions()
                {
                    Id = model.Id,
                    Name = name,
                    Description = description,
                    IsActive = true,
                    CategoryId = model.CategoryId,
                    ImageURL = image,
                };

                if (!string.IsNullOrWhiteSpace(videoUrl))
                {
                    land.VideoURL = videoUrl;
                }

                await repo.AddAsync(land);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(string.Format("Model is not valid"), ex);
            }

            return model;
        }


        [Area("Administrator")]
        public async Task<AddLandMarkViewModel> AddLandMark([FromBody] AddLandMarkViewModel model)
        {
            var sanitizer = new HtmlSanitizer();

            string name = sanitizer.Sanitize(model.Name);
            string description = sanitizer.Sanitize(model.Description);
            string videoUrl = sanitizer.Sanitize(model.VideoURL ?? null!);
            string image = sanitizer.Sanitize(model.ImageURL ?? null!);

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
            {
                throw new NullReferenceException("Name and Description connot by Null or Empty");
            }

            var category = repo.GetByIdAsync<Category>(model.CategoryId).Result;

            try
            {
                var land = new LandMark()
                {
                    Id = model.Id,
                    Name = name,
                    Description = description,
                    Rating = 0,
                    Category = category,
                };

                if (!string.IsNullOrWhiteSpace(videoUrl))
                {
                    land.VideoURL = videoUrl;
                }

                if (!string.IsNullOrWhiteSpace(image))
                {
                    var picture = new Pictures()
                    {
                        UrlImgAddres = image,
                        LandMark = land
                    };

                    land.Pictures.Add(picture);
                }

                await repo.AddAsync(land);
                await repo.SaveChangesAsync();

            }
            catch (DbUpdateException de)
            {
                logger.LogError(string.Format("Database not save info try again..."), de);
            }

            return model;
        }

        public async Task<IEnumerable<CategoryViewModel>> AllCategory()
        {
            var all = await repo.AllReadonly<Category>()
           .Where(z => z.IsActive == true)
           .Select(x => new CategoryViewModel()
           {
               Id = x.Id,
               Name = x.Name,
           })
           .ToListAsync();

            return all;
        }

        [Area("Administrator")]
        public async Task Delete(int id)
        {
            var deletedItem = await repo.AllReadonly<LandMark>()
                    .Where(z => z.Id == id)
                    .Include(x => x.Pictures)
                    .ToListAsync();

            if (deletedItem.Count == 0)
            {
                throw new ArgumentOutOfRangeException("Journey not deleted ,item not found");
            }

            try
            {

                await repo.DeleteAsync<LandMark>(deletedItem[0].Id);
                await repo.SaveChangesAsync();
            }
            catch (ArgumentOutOfRangeException ae)
            {
                logger.LogError(string.Format("Journey not deleted"), ae);
            }
        }

        [Area("Administrator")]
        public async Task<LandMarkViewModelAll> Edit(LandMarkViewModelAll model)
        {
            var sanitizer = new HtmlSanitizer();

            string name = sanitizer.Sanitize(model.Name);
            string description = sanitizer.Sanitize(model.Description);

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
            {
                throw new NullReferenceException("Name and Description connot by Null or Empty");
            }

            var landUpdated = await repo.GetByIdAsync<LandMark>(model.Id);

            if (landUpdated == null)
            {
                throw new NullReferenceException("Model is not vaid");
            }


            try
            {
                landUpdated!.Name = name;
                landUpdated.Description = description;
                landUpdated.Rating = model.Rating;

                repo.Update(landUpdated);
                await repo.SaveChangesAsync();
            }
            catch (NullReferenceException ne)
            {
                logger.LogError(string.Format("Model is not vaid"), ne);
            }

            return model;
        }

        public async Task<bool> ExistById(int id)
        {
            var results = await repo.GetByIdAsync<LandMark>(id);
            if (results != null)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<LandMarkViewModelAll>> GetAllLandmark()
        {
            var result = await repo.All<LandMark>()
                .Include(x => x.Pictures)
                .Include(x => x.Town)
                .Where(x => x.IsActiv == true)
                .Select(l => new LandMarkViewModelAll()
                {
                    Id = l.Id,
                    Name = l.Name,
                    Description = l.Description,
                    Rating = l.Rating,
                    TownName = l.Town!.Name,
                    IsActiv = l.IsActiv,
                    VideoUrl = l.VideoURL,
                    Category = l.Category.Name.ToString(),
                    Pictures = l.Pictures.Where(z => z.LandMarkId == l.Id).ToList(),
                })
                .OrderBy(a => a.Id)
                .ToListAsync();

            return result;
        }

        public async Task<LandMarkViewModelAll> GetById(int id)
        {
            return await repo.AllReadonly<LandMark>()
                .Where(l => l.Id == id && l.IsActiv == true)
                .Select(x => new LandMarkViewModelAll()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Rating = x.Rating,
                    TownName = x.Town!.Name,
                    VideoUrl = x.VideoURL,
                    Pictures = x.Pictures.Where(p => p.LandMarkId == x.Id).ToList()
                }).FirstAsync();
        }

        [Authorize]
        public async Task<IEnumerable<LandMarkByUserAdded>> GetAllByUser()
        {
            var result = await repo.All<Landmark_suggestions>()
                .Where(l => l.IsActive == true)
                .Select(l => new LandMarkByUserAdded()
                {
                    Id = l.Id,
                    Name = l.Name,
                    Description = l.Description,
                    IsActive = l.IsActive,
                    VideoURL = l.VideoURL,
                    CategoryId = l.CategoryId,
                    ImageURL = l.ImageURL,
                })
                .ToListAsync();

            return result;
        }

    }
}
