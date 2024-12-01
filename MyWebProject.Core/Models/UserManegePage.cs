using MyWebProject.Core.Constants;
using MyWebProject.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MyWebProject.Core.Models
{
    public class UserManegePageViewModel
    {
        public string? Avatar { get; set; }

        [StringLength(GlobalConstant.UserConstant.FirstNameMaxLenght,
          MinimumLength = GlobalConstant.UserConstant.FirstNameMinLenght)]
        public string? UserName { get; set; }

        public string? OldPassword { get; set; }

        [StringLength(GlobalConstant.UserConstant.PassworMaxLenght,
           MinimumLength = GlobalConstant.UserConstant.PassworMinLenght)]

        public string? newPassword { get; set; }

        [StringLength(GlobalConstant.UserConstant.PassworMaxLenght,
           MinimumLength = GlobalConstant.UserConstant.PassworMinLenght)]

        public string? ConfirmPassword { get; set; }


        [StringLength(GlobalConstant.UserConstant.FirstNameMaxLenght,
            MinimumLength = GlobalConstant.UserConstant.FirstNameMinLenght)]
        public string? FirstName { get; set; }


        [StringLength(GlobalConstant.UserConstant.LastNameMaxLenght,
            MinimumLength = GlobalConstant.UserConstant.LastNameMinLenght)]
        public string? LastName { get; set; }


        [EmailAddress]
        public string? Email { get; set; }

        public List<LandMark> SightsVisited { get; set; } =
            new List<LandMark>();

        public List<Pictures> UserPicture { get; set; }
            = new List<Pictures>();

    }
}
