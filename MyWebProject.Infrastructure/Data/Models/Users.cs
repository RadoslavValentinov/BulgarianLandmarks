using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyWebProject.Infrastructure.Data.Models
{
    public class Users : IdentityUser
    {
        public string? Avatar { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string LastName { get; set; } = null!;

        public bool IsActiv { get; set; } = true;


        public DateTime LastActive { get; set; }


        public List<LandMark> SightsVisited { get; set; }
            = new List<LandMark>();

        public List<Pictures> UserPictures { get; set; }
            = new List<Pictures>();

        public List<Cultural_events> CulturalEvents { get; set; }
            = new List<Cultural_events>();


        public byte[]? PictureOfFile { get; set; }

    }
}
