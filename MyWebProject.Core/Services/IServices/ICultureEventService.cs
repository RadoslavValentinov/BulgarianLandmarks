using MyWebProject.Core.Models.CultureEventModel;

namespace MyWebProject.Core.Services.IServices
{
    public interface ICultureEventService
    {
        Task<CultureEventViewModelByTownId> EventByTownId(int id);

        Task<IEnumerable<AllCultureEventViewModel>> AllEvent();

        Task<CultureEventViewModelByTownId> Create(CultureEventViewModelByTownId model);

        Task<CultureEventViewModelByTownId> Edit(CultureEventViewModelByTownId model);

        Task Delete(int id);
    }
}
