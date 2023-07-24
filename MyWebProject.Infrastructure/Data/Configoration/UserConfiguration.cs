using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebProject.Infrastructure.Data.Models;

namespace MyWebProject.Infrastructure.Data.Configoration
{
    public class UserConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasData(dataUsers());
        }

        private List<Users> dataUsers()
        {
            var user = new List<Users>();
            var hasher = new PasswordHasher<Users>();


            var appUser = new Users()
            {
                Id = "630d5dda-7255-4ce9-a658-0eedfb698a5f",
                Avatar = "https://img.freepik.com/premium-vector/young-smiling-man-avatar-man-with-brown-beard-mustache-hair-wearing-yellow-sweater-sweatshirt-3d-vector-people-character-illustration-cartoon-minimal-style_365941-860.jpg",
                Email = "Bobo561@abv.bg",
                EmailConfirmed = true,
                IsActiv = true,
                UserName = "Bobo561@abv.bg",
                NormalizedUserName = "Bobo561@abv.bg",
                NormalizedEmail = "Bobo561@abv.bg",
                FirstName = "Borislav",
                LastName = "Ivanov",
            };

            appUser.PasswordHash = hasher.HashPassword(appUser, "Bobo123!");

            user.Add(appUser);
            return user;
        }
    }
}
