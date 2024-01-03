using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebProject.Core.Models.SearchEngineModel
{
    public class SearchViewModel
    {
        [Required]
        public string Name { get; set; } = null!;


        [Required]
        public string Description { get; set; } = null!;
    }
}
