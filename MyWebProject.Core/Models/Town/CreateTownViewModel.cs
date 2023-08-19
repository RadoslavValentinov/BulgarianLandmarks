using MyWebProject.Core.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
