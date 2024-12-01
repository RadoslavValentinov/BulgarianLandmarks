using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyWebProject.Core.Models.LandMarkModel;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Core.Services.Services;
using MyWebProject.Infrastructure.Data;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;
using NUnit.Framework.Internal;

namespace TetstingAllProjects.TestServices
{
    [TestFixture]
    public class TestLandMarkService
    {
        private ILandmarkService? service;
        private ApplicationDbContext context;
        private readonly ILogger<LandMarkService>? logger;


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
        public void Method_AddNew_LandMark_Throw_Exeption_To_Model_Property_Is_Empty()
        {
            var repo = new Repository(context);
            service = new LandMarkService(repo, logger!);

            Assert.ThrowsAsync<NullReferenceException>(async () => await service.AddLandMark(new AddLandMarkViewModel()));
        }

        [Test]
        public async Task Method_AddNew_LandMark_Added_Model_Corectly()
        {
            var repo = new Repository(context);
            service = new LandMarkService(repo, logger!);

            var allLadmark = await service.GetAllLandmark();

            await service.AddLandMark(new AddLandMarkViewModel()
            {
                Id = 100,
                Name = "Зоопарк Плевен",
                Description = "Зоопаркът е построен по шремето на социализмът... ",
                Rating = 8.9m,
                CategoryId = 1,
                ImageURL = "https://darik.bg/media/628/zoopark-kajlaka-me4kite-2.l.webp"
            });

            var getAllLandmark = await repo.AllReadonly<LandMark>().ToListAsync();

            var getById = await service.GetById(100);

            Assert.That(allLadmark.Count() + 1, Is.EqualTo(getAllLandmark.Count()));
            Assert.That(getById.Name, Is.EqualTo("Зоопарк Плевен"));
            Assert.That(getById.Description, Is.EqualTo("Зоопаркът е построен по шремето на социализмът... "));
        }

        [Test]
        public async Task Method_AddNewUser_LandMark_Added_Model_Corectly()
        {
            var repo = new Repository(context);
            service = new LandMarkService(repo, logger!);

            var allLadmark = await service.GetAllByUser();

            await service.AddLandMarkOfUsers(new LandMarkByUserAdded()
            {
                Id = 100,
                Name = "Зоопарк Плевен",
                Description = "Зоопаркът е построен по шремето на социализмът... ",
                CategoryId = 1,
                ImageURL = "https://darik.bg/media/628/zoopark-kajlaka-me4kite-2.l.webp"
            });

            var getAllLandmark = await repo.AllReadonly<Landmark_suggestions>().ToListAsync();

            var getById = await repo.GetByIdAsync<Landmark_suggestions>(100);

            Assert.That(allLadmark.Count() + 1, Is.EqualTo(getAllLandmark.Count()));
            Assert.That(getById.Name, Is.EqualTo("Зоопарк Плевен"));
            Assert.That(getById.Description, Is.EqualTo("Зоопаркът е построен по шремето на социализмът... "));
        }


        [Test]
        public void Method_AddNewUser_LandMark_Throw_Exeption_To_Model_Property_Is_Empty()
        {
            var repo = new Repository(context);
            service = new LandMarkService(repo, logger!);

            Assert.ThrowsAsync<NullReferenceException>(async () => await service.AddLandMarkOfUsers(new LandMarkByUserAdded()));
        }


        [Test]
        public async Task Method_AllCategory_Return_All_Category_Corectly()
        {
            var repo = new Repository(context);
            service = new LandMarkService(repo, logger!);

            var all = await service.AllCategory();

            Assert.That(all.Count(), Is.EqualTo(8));
        }


        [Test]
        public async Task Test_Method_ExistById_Return_True_Result()
        {
            var repo = new Repository(context);
            service = new LandMarkService(repo, logger!);

            Assert.IsTrue(await service.ExistById(7));
        }

        [Test]
        public async Task Test_Method_ExistById_Return_False_Result()
        {
            var repo = new Repository(context);
            service = new LandMarkService(repo, logger!);

            Assert.IsFalse(await service.ExistById(-1));
        }

        [Test]
        public void TestMetyhod_Delete_Throw_Exp_To_Id_Is_Not_Valid()
        {
            var repo = new Repository(context);
            service = new LandMarkService(repo, logger!);

            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await service.Delete(100));
        }


        [Test]
        public async Task Test_Method_Delete_Succsessfully()
        {
            var repo = new Repository(context);
            service = new LandMarkService(repo, logger!);


            var allLadmark = await service.GetAllLandmark();

            await service.AddLandMark(new AddLandMarkViewModel()
            {
                Id = 100,
                Name = "Зоопарк Плевен",
                Description = "Зоопаркът е построен по шремето на социализмът... ",
                Rating = 8.9m,
                CategoryId = 1,
                ImageURL = "https://darik.bg/media/628/zoopark-kajlaka-me4kite-2.l.webp"
            });


            await service.Delete(100);

            var getAllLandmark = await repo.AllReadonly<LandMark>().ToListAsync();

            Assert.That(allLadmark.Count(), Is.EqualTo(getAllLandmark.Count()));
        }



        [Test]
        public void Test_Method_Edit_Trow_Exeption_Name_And_Description_Is_Null()
        {
            var repo = new Repository(context);
            service = new LandMarkService(repo, logger!);

            Assert.ThrowsAsync<NullReferenceException>(async () => await service.Edit(new LandMarkViewModelAll()));
        }

        [Test]
        public void Test_Method_Edit_Trow_Exeption_Model_Is_Empty()
        {
            var repo = new Repository(context);
            service = new LandMarkService(repo, logger!);

            Assert.ThrowsAsync<NullReferenceException>(async () => await service.Edit(new LandMarkViewModelAll()
            {
                Name = "Pirin",
                Description = "Pirin is Montain in Bulgaria..."
            }));
        }

        [Test]
        public async Task Test_Method_Edit_Update_Successfully_LandMark()
        {
            var repo = new Repository(context);
            service = new LandMarkService(repo, logger!);

            await service.AddLandMark(new AddLandMarkViewModel()
            {
                Id = 100,
                Name = "Зоопарк Плевен",
                Description = "Зоопаркът е построен по шремето на социализмът... ",
                Rating = 8.9m,
                CategoryId = 1,
                ImageURL = "https://darik.bg/media/628/zoopark-kajlaka-me4kite-2.l.webp"
            });

            await service.Edit(new LandMarkViewModelAll()
            {
                Id = 100,
                Name = "Зоопарк Стара Загора",
                Description = "Зоопаркът е изшестен с разнообразието от вишотни... ",
                Rating = 9.9m,
            });

            var getUpdated = await service.GetById(100);

            Assert.That(getUpdated.Name, Is.EqualTo("Зоопарк Стара Загора"));
            Assert.That(getUpdated.Description, Is.EqualTo("Зоопаркът е изшестен с разнообразието от вишотни... "));
            Assert.That(getUpdated.Rating, Is.EqualTo(9.9));
        }




    }
}
