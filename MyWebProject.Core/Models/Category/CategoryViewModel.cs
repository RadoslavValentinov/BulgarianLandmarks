using MyWebProject.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace MyWebProject.Core.Models.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: GlobalConstant.CategoryConstant.CategoryMaxLenght,
            MinimumLength = GlobalConstant.CategoryConstant.CategoryMinLenght)]
        public string Name { get; set; } = null!;
    }
}
