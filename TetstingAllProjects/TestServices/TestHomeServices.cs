using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyWebProject.Core.Models.PictureModel;
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

        [Test]
        public void Test_Method_AllPicture_Return_Collection_Corectly_When_Empty()
        {
            var repo = new Repository(context);
            service = new HomeServices(repo, logger!);

            var allServicePicture = service.AllPictureOfUserUpload().Result;

            Assert.That(allServicePicture.Count(), Is.EqualTo(0));
        }

        [Test]
        public void Test_Method_AllPictureOfUserUpload_Return_Collection_Corectly()
        {
            var repo = new Repository(context);
            service = new HomeServices(repo, logger!);
            var allServicePicture = service.AllPictureOfUserUpload().Result;
            var allDBPicture = repo.AllReadonly<Pictures>()
                .Where(x => x.UserName != null)
                .Select(x => new AddPictureViewModel()
                {
                    Id = x.Id,
                    UrlImgAddres = x.UrlImgAddres,
                    LandMark = x.LandMarkId,
                    Town = x.TownId,
                    Journey = x.JourneyId,
                    PictureData = x.ArrayPicture,
                    LikeCount = x.LikeCount,
                    UserName = x.UserName
                }).ToList();
            Assert.That(allServicePicture.Count(), Is.EqualTo(allDBPicture.Count));
        }


        [Test]
        public void AllData_Return_Correctly_When_Empty()
        {
            var repo = new Repository(context);
            service = new HomeServices(repo, logger!);
            var model = new MyWebProject.Core.Models.AdminHomeModel.AdminHomeModelAllData();
            var allData = service.AllData(model);
            allData = null;

            Assert.That(allData, Is.Null);
        }

        [Test]
        public void AllData_Data_Return_Correctly()
        {
            var repo = new Repository(context);
            service = new HomeServices(repo, logger!);
            var model = new MyWebProject.Core.Models.AdminHomeModel.AdminHomeModelAllData();
            var allData = service.AllData(model);

            Assert.That(allData.CountOfTown, Is.EqualTo(allData!.CountOfTown));
            Assert.That(allData.CountOfCategory, Is.EqualTo(allData!.CountOfCategory));
            Assert.That(allData.CountOfLandmarks, Is.EqualTo(allData!.CountOfLandmarks));
            Assert.That(allData.CountOfEvents, Is.EqualTo(allData!.CountOfEvents));
            Assert.That(allData.CountOfJourney, Is.EqualTo(allData!.CountOfJourney));
            Assert.That(allData.CountOfPictures, Is.EqualTo(allData!.CountOfPictures));
            Assert.That(allData.CountOfFacts, Is.EqualTo(allData!.CountOfFacts));

        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
