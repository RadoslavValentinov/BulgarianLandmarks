using System.ComponentModel.DataAnnotations;

namespace MyWebProject.Infrastructure.Data.Models
{
    public class PictureByUser
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        [MinLength(20)]
        public string UrlImgAddres { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public bool IsActive { get; set; } = true;
    }
}
