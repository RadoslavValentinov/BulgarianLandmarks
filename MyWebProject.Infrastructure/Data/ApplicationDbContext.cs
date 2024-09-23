using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyWebProject.Infrastructure.Data.Configoration;
using MyWebProject.Infrastructure.Data.Models;
using System.Reflection.Emit;

namespace MyWebProject.Infrastructure.Data
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

        public DbSet<Landmark_suggestions> LandmarkSuggestions { get; set; } = null!;

        public DbSet<Cultural_events> Cultural_Events { get; set; } = null!;

        public DbSet<PictureByUser> UserPicture { get; set; } = null!;

        public DbSet<Journeys> Journeys { get; set; } = null!;

        public DbSet<Pictures> Pictures { get; set; } = null!;

        public DbSet<InterestingFacts> Facts { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Cultural_events>()
                .HasMany(x => x.AllUsers)
                .WithMany(x => x.CulturalEvents)
                .UsingEntity(j=> j.ToTable("Cultural_eventsUsers"));

            builder.Entity<LandMark>()
                .HasOne(x => x.Town)
                .WithMany(x => x.Landmarks)
            .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Category>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });

           

            builder.Entity<Pictures>()
            .HasOne(x => x.Journey)
            .WithMany(a => a.pictures)
            .OnDelete(DeleteBehavior.Cascade);



            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new TownConfiguration());
            builder.ApplyConfiguration(new PictureConfiguration());
            builder.ApplyConfiguration(new LandMarkConfiguration());
            builder.ApplyConfiguration(new JourneyConfiguration());
            builder.ApplyConfiguration(new CultureEventConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new InterestigFactConfiguration());


            base.OnModelCreating(builder);
        }
    }
}