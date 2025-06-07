using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<UserService> logger;

        public UserService(IRepository _repo,
            ILogger<UserService> _logger)
        {
            repo = _repo;
            logger = _logger;
        }


        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <param name="model">The model containing user data.</param>
        /// <returns>A collection of all users.</returns>
        [Authorize]
        [Area("Administrator")]
        public async Task<IEnumerable<UserviewModel>> GetAllUsers(UserviewModel model)
        {
            var AllUsers = await repo.AllReadonly<Users>()
                .Select(u => new UserviewModel()
                {
                    Avatar = u.Avatar ?? null!,
                    FullName = $"{u.FirstName} {u.LastName}",
                    UserName = u.UserName!,
                    Email = u.Email!,
                    IsActive = u.IsActiv,
                    LastActiveLog = u.LastActive
                })
                .ToListAsync();

            if (AllUsers == null)
            {
                logger.LogError(string.Format("No registered users"), new NullReferenceException());
            }

            return AllUsers ?? null!;
        }


        /// <summary>
        /// Updates the last login time for a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateLastLoginAsync(string userId)
        {
            var user = await repo.GetByIdAsync<Users>(userId);
            try
            {
                user.LastActive = DateTime.UtcNow;
                repo.Update(user);
                await repo.SaveChangesAsync();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException($"User with ID not found.");
            }
        }
    }
}
