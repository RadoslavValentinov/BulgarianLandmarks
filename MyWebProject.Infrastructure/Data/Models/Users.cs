using Microsoft.AspNetCore.Identity;
using MyWebProject.Infrastructure.Data.Models;

namespace My_Web_Project_LandMarks_.Infrastructure.Data.Models
{
    public class Users : IdentityUser
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public bool IsActiv { get; set; } = true;

        public List<LandMark> SightsVisited { get; set; }
            = new List<LandMark>();

        public List<Pictures> UserPictures { get; set; }
            = new List<Pictures>();
    }
}
