using MyWebProject.Core.Constants;
using MyWebProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebProject.Core.Models.JourneyModel
{
    public class JourneyGetAllViewModel
    {
        public int Id { get; set; }


        [Required]
        [StringLength(maximumLength:GlobalConstant.JourneyConstant.NameMaxLenght,
           MinimumLength = GlobalConstant.JourneyConstant.NameMinLenght)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(maximumLength:GlobalConstant.JourneyConstant.DescriptionMaxLenght,
            MinimumLength =GlobalConstant.JourneyConstant.DescriptionMinLenght)]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Rating { get; set; }

        [Required]
        public string StartDate { get; set; } = null!;

        public int? Day { get; set; }

        [Required]
        public decimal Price { get; set; }

        public List<Pictures> pictures { get; set; }
                = new List<Pictures>();
    }
}
