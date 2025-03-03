using System.ComponentModel.DataAnnotations;

namespace MyWebProject.Infrastructure.Data.Models
{
    public class PictureByUser
    {
        public int Id { get; set; }

        public string? UrlImgAddres { get; set; }

        public string UserName { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        public int LikeCount { get; set; }

        public byte[]? PictureData { get; set; }
    }
}
