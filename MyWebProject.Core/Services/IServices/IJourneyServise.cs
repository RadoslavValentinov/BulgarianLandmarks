using MyWebProject.Core.Models.JourneyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebProject.Core.Services.IServices
{
    public interface IJourneyServise
    {
        Task<IEnumerable<JourneyGetAllViewModel>> GetAll();

        Task<JourneyGetAllViewModel> GetById(int id);
        Task<JourneyViewModel> GetByIdNewModel(int id);

        Task<JourneyViewModel> Create(JourneyViewModel model);

        Task<JourneyViewModel> Edit(JourneyViewModel model);

        Task Delete(int id);
    }
}
