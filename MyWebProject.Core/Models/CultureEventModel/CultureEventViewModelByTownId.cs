using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MyWebProject.Core.Constants;
using Microsoft.Graph.Models;

namespace MyWebProject.Core.Models.CultureEventModel
{
    public class CultureEventViewModelByTownId
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: GlobalConstant.CultureEventConstant.NameMaxLenght,
            MinimumLength = GlobalConstant.CultureEventConstant.NameMinLenght)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(maximumLength:GlobalConstant.CultureEventConstant.DescriptionMaxLenght,
            MinimumLength = GlobalConstant.CultureEventConstant.DescriptionMinLenght)]
        public string Description { get; set; } = null!;

        [Required]
        public string Date { get; set; } = null!;

        [Required]
        public string Hour { get; set; } = null!;

        [Required]
        public string TownName { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        [Required]
        [MaxLength(300)]
        public string ImageURL { get; set; } = null!;

        public bool Going { get; set; } = false;

        public bool Maybe { get; set; } = false;

        public string? UserEvents { get; set; }
    }
}
