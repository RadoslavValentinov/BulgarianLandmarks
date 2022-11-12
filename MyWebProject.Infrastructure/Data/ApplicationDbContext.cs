using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using My_Web_Project_LandMarks_.Infrastructure.Data.Models;
using MyWebProject.Infrastructure.Data.Configoration;
using MyWebProject.Infrastructure.Data.Models;

namespace My_Web_Project_LandMarks_.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<Users>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Town> Towns { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<LandMark> Landmarks { get; set; } = null!;

        public DbSet<Cultural_events> Cultural_Events { get; set; } = null!;

        public DbSet<Journeys> Journeys { get; set; } = null!;

        public DbSet<Pictures> Pictures { get; set; } = null!;
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<LandMark>()
                .HasOne(x=>x.Town)
                .WithMany(x=>x.Landmarks)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.ApplyConfiguration(new UserConfiguration());
            //builder.ApplyConfiguration(new TownConfiguration());
            //builder.ApplyConfiguration(new PictureConfiguration());
            //builder.ApplyConfiguration(new LandMarkConfiguration());
            //builder.ApplyConfiguration(new JourneyConfiguration());
            //builder.ApplyConfiguration(new CultureEventConfiguration());
           // builder.ApplyConfiguration(new CategoryConfiguration());


            base.OnModelCreating(builder);
        }
    }
}