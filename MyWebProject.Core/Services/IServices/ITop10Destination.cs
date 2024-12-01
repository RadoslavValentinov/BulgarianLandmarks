using MyWebProject.Core.Models.LandMarkModel;
using MyWebProject.Core.Models.Top10;

namespace MyWebProject.Core.Services.IServices
{
    public interface ITop10Destination
    {
        Task<IEnumerable<Top10ViewModelLandMark>> Get10TopLandMark();

        Task<IEnumerable<LandMarkViewModelAll>> AllLandMarkByTown();
    }
}
