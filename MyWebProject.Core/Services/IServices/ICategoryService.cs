using MyWebProject.Core.Models.Category;

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
