﻿using MyWebProject.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace MyWebProject.Core.Models.JourneyModel
{
    public class JourneyViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: GlobalConstant.JourneyConstant.NameMaxLenght,
            MinimumLength = GlobalConstant.JourneyConstant.NameMinLenght)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(maximumLength: GlobalConstant.JourneyConstant.DescriptionMaxLenght,
            MinimumLength = GlobalConstant.JourneyConstant.DescriptionMinLenght)]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Rating { get; set; }

        [Required]
        public string StartDate { get; set; } = null!;

        public int? Day { get; set; }

        [Required]
        public decimal Price { get; set; }

        [MaxLength(300)]
        public string Urladdress { get; set; } = null!;
    }
}
