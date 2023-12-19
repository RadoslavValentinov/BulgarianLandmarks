namespace MyWebProject.Core.Models

{
    public class UserviewModel
    {
        public string Avatar { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public bool IsActive { get; set; }

    }
}
