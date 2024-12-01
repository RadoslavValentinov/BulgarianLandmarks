using System.ComponentModel.DataAnnotations;

namespace MyWebProject.Core.Models.SearchEngineModel
{
    public class SearchViewModel
    {
        [Required]
        public string Name { get; set; } = null!;


        [Required]
        public string Description { get; set; } = null!;

        public string CategoryName { get; set; } = null!;
    }
}
