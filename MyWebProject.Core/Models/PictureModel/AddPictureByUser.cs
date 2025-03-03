
namespace MyWebProject.Core.Models.PictureModel
{
    public class AddPictureByUser
    {
        public int Id { get; set; }

        public string? UrlImgAddres { get; set; }

        public string UserName { get; set; } = null!;

        public bool IsActive { get; set; } = true;
        public int LikeCount { get; set; }

        public byte[]? PictureData { get; set; }

    }
}
