using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebProject.Infrastructure.Data.Models
{
    public class Cultural_events
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(2000)]
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
        public string ImageURL { get; set; } = null!;

    }
}
