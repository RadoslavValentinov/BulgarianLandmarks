using My_Web_Project_LandMarks_.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebProject.Infrastructure.Data.Models
{
    public class Pictures
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(300)]
        public string UrlImgAddres { get; set; } = null!;

        
        [ForeignKey(nameof(LandMark))]
        public int? LandMarkId { get; set; }
        public LandMark? LandMark { get; set; }

       
        [ForeignKey(nameof(Town))]
        public int? TownId { get; set; }
        public Town? Town { get; set; }


    }
}
