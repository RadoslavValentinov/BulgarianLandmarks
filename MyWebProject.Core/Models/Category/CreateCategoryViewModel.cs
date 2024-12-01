using MyWebProject.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace MyWebProject.Core.Models.Category
{
    public class CreateCategoryViewModel
    {
        [Required]
        [StringLength(maximumLength: GlobalConstant.CategoryConstant.CategoryMaxLenght,
            MinimumLength = GlobalConstant.CategoryConstant.CategoryMinLenght)]
        public string Name { get; set; } = null!;
    }
}
