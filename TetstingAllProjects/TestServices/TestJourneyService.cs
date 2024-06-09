using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyWebProject.Core.Models.JourneyModel;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Core.Services.Services;
using MyWebProject.Infrastructure.Data;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetstingAllProjects.TestServices
{
    public class TestJourneyService
    {
        private IJourneyServise? service;
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

            Assert.That(afterSet.Description, Is.EqualTo(newJourney.Description));
            Assert.That(afterSet.StartDate, Is.EqualTo(newJourney.StartDate));
            Assert.That(afterSet.Rating, Is.EqualTo(newJourney.Rating));
            Assert.That(afterSet.Day, Is.EqualTo(newJourney.Day));
            Assert.That(afterSet.Price, Is.EqualTo(newJourney.Price));

            Assert.That(allJourney.Count() + 1, Is.EqualTo(AllSet.Count()));
        }


        [Test]
        public void Test_Method_Create_Added_New_Journey_Throw_Exeption()
        {
            var repo = new Repository(context);
            service = new JourneyService(repo, logger!);

            Assert.ThrowsAsync<NullReferenceException>(async () => await service.Create(new JourneyViewModel()
            {
                Name = "    ",
                Description = "Пирин е разположен в югозападната част на страната между долините на ... Северен Пирин е най-големият дял на планината и всъщност неговата същинска",
                Rating = 0.0m,
                StartDate = null!,
                Day = null,
                Price = 198,
                Urladdress = null!
            }));
        }


        [Test]
        public async Task Test_Method_GetById_Return_Correctly_Journey()
        {
            var repo = new Repository(context);
            service = new JourneyService(repo, logger);

            await service.Create(new JourneyViewModel()
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

            var getById = await service.GetById(50);

            Assert.That(afterSet.Name, Is.EqualTo(getById.Name));
            Assert.That(afterSet.Description, Is.EqualTo(getById.Description));
            Assert.That(afterSet.Price, Is.EqualTo(getById.Price));
            Assert.That(afterSet.Day, Is.EqualTo(getById.Day));
        }


        [Test]
        public async Task Test_Method_GetByIdNewModel_Return_Correctly_Journey()
        {
            var repo = new Repository(context);
            service = new JourneyService(repo, logger!);

            await service.Create(new JourneyViewModel()
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

            var getById = await service.GetByIdNewModel(50);

            Assert.That(afterSet.Name, Is.EqualTo(getById.Name));
            Assert.That(afterSet.Description, Is.EqualTo(getById.Description));
            Assert.That(afterSet.Price, Is.EqualTo(getById.Price));
            Assert.That(afterSet.Day, Is.EqualTo(getById.Day));
        }


        // Method connot added
        [Test]
        public async Task Test_Method_Delete_Remove_Journey_Corectly()
        {
            var repo = new Repository(context);
            service = new JourneyService(repo, logger!);

            await service.Create(new JourneyViewModel()
            {
                Id = 50,
                Name = "дву дневна екскурзия в недрата на Пирин",
                Description = "Пирин е разположен в югозападната част на страната между долините на ... Северен Пирин е най-големият дял на планината и всъщност неговата същинска",
                Rating = 7,
                StartDate = "12-09-2023",
                Day = 2,
                Price = 198,
                Urladdress = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/69/Pirin_pano0.jpg/2250px-Pirin_pano0.jpg"
            });

            var getDB = await repo.AllReadonly<Journeys>().ToListAsync();

            await service.Delete(50);

            var getCurent = await service.GetAll();

            Assert.That(getDB.Count() - 1, Is.EqualTo(getCurent.Count()));
        }


        [Test]
        public void Test_Method_Delete_Throw_Exeption_Model_Is_Not_Valid()
        {
            var repo = new Repository(context);
            service = new JourneyService(repo, logger!);

            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await service.Delete(150));
        }


        [Test]
        public void Test_Method_Edit_Trow_Exeption_to_Model_Is_Not_Valid()
        {
            var repo = new Repository(context);
            service = new JourneyService(repo, logger!);


            Assert.ThrowsAsync<InvalidOperationException>(async () => await service.Edit(new JourneyViewModel()
            {
                Id = 50,
                Name = " Дву дневна екскурзия в Пирин",
                Description = "Пирин е разположен в югозападната част на страната между долините наСеверен Пирин е най-големият дял на планината и всъщност неговата същинска",
                Rating = 10,
                StartDate = "20-09-2023",
                Day = 3,
                Price = 398,
                Urladdress = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/69/Pirin_pano0.jpg/2250px-Pirin_pano0.jpg"
            }));

        }


        [Test]
        public async Task Test_Method_Edit_Set_New_Value_Corectly()
        {
            var repo = new Repository(context);
            service = new JourneyService(repo, logger!);

            await service.Create(new JourneyViewModel()
            {
                Id = 50,
                Name = "дву дневна екскурзия в недрата на Пирин",
                Description = "Пирин е разположен в югозападната част на страната между долините на ... Северен Пирин е най-големият дял на планината и всъщност неговата същинска",
                Rating = 7,
                StartDate = "12-09-2023",
                Day = 2,
                Price = 198,
                Urladdress = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/69/Pirin_pano0.jpg/2250px-Pirin_pano0.jpg"
            });


            await service.Edit(new JourneyViewModel()
            {
                Id = 50,
                Name = " Дву дневна екскурзия в Пирин",
                Description = "Пирин е разположен в югозападната част на страната между долините наСеверен Пирин е най-големият дял на планината и всъщност неговата същинска",
                Rating = 10,
                StartDate = "20-09-2023",
                Day = 3,
                Price = 398
            });

            var getUpdated = await service.GetById(50);

            Assert.That(getUpdated.Rating, Is.EqualTo(10));
            Assert.That(getUpdated.Day, Is.EqualTo(3));
            Assert.That(getUpdated.Price, Is.EqualTo(398));
            Assert.That(getUpdated.Name, Is.EqualTo(" Дву дневна екскурзия в Пирин"));
            Assert.That(getUpdated.Description, Is.EqualTo("Пирин е разположен в югозападната част на страната между долините наСеверен Пирин е най-големият дял на планината и всъщност неговата същинска"));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
