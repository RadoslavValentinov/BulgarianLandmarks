using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebProject.Infrastructure.Data.Models
{

    public class LandMark
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(5000)]
        [MinLength(20)]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Rating { get; set; }


        [ForeignKey(nameof(Town))]
        public int? TownId { get; set; }
        public Town? Town { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public bool IsActiv { get; set; } = true;

        [MaxLength(300)]
        public string? VideoURL { get; set; }

        public List<Pictures> Pictures { get; set; }
            = new List<Pictures>();
    }
}