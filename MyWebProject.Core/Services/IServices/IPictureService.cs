using MyWebProject.Core.Models.PictureModel;
using MyWebProject.Infrastructure.Data.Models;

namespace MyWebProject.Core.Services.IServices
{
    public interface IPictureService
    {

        Task<int> UpLikeCount(int id);

        Task<int> AddPicture(AddPictureViewModel model);
        Task<AddPictureByUser> AddPictureByUser(AddPictureByUser model);
        Task<AddPictureByUser> PictureByByteArray(AddPictureByUser model);
        Task<AddPictureViewModel> EditPicture(AddPictureViewModel model);
        Task<IEnumerable<PicturesViewModel>> AllPicture();
        Task<IEnumerable<AddPictureByUser>> AllPictureByUser();
        Task<AddPictureViewModel> GetById(int id);
        Task<PictureByUser> GetByUserId(int id);
        Task Delete(int Id);
        Task DeleteByUser(int Id);
    }
}
