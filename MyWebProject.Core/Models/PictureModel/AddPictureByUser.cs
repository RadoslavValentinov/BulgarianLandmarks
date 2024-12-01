using MyWebProject.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace MyWebProject.Core.Models.PictureModel
{
    public class AddPictureByUser
    {
        public int Id { get; set; }


        [Required]
        [StringLength(maximumLength: GlobalConstant.PictureConstant.pictureUrlImgMaxLenght,
        MinimumLength = GlobalConstant.PictureConstant.pictureUrlImgMinLenght)]
        public string UrlImgAddres { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public bool IsActive { get; set; } = true;

    }
}
