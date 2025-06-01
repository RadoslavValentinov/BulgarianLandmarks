using Microsoft.EntityFrameworkCore;
using MyWebProject.Core.Models.LandMarkModel;
using MyWebProject.Core.Models.Top10;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Core.Services.Services;
using MyWebProject.Infrastructure.Data;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;

namespace TetstingAllProjects.TestServices
{
    [TestFixture]
    public class TestTop10Service
    {
        private Top10Destination? services;
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
        public async Task TestMethod_AllLandMarkByTown_Return_Data_Correctly()
        {
            var repo = new Repository(context);
            services = new Top10Destination(repo);


            var allService = await services.AllLandMarkByTown();

            var dbAll = await repo.AllReadonly<LandMark>()
                .Where(x => x.TownId != null && x.Rating >= 9)
                .Select(l => new LandMarkViewModelAll()
                {
                    Id = l.Id,
                    Name = l.Name,
                    Description = l.Description,
                    Rating = l.Rating,
                    TownName = l.Town!.Name,
                    Pictures = l.Pictures.Where(p => p.LandMarkId == l.Id)
                    .ToList(),
                })
                .OrderBy(x => x.Name)
                .ToListAsync();


            Assert.That(allService.Count(), Is.EqualTo(dbAll.Count));
        }


        [Test]
        public void AllLandMarkByTown_Returns_Empty_Collection_When_No_Data()
        {
            var repo = new Repository(context);
            services = new Top10Destination(repo);

           
            var allService = services.AllLandMarkByTown();
            allService = null;

            Assert.That(allService, Is.EqualTo(null));
        }



        [Test]
        public async Task TestMethod_Get10TopLandMark_Return_Data_Correctly()
        {
            var repo = new Repository(context);
            services = new Top10Destination(repo);


            var allService = await services.Get10TopLandMark();

            var dbAll = await repo.AllReadonly<LandMark>()
              .Where(x => x.Rating >= 9.2m && x.Rating <= 10m)
                .Select(d => new Top10ViewModelLandMark
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description,
                    Rating = d.Rating,
                    TownName = d.Town!.Name,
                    Category = d.Category.Name,
                    Pictures = d.Pictures.Where(z => z.LandMarkId == d.Id)
                    .ToList(),
                })
                .OrderByDescending(x => x.Rating)
                .Take(10)
                .ToListAsync();


            Assert.That(allService.Count(), Is.EqualTo(dbAll.Count));
        }


        [Test]
        public void Get10TopLandMark_Returns_Empty_Collection_When_No_Data()
        {
            var repo = new Repository(context);
            services = new Top10Destination(repo);


            var allServiceInfo = services.Get10TopLandMark();
            allServiceInfo = null;

            Assert.That(allServiceInfo, Is.EqualTo(null));
        }


        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
