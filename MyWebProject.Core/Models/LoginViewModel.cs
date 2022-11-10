using My_Web_Project_LandMarks_.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace My_Web_Project_LandMarks_.Core.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(GlobalConstant.UserConstant.PassworMaxLenght,
            MinimumLength =GlobalConstant.UserConstant.PassworMinLenght)]
        public string Password { get; set; } = null!;

        public bool RememberMe { get; set; }
    }
}
