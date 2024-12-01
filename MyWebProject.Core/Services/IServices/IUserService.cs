using MyWebProject.Core.Models;

namespace MyWebProject.Core.Services.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserviewModel>> GetAllUsers(UserviewModel model);
    }
}
