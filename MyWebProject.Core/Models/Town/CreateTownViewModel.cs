using MyWebProject.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace MyWebProject.Core.Models.Town
{
    public class CreateTownViewModel
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
    }
}
