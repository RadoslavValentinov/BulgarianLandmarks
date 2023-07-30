using System.ComponentModel.DataAnnotations;

namespace MyWebProject.Infrastructure.Data.Models
{
    public class Town
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(5000)]
        [MinLength(50)]
        public string Description { get; set; } = null!;

        public List<Pictures> Picture { get; set; }
             = new List<Pictures>();

        public List<LandMark> Landmarks { get; set; }
            = new List<LandMark>();

        public List<Cultural_events> cultural_Events { get; set; }
                = new List<Cultural_events> { };

        [MaxLength(200)]
        public string? Location { get; set; }
    }
}
