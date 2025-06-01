using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyWebProject.Core.Models.Town;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Core.Services.Services;
using MyWebProject.Infrastructure.Data;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;

namespace TetstingAllProjects.TestServices
{
    [TestFixture]
    public class TestTownService
    {
        private TownService? service;
        private ApplicationDbContext context;
        private readonly ILogger<TownService>? logger;


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
        public async Task Test_Method_TownsById_Return_Town_Correctly()
        {
            var repo = new Repository(context);
            service = new TownService(repo, logger!);

            var targetTown = await service.TownsById(1);

            Assert.That(targetTown.Name, Is.EqualTo("София"));

        }

        [Test]
        public async Task Test_Method_TownsByName_Return_Town_Correctly()
        {
            var repo = new Repository(context);
            service = new TownService(repo, logger!);

            var targetTown = await service.TownsByName("Плевен");

            Assert.Multiple(() =>
            {
                Assert.That(targetTown.Name, Is.EqualTo("Плевен"));
                Assert.That(targetTown.Id, Is.EqualTo(3));
            });
        }

        [Test]
        public void TownsByName_Returns_Empty_Collection_When_No_Data()
        {
            var repo = new Repository(context);
            service = new TownService(repo, logger!);

            Assert.ThrowsAsync<InvalidOperationException>(async () => await service.TownsByName(null!));
        }



        [Test]
        public async Task Test_Method_AllTowns_Return_Town_Correctly()
        {
            var repo = new Repository(context);
            service = new TownService(repo, logger!);

            var townByService = await service.AllTowns();

            var townsDb = await repo.AllReadonly<Town>().ToListAsync();

            Assert.That(townByService.Count(), Is.EqualTo(townsDb.Count));
        }



        [Test]
        public async Task Test_Method_Create_Add_Town_Correctly()
        {
            var repo = new Repository(context);
            service = new TownService(repo, logger!);

            var townCount = await service.AllTowns();

            await service.CreateTown(new CreateTownViewModel()
            {
                Id = 100,
                Name = "Русе",
                Description = "Русе е край реюен град с добро... ",
            });

            var getNewTown = await service.TownsById(100);

            var dbTown = await repo.AllReadonly<Town>().ToListAsync();

            Assert.Multiple(() =>
            {
                Assert.That(townCount.Count() + 1, Is.EqualTo(dbTown.Count)); // Fixed: Replaced Enumerable.Count() with Count property
                Assert.That(getNewTown.Name, Is.EqualTo("Русе"));
                Assert.That(getNewTown.Description, Is.EqualTo("Русе е край реюен град с добро... "));
            });
        }


        [Test]
        public void Test_Method_CreateTown_Throw_Exeption_If_Model_Is_Not_Valid()
        {
            var repo = new Repository(context);
            service = new TownService(repo, logger!);

            Assert.ThrowsAsync<ArgumentNullException>(async () => await service.CreateTown(new CreateTownViewModel()));
        }


        [Test]
        public void Test_Method_Delete_Throw_Exeption_If_Id_Not_Found()
        {
            var repo = new Repository(context);
            service = new TownService(repo, logger!);

            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await service.Delete(200));
        }


        [Test]
        public async Task Test_Method_Delete_Remove_Town_Succsessfuly()
        {
            var repo = new Repository(context);
            service = new TownService(repo, logger!);

            var all = await service.AllTowns();

            await service.CreateTown(new CreateTownViewModel()
            {
                Id = 100,
                Name = "Русе",
                Description = "Русе е край реюен град с добро... ",

            });

            var dbTown = await repo.AllReadonly<Town>().ToListAsync();

            await service.Delete(100);

            Assert.That(all.Count(), Is.EqualTo(dbTown.Count - 1)); // Fixed: Replaced Enumerable.Count() with Count property
        }

        [Test]
        public async Task Test_Method_Edit_Update_Successfully_LandMark()
        {
            var repo = new Repository(context);
            service = new TownService(repo, logger!);

            await service.CreateTown(new CreateTownViewModel()
            {
                Id = 100,
                Name = "Русе",
                Description = "Русе е край реюен град с добро... ",
            });

            await service.Edit(new TownViewModelGetTown()
            {
                Id = 100,
                Name = "Созопол",
                Description = "Созопол е край морски град с добро... ",
            });

            var getUpdated = await service.TownsById(100);

            Assert.Multiple(() =>
            {
                Assert.That(getUpdated.Name, Is.EqualTo("Созопол"));
                Assert.That(getUpdated.Description, Is.EqualTo("Созопол е край морски град с добро... "));
            });
        }

        [Test]
        public void Test_Method_Edit_Throw_Exeption_If_Model_Not_Valid()
        {
            var repo = new Repository(context);
            service = new TownService(repo, logger!);

            Assert.ThrowsAsync<NullReferenceException>(async () => await service.Edit(new TownViewModelGetTown()));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
