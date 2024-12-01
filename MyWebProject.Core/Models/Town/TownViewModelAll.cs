using MyWebProject.Core.Constants;
using MyWebProject.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MyWebProject.Core.Models.Town
{
    public class TownViewModelAll
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: GlobalConstant.TownConstant.townNameMaxLenght,
           MinimumLength = GlobalConstant.TownConstant.townNameMinLenght)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(maximumLength: GlobalConstant.TownConstant.townDescriptionMaxLenght,
         MinimumLength = GlobalConstant.TownConstant.townDescriptionMinLenght)]
        public string Description { get; set; } = null!;

        public List<Pictures> Picture { get; set; }
            = new List<Pictures>();

        public List<LandMark> Landmarks { get; set; }
           = new List<LandMark>();

        public List<Cultural_events> cultural_Events { get; set; }
                = new List<Cultural_events> { };
    }
}
