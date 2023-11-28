using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
