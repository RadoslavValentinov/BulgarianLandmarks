﻿using Ganss.Xss;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyWebProject.Core.Models.Category;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;

namespace MyWebProject.Core.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository repo;
        private readonly ILogger<CategoryService> logger;

        public CategoryService(IRepository _repo,
            ILogger<CategoryService> _logger)
        {
            repo = _repo;
            logger = _logger;
        }

        public async Task<IEnumerable<CategoryViewModel>> AllCategory()
        {
            var all = await repo.AllReadonly<Category>()
               .Where(z => z.IsActive == true)
               .Select(x => new CategoryViewModel()
               {
                   Id = x.Id,
                   Name = x.Name
               })
               .ToListAsync();

            return all;
        }

        [Area("Administrator")]
        public async Task<CreateCategoryViewModel> CreateCategory(CreateCategoryViewModel model)
        {
            var sanitizer = new HtmlSanitizer();

            string NameOfCategory = sanitizer.Sanitize(model.Name);

            if (string.IsNullOrWhiteSpace(NameOfCategory))
            {
                throw new NullReferenceException("Name conot null and whritespace");
            }

            var newCategory = new Category()
            {
                Name = NameOfCategory,
            };

            try
            {
                await repo.AddAsync(newCategory);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(string.Format("Place try again later"), ex);
            }

            return model;
        }

        [Area("Administrator")]
        public async Task Delete(int id)
        {

            var catDeleted = await repo.GetByIdAsync<Category>(id);

            if (catDeleted == null)
            {
                throw new NullReferenceException("Тhe category you want to delete was not found!");
            }

            try
            {
                repo.Delete(catDeleted);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(string.Format("Тhe category Not deleted"), ex);
            }
        }

        [Area("Administrator")]
        public async Task<CategoryViewModel> EditCategory(CategoryViewModel model)
        {
            var sanitizer = new HtmlSanitizer();

            string nameCategory = sanitizer.Sanitize(model.Name);

            try
            {
                var currentCategory = await repo.GetByIdAsync<Category>(model.Id);
                if (string.IsNullOrWhiteSpace(nameCategory))
                {
                    throw new NullReferenceException("Name conot null and whritespace");
                }

                currentCategory.Name = nameCategory;

                repo.Update(currentCategory);
                await repo.SaveChangesAsync();
            }
            catch (ArgumentException ex)
            {
                logger.LogError(string.Format("Place try again later"), ex);
            }

            return model;
        }

        public async Task<CategoryViewModel> GetById(int id)
        {
            return await repo.AllReadonly<Category>()
                .Where(x => x.Id == id)
                .Select(s => new CategoryViewModel
                {
                    Id = s.Id,
                    Name = s.Name
                }).FirstAsync();
        }
    }
}
