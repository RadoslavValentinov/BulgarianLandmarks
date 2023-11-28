using MyWebProject.Core.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebProject.Core.Services.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> AllCategory();

        Task<CategoryViewModel> GetById(int id);

        Task Delete(int id);

        Task<CategoryViewModel> EditCategory(CategoryViewModel model);

        Task<CreateCategoryViewModel> CreateCategory(CreateCategoryViewModel model);
    }
}
