using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebProject.Infrastructure.Data.Models
{

    public class InterestingFacts
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(5000)]
        [MinLength(20)]
        public string Description { get; set; } = null!;

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
