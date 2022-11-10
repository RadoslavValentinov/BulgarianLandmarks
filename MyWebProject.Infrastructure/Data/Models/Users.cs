using Microsoft.AspNetCore.Identity;

namespace My_Web_Project_LandMarks_.Infrastructure.Data.Models
{
    public class Users : IdentityUser
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public List<LandMark> SightsVisited { get; set; }
            = new List<LandMark>();
    }
}
