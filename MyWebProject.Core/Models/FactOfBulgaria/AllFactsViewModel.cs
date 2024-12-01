using MyWebProject.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace MyWebProject.Core.Models.FactOfBulgaria
{
    /// <summary>
    /// This class validated Facts requared propertys and lenght of Facts
    /// </summary>
    public class AllFactsViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: GlobalConstant.TownConstant.townDescriptionMaxLenght,
           MinimumLength = GlobalConstant.TownConstant.townDescriptionMinLenght)]
        public string Description { get; set; } = null!;

        [Required]
        public string Category { get; set; } = null!;
    }
}
