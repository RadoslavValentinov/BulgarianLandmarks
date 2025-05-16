using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyWebProject.Core.Services.Services;
using MyWebProject.Infrastructure.Data;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;

namespace TetstingAllProjects.TestServices
{
    [TestFixture]
    public class TestHomeServices
    {
        private HomeServices? service;
        private ApplicationDbContext context;
        private readonly ILogger<HomeServices>? logger;

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
        public async Task Test_Method_AllPicture_Return_Collection_Corectly()
        {
            var repo = new Repository(context);
            service = new HomeServices(repo, logger!);

            var allServicePicture = await service.AllPicture();

            var allDBPicture = await repo.AllReadonly<Pictures>()
                .Where(x => x.TownId == null && x.LandMarkId == null && x.JourneyId == null)
                .ToArrayAsync();

            Assert.That(allServicePicture.Count(), Is.EqualTo(allDBPicture.Length));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
