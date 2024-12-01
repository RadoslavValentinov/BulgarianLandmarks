﻿using MyWebProject.Core.Constants;
using MyWebProject.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MyWebProject.Core.Models.Top10
{
    public class Top10ViewModelLandMark
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: GlobalConstant.LandMarkConstant.NameMaxLenght,
         MinimumLength = GlobalConstant.LandMarkConstant.NameMinLenght)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(maximumLength: GlobalConstant.LandMarkConstant.DescriptionMaxLenght,
        MinimumLength = GlobalConstant.LandMarkConstant.DescriptionMinLenght)]
        public string Description { get; set; } = null!;

        public decimal Rating { get; set; }

        public string? TownName { get; set; }

        public string Category { get; set; } = null!;

        public List<Pictures> Pictures { get; set; }
            = new List<Pictures>();
    }
}
