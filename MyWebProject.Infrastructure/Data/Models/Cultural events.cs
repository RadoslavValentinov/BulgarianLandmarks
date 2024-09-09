using Microsoft.AspNetCore.Mvc.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebProject.Infrastructure.Data.Models
{
    public class Cultural_events
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(10)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(2000)]
        [MinLength(20)]
        public string Description { get; set; } = null!;

        [Required]
        public string Date { get; set; } = null!;

        [Required]
        public string Hour { get; set; } = null!;

        public bool IsActiv { get; set; } = true;

       
        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }
        public Town Town { get; set; } = null!;

        [Required]
        [MaxLength(300)]
        public string ImageURL { get; set; } = null!;


        public List<Users> UserName { get; set; }
            = new List<Users>();

        public bool Going { get; set; } = false;

        public bool Maybe { get; set; } = false;
    }
}
