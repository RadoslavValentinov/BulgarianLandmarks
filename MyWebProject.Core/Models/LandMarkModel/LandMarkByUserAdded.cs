using MyWebProject.Core.Constants;
using MyWebProject.Core.Models.Category;
using System.ComponentModel.DataAnnotations;

namespace MyWebProject.Core.Models.LandMarkModel
{
    public class LandMarkByUserAdded
    {
        public int Id { get; set; }

        [MaxLength(GlobalConstant.LandMarkConstant.NameMaxLenght)]
        [MinLength(GlobalConstant.LandMarkConstant.NameMinLenght)]
        public string Name { get; set; } = null!;


        [MinLength(GlobalConstant.LandMarkConstant.DescriptionMinLenght)]
        [MaxLength(GlobalConstant.LandMarkConstant.DescriptionMaxLenght)]
        public string Description { get; set; } = null!;



        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Category { get; set; }
            = new List<CategoryViewModel>();

        public bool IsActive { get; set; } = true;

        [MaxLength(300)]
        public string? VideoURL { get; set; }

        [MaxLength(300)]
        public string? ImageURL { get; set; }

        public string? UserName { get; set; }
    }
}
