using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebProject.Core.Models;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;

namespace MyWebProject.Core.Services.Services
{
    [Authorize]
    [Area("Administrator")]
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository _repo)
        {
            repo = _repo;
        }


        [Authorize]
        [Area("Administrator")]
        public async Task<IEnumerable<UserviewModel>> GetAllUsers(UserviewModel model)
        {
            var AllUsers = await repo.AllReadonly<Users>()
                .Select(u => new UserviewModel()
                {
                    Avatar = u.Avatar ?? null!,
                    FullName = $"{u.FirstName} {u.LastName}",
                    UserName = u.UserName,
                    Email = u.Email,
                    IsActive = u.IsActiv
                })
                .ToListAsync();

            if (AllUsers == null)
            {
                throw new ArgumentException("No register users");
            }

            return AllUsers;
        }
    }
}
