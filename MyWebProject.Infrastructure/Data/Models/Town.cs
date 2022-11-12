using MyWebProject.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace My_Web_Project_LandMarks_.Infrastructure.Data.Models
{
    public class Town
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(5000)]
        public string Description { get; set; } = null!;

       public List<Pictures> Picture { get; set; } 
            = new List<Pictures>();

        public List<LandMark> Landmarks { get; set; }
            =new List<LandMark>();

        public List<Cultural_events> cultural_Events { get; set; }
                =new List<Cultural_events> { };
    }
}
