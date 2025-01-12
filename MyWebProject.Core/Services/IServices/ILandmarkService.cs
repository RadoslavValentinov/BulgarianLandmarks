using MyWebProject.Core.Models.Category;
using MyWebProject.Core.Models.LandMarkModel;

namespace MyWebProject.Core.Services.IServices
{
    public interface ILandmarkService
    {
        Task<IEnumerable<LandMarkViewModelAll>> GetAllLandmark();
        Task<IEnumerable<LandMarkByUserAdded>> GetAllByUser();

        Task<LandMarkViewModelAll> GetById(int id);

        Task<bool> ExistById(int id);

        Task<AddLandMarkViewModel> AddLandMark(AddLandMarkViewModel model);

        Task<LandMarkByUserAdded> AddLandMarkOfUsers(LandMarkByUserAdded model);

        Task<LandMarkViewModelAll> Edit(LandMarkViewModelAll model);

        Task<IEnumerable<CategoryViewModel>> AllCategory();

        Task Delete(int id);

        Task<bool> UpRattingPoint(int id);

    }
}
