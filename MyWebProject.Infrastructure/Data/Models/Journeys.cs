using MyWebProject.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int? Day { get; set; }

        [Required]
        public decimal Price { get; set; }

        public List<Pictures> pictures { get; set; }
                = new List<Pictures>();

    }
}
