using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyWebProject.Core.Models.JourneyModel;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Core.Services.Services;
using MyWebProject.Infrastructure.Data;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;

namespace TetstingAllProjects.TestServices
{
    public class TestJourneyService
    {
        private JourneyService? service;
        private ApplicationDbContext context;
        private readonly ILogger<JourneyService>? logger;

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
        public async Task Test_Method_Create_Added_New_Journey()
        {
            var repo = new Repository(context);
            service = new JourneyService(repo, logger);

            var allJourney = await service.GetAll();

            var newJourney = await service.Create(new JourneyViewModel()
            {
                Id = 50,
                Name = "дву дневна екскурзия в недрата на Пирин",
                Description = "Пирин е разположен в югозападната част на страната между долините на ... Северен Пирин е най-големият дял на планината и всъщност неговата същинска",
                Rating = 7,
                StartDate = "12-09-2023",
                Day = 2,
                Price = 198,
                Urladdress = "https://t0.gstatic.com/licensed-image?q=tbn:ANd9GcSbXKsSTtJzlgHarTVuEPLWCEz1PRdbnZrqKC20Oa0WpmBazpBKGXm4mG9Hu8SKEQrZ"
            });

            await repo.SaveChangesAsync();

            var afterSet = await repo.GetByIdAsync<Journeys>(50);
            var AllSet = await repo.AllReadonly<Journeys>().ToListAsync();

            Assert.Multiple(() =>
            {
                Assert.That(afterSet.Description, Is.EqualTo(newJourney.Description));
                Assert.That(afterSet.StartDate, Is.EqualTo(newJourney.StartDate));
                Assert.That(afterSet.Rating, Is.EqualTo(newJourney.Rating));
                Assert.That(afterSet.Day, Is.EqualTo(newJourney.Day));
                Assert.That(afterSet.Price, Is.EqualTo(newJourney.Price));
                Assert.That(allJourney.Count() + 1, Is.EqualTo(AllSet.Count));
            });
        }


        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
