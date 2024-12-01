using MyWebProject.Core.Models.Top10;

namespace MyWebProject.Core.Services.IServices
{
    public interface IMysteryPlace
    {
        Task<IEnumerable<MisteryModelView>> MysteryPlaces();
    }
}
