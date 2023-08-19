using System.ComponentModel.DataAnnotations;

namespace MyWebProject.Infrastructure.Data.Models
{
    public class Landmark_suggestions
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
        public int CategoryId { get; set; }

        public bool IsActive { get; set; } = true;


        [MaxLength(300)]
        public string? VideoURL { get; set; }

        [MaxLength(300)]
        public string? ImageURL { get; set; }
    }
}
