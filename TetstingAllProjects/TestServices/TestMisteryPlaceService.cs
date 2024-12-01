using Microsoft.EntityFrameworkCore;
using MyWebProject.Core.Models.Top10;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Core.Services.Services;
using MyWebProject.Infrastructure.Data;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;

namespace TetstingAllProjects.TestServices
{
    public class TestMisteryPlaceService
    {
        private IMysteryPlace services;
        private ApplicationDbContext context;


        [SetUp]
        public void Setup()
        {

            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase("LandDB")
                 .Options;

            context = new ApplicationDbContext(contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        [Test]
        public async Task TestMisteryPlace()
        {
            var repo = new Repository(context);
            services = new MysteryPlace(repo);

            var allService = await services.MysteryPlaces();

            var dbAll = await repo.AllReadonly<LandMark>()
                .Where(x => x.TownId == null && x.VideoURL != null)
               .Select(m => new MisteryModelView()
               {
                   Id = m.Id,
                   Name = m.Name,
                   Description = m.Description,
                   Rating = m.Rating,
                   VideoUrl = m.VideoURL ?? null!,
                   Pictures = m.Pictures.Where(p => p.LandMarkId == m.Id).ToList()
               })
               .OrderBy(x => x.Name)
               .ToListAsync();

            Assert.That(allService.Count(), Is.EqualTo(dbAll.Count()));
        }


        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
