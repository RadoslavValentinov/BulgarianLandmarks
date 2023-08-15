using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebProject.Infrastructure.Data.Models
{
    public class Pictures
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        [MinLength(20)]
        public string UrlImgAddres { get; set; } = null!;

        public bool IsActiv { get; set; } = true;

        [ForeignKey(nameof(LandMark))]
        public int? LandMarkId { get; set; }
        public LandMark? LandMark { get; set; }

       
        [ForeignKey(nameof(Town))]
        public int? TownId { get; set; }
        public Town? Town { get; set; }


        [ForeignKey(nameof(Journey))]
        public int? JourneyId { get; set; }
        public Journeys? Journey { get; set; }
    }
}
