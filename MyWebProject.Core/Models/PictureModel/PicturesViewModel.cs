using MyWebProject.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace MyWebProject.Core.Models.PictureModel
{
    public class PicturesViewModel
    {

        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: GlobalConstant.PictureConstant.pictureUrlImgMaxLenght,
           MinimumLength = GlobalConstant.PictureConstant.pictureUrlImgMinLenght)]
        public string UrlImgAddres { get; set; } = null!;

        public bool IsActive { get; set; }

        public string? LandMark { get; set; }

        public string? Town { get; set; }

        public string? Journey { get; set; }
        public string? UserName { get; set; }
    }
}
