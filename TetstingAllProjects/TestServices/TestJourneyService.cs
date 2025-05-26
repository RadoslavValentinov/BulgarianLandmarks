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
            service = new JourneyService(repo, logger!);

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

        [Test]
        public void Test_Method_Create_Throws_NullReferenceException_When_Required_Field_Is_Null()
        {
            var repo = new Repository(context);
            service = new JourneyService(repo, logger!);
            var model = new JourneyViewModel()
            {
                Id = 50,
                Name = null!, 
                Description = "Description",
                Rating = 7,
                StartDate = "12-09-2023",
                Day = 2,
                Price = 198,
                Urladdress = "https://example.com/image.jpg"
            };
            Assert.ThrowsAsync<NullReferenceException>(async () => await service.Create(model));
        }



        [Test]
        public void Method_Delete_Throws_ArgumentOutOfRangeException_When_ID_Is_Null()
        {
            var repo = new Repository(context);
            service = new JourneyService(repo, logger!);
            
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await service.Delete(0));
        }

        [Test]
        public async Task Method_Delete_Removes_Journey_When_ID_Is_Valid()
        {
            var repo = new Repository(context);
            service = new JourneyService(repo, logger!);

            var journey = new Journeys()
            {
                Id = 50,
                Name = "Test Journey",
                Description = "Test Description",
                Rating = 5,
                StartDate = "12-09-2023",
                Day = 1,
                Price = 100
            };
            await repo.AddAsync(journey);
            await repo.SaveChangesAsync();
            await service.Delete(50);

            var deletedJourney = await repo.GetByIdAsync<Journeys>(50);

            Assert.IsNull(deletedJourney);
        }

        [Test]
        public void GetById_Throws_ArgumentOutOfRangeException_When_ID_Is_Null()
        {
            var repo = new Repository(context);
            service = new JourneyService(repo, logger!);

            Assert.ThrowsAsync<InvalidOperationException>(async () => await service.GetById(0));
        }

        [Test]
        public async Task GetById_Returns_Journey_When_ID_Is_Valid()
        {
            var repo = new Repository(context);
            service = new JourneyService(repo, logger!);

            var journey = new Journeys()
            {
                Id = 50,
                Name = "Test Journey",
                Description = "Test Description",
                Rating = 5,
                StartDate = "12-09-2023",
                Day = 1,
                Price = 100
            };
            await repo.AddAsync(journey);
            await repo.SaveChangesAsync();

            var result = await service.GetById(50);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo(journey.Name));
        }


        [Test]
        public async Task GetByIdNewModel_Returns_Journey_When_ID_Is_Valid()
        {
            var repo = new Repository(context);
            service = new JourneyService(repo, logger!);

            var journey = new Journeys()
            {
                Id = 20,
                Name = "Test Journey",
                Description = "Test Description",
                Rating = 5,
                StartDate = "12-09-2023",
                Day = 1,
                Price = 100,
                pictures = new List<Pictures>
                {
                    new Pictures
                    {
                        JourneyId = 20,
                        UrlImgAddres = "https://t3.ftcdn.net/jpg/02/10/30/46/360_F_210304684_P3pYx0oRpv3x20Q7mn6NVksCxugcUd8j.jpg"
                    }
                }
            };
            await repo.AddAsync(journey);
            await repo.SaveChangesAsync();

            var result = await service.GetByIdNewModel(20);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo(journey.Name));
        }


        [Test]
        public void GetByIdNewModel_Throws_ArgumentOutOfRangeException_When_ID_Is_Null()
        {
            var repo = new Repository(context);
            service = new JourneyService(repo, logger!);

            Assert.ThrowsAsync<InvalidOperationException>(async () => await service.GetByIdNewModel(0));
        }


        [Test]
        public void Edit_Throws_InvalidOperationException_When_Journey_Is_Not_Found()
        {
            var repo = new Repository(context);
            service = new JourneyService(repo, logger!);
            var model = new JourneyViewModel()
            {
                Id = 999, 
                Name = "Non-existent Journey",
                Description = "This journey does not exist.",
                Rating = 5,
                StartDate = "12-09-2023",
                Day = 1,
                Price = 100,
                Urladdress = "https://exampleOfCurrentTest.com/image.jpg"
            };
            Assert.ThrowsAsync<InvalidOperationException>(async () => await service.Edit(model));
        }

        [Test]
        public async Task Edit_Updates_Journey_When_Model_Is_Valid()
        {
            var repo = new Repository(context);
            service = new JourneyService(repo, logger!);

            var journey = new Journeys()
            {
                Id = 50,
                Name = "Test Journey",
                Description = "Test Description",
                Rating = 5,
                StartDate = "12-09-2023",
                Day = 1,
                Price = 100
            };
            await repo.AddAsync(journey);
            await repo.SaveChangesAsync();

            var model = new JourneyViewModel()
            {
                Id = 50,
                Name = "Updated Journey",
                Description = "Updated Description",
                Rating = 8,
                StartDate = "15-09-2023",
                Day = 2,
                Price = 150,
                Urladdress = "https://exampleOfCurrentTest.com"
            };
            var updatedJourney = await service.Edit(model);

            Assert.Multiple(() =>
            {
                Assert.That(updatedJourney.Name, Is.EqualTo("Updated Journey"));
                Assert.That(updatedJourney.Description, Is.EqualTo("Updated Description"));
                Assert.That(updatedJourney.Rating, Is.EqualTo(8));
                Assert.That(updatedJourney.StartDate, Is.EqualTo("15-09-2023"));
                Assert.That(updatedJourney.Day, Is.EqualTo(2));
                Assert.That(updatedJourney.Price, Is.EqualTo(150));
            });
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
