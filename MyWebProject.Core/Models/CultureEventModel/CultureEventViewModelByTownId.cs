﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MyWebProject.Core.Constants;

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

        [Required]
        [MaxLength(300)]
        public string ImageURL { get; set; } = null!;
    }
}
