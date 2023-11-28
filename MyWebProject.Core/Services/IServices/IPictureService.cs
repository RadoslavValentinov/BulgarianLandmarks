using MyWebProject.Core.Models.PictureModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebProject.Core.Services.IServices
{
    public interface IPictureService
    {
        Task<int> AddPicture(AddPictureViewModel model);
        Task<AddPictureByUser> AddPictureByUser(AddPictureByUser model);
        Task<AddPictureViewModel> EditPicture(AddPictureViewModel model);
        Task<IEnumerable<PicturesViewModel>> AllPicture();
        Task<IEnumerable<AddPictureByUser>> AllPictureByUser();
        Task<AddPictureViewModel> GetById(int id);
        Task Delete(int Id);
        Task DeleteByUser(int Id);
    }
}
