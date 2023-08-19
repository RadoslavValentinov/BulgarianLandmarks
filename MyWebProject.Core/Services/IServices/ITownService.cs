using MyWebProject.Core.Models.Town;

namespace MyWebProject.Core.Services.IServices
{
    public interface ITownService
    {
        Task<IEnumerable<TownViewModelAll>> AllTowns();

        Task<TownViewModelGetTown> TownsById(int id);

        Task<TownViewModelGetTown> TownsByName(string name);

        Task <CreateTownViewModel> CreateTown(CreateTownViewModel model);
        Task <TownViewModelGetTown> Edit(TownViewModelGetTown model);

        Task Delete(int id);
    }
}
