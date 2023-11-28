using MyWebProject.Core.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
