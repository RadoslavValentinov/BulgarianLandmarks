using System.ComponentModel.DataAnnotations;

namespace My_Web_Project_LandMarks_.Infrastructure.Data.Models
{
    public class Journeys
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Rating { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public int? Day { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
