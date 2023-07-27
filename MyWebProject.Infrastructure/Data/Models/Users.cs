using Microsoft.AspNetCore.Identity;

namespace MyWebProject.Infrastructure.Data.Models
{
    public class Users : IdentityUser
    {
        public string? Avatar { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public bool IsActiv { get; set; } = true;

        public List<LandMark> SightsVisited { get; set; }
            = new List<LandMark>();

        public List<Pictures> UserPictures { get; set; }
            = new List<Pictures>();
    }
}
