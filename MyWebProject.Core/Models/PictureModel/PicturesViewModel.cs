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
    }
}
