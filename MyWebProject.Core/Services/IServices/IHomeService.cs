using MyWebProject.Core.Models.CultureEventModel;
using MyWebProject.Core.Models.PictureModel;
using MyWebProject.Core.Models.SearchEngineModel;
using MyWebProject.Infrastructure.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebProject.Core.Services.IServices
{
    public interface IHomeService
    {
        Task<IEnumerable<Pictures>> AllPicture();
        Task<IEnumerable<PicturesViewModel>> AllUserPictures(string username);

        Task<IEnumerable> ShearchItem(string item);

        Task<IEnumerable<AllCultureEventViewModel>> AllUserEvents(string userName);
    }
}
