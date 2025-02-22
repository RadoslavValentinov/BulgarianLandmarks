namespace MyWebProject.Core.Models

{
    public class UserviewModel
    {
        public byte[]? PictureOfFileAvatar { get; set; }

        public string Avatar { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public bool IsActive { get; set; }

        public DateTime LastActiveLog { get; set; }

    }
}
