using MyWebProject.Core.Constants;
using MyWebProject.Core.Models.Category;
using MyWebProject.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MyWebProject.Core.Models.LandMarkModel
{
    public class AddLandMarkViewModel
    {
        public int Id { get; set; }

        [MaxLength(GlobalConstant.LandMarkConstant.NameMaxLenght)]
        [MinLength(GlobalConstant.LandMarkConstant.NameMinLenght)]
        public string Name { get; set; } = null!;


        [MinLength(GlobalConstant.LandMarkConstant.DescriptionMinLenght)]
        [MaxLength(GlobalConstant.LandMarkConstant.DescriptionMaxLenght)]
        public string Description { get; set; } = null!;


        public decimal Rating { get; set; }

        public int CategoryId { get; set; }

        public bool IsActive { get; set; } = true;

        public IEnumerable<CategoryViewModel> Category { get; set; }
            = new List<CategoryViewModel>();

        [MaxLength(300)]
        public string? VideoURL { get; set; }

        [MaxLength(300)]
        public string? ImageURL { get; set; }

        public List<Pictures> Pictures { get; set; }
            = new List<Pictures>();

        public string? UserName { get; set; }
    }
}
