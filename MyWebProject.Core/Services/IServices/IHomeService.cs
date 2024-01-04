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
        public Task<IEnumerable<Pictures>> AllPicture();

        Task<IEnumerable> ShearchItem(string item);
    }
}
