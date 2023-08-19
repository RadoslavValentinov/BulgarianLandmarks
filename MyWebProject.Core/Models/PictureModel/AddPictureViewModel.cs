using MyWebProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebProject.Core.Constants;

namespace MyWebProject.Core.Models.PictureModel
{
    public class AddPictureViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: GlobalConstant.PictureConstant.pictureUrlImgMaxLenght,
         MinimumLength = GlobalConstant.PictureConstant.pictureUrlImgMinLenght)]
        public string UrlImgAddres { get; set; } = null!;

        public bool IsActiv { get; set; } = true;

        public int? LandMark { get; set; }

        public int? Town { get; set; }

        public int? Journey { get; set; }

        public string? UserName { get; set; }
    }
}
