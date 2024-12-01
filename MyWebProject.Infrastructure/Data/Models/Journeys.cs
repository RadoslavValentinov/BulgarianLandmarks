﻿using System.ComponentModel.DataAnnotations;

namespace MyWebProject.Infrastructure.Data.Models
{
    public class Journeys
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(10)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(2000)]
        [MinLength(20)]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Rating { get; set; }

        [Required]
        public string StartDate { get; set; } = null!;

        public int? Day { get; set; }

        [Required]
        public decimal Price { get; set; }

        public bool IsActiv { get; set; } = true;

        public List<Pictures> pictures { get; set; }
                = new List<Pictures>();

    }
}
