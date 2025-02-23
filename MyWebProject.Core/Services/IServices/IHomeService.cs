using MyWebProject.Core.Models.AdminHomeModel;
using MyWebProject.Core.Models.CultureEventModel;
using MyWebProject.Core.Models.PictureModel;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;
using System.Collections;

namespace MyWebProject.Core.Services.IServices
{
    public interface IHomeService
    {
        Task<IEnumerable<Pictures>> AllPicture();
        Task<IEnumerable<PicturesViewModel>> AllUserPictures(string username);

        Task<IEnumerable> ShearchItem(string item);

        Task<IEnumerable<AllCultureEventViewModel>> AllUserEvents(string userName);
        AdminHomeModelAllData AllData(AdminHomeModelAllData model);

        Task<IEnumerable<AddPictureViewModel>> AllPictureOfUserUpload();
    }
}
