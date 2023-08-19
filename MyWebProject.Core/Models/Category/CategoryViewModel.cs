using MyWebProject.Core.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
