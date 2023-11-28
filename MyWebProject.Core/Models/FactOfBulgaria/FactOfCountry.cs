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
    public class FactOfCountry
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: GlobalConstant.TownConstant.townDescriptionMaxLenght,
            MinimumLength = GlobalConstant.TownConstant.townDescriptionMinLenght)]
        public string Description { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Category { get; set; }
           = new List<CategoryViewModel>();
    }
}
