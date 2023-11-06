using MyWebProject.Core.Constants;
using MyWebProject.Core.Models.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebProject.Core.Models.FactOfBulgaria
{
    /// <summary>
    /// This class validated facts requared propertys and lenght of facts
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
