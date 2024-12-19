using System.ComponentModel.DataAnnotations;

namespace MyWebProject.Infrastructure.Data.Models
{
    public class Category
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string Name { get; set; } = null!;


        public bool IsActive { get; set; } = true;
    }
}
