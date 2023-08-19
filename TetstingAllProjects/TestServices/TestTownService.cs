using Microsoft.EntityFrameworkCore;
using MyWebProject.Core.Models.LandMarkModel;
using MyWebProject.Core.Models.Town;
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
    [TestFixture]
    public class TestTownService
    {
        private ITownService service;
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
        public async Task Test_Method_TownsById_Return_Town_Correctly()
        {
            var repo = new Repository(context);
            service = new TownService(repo);

            var targetTown = await service.TownsById(1);

            Assert.That(targetTown.Name, Is.EqualTo("София"));
           
        }

        [Test]
        public async Task Test_Method_TownsByName_Return_Town_Correctly()
        {
            var repo = new Repository(context);
            service = new TownService(repo);

            var targetTown = await service.TownsByName("Плевен");

            Assert.That(targetTown.Name, Is.EqualTo("Плевен"));
            Assert.That(targetTown.Id, Is.EqualTo(3));
        }



        [Test]
        public async Task Test_Method_AllTowns_Return_Town_Correctly()
        {
            var repo = new Repository(context);
            service = new TownService(repo);

            var townByService = await service.AllTowns();

            var townsDb = await repo.AllReadonly<Town>().ToListAsync();

            Assert.That(townByService.Count(), Is.EqualTo(townsDb.Count()));

        }



        [Test]
        public async Task Test_Method_Create_Add_Town_Correctly()
        {
            var repo = new Repository(context);
            service = new TownService(repo);

            var townCount = await service.AllTowns();

            await service.CreateTown(new CreateTownViewModel()
            {
                Id = 100,
                Name = "Русе",
                Description = "Русе е край реюен град с добро... ",
              
            });

            var getNewTown = await service.TownsById(100);

            var dbTown = await repo.AllReadonly<Town>().ToListAsync();

            Assert.That(townCount.Count()+1, Is.EqualTo(dbTown.Count()));

            Assert.That(getNewTown.Name, Is.EqualTo("Русе"));
            Assert.That(getNewTown.Description, Is.EqualTo("Русе е край реюен град с добро... "));
        }


        [Test]
        public void Test_Method_CreateTown_Throw_Exeption_If_Model_Is_Not_Valid()
        {
            var repo = new Repository(context);
            service = new TownService(repo);

            Assert.ThrowsAsync<ArgumentNullException>(async ()=> await service.CreateTown(new CreateTownViewModel()));
        }


        [Test]
        public void Test_Method_Delete_Throw_Exeption_If_Id_Not_Found()
        {
            var repo = new Repository(context);
            service = new TownService(repo);

            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await service.Delete(200));
        }


        [Test]
        public async Task Test_Method_Delete_Remove_Town_Succsessfuly()
        {
            var repo = new Repository(context);
            service = new TownService(repo);

            var all = await service.AllTowns();

            await service.CreateTown(new CreateTownViewModel()
            {
                Id = 100,
                Name = "Русе",
                Description = "Русе е край реюен град с добро... ",

            });

            var dbTown = await repo.AllReadonly<Town>().ToListAsync();

            await service.Delete(100);


            Assert.That(all.Count(), Is.EqualTo(dbTown.Count() - 1));
        }

        [Test]
        public async Task Test_Method_Edit_Update_Successfully_LandMark()
        {
            var repo = new Repository(context);
            service = new TownService(repo);

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

            Assert.That(getUpdated.Name, Is.EqualTo("Созопол"));
            Assert.That(getUpdated.Description, Is.EqualTo("Созопол е край морски град с добро... "));
        }

        [Test]
        public void Test_Method_Edit_Throw_Exeption_If_Model_Not_Valid()
        {
            var repo = new Repository(context);
            service = new TownService(repo);

            Assert.ThrowsAsync<NullReferenceException>(async () => await service.Edit(new TownViewModelGetTown()));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
