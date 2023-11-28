using Microsoft.EntityFrameworkCore;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data;
using MyWebProject.Core.Services.Services;
using MyWebProject.Infrastructure.Data.Models;
using MyWebProject.Core.Models.CultureEventModel;

namespace TetstingAllProjects.TestServices
{
    [TestFixture]
    public class TestCultureEventService
    {
        private ICultureEventService services;
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
        public async Task TestMethod_AllEvents()
        {
            var repo = new Repository(context);
            services = new CultureEventService(repo);

            var dbAllEvent = await repo.AllReadonly<Cultural_events>().ToListAsync();
            var AllEventMethod = await services.AllEvent();

            Assert.That(dbAllEvent.Count(), Is.EqualTo(AllEventMethod.Count()));
        }

        [Test]
        public async Task TestMethod_Create_New_Eventl()
        {
            var repo = new Repository(context);
            services = new CultureEventService(repo);

            var dbAllEvent = await repo.AllReadonly<Cultural_events>().ToListAsync();
            var count = dbAllEvent.Count();

            var newEvent = new CultureEventViewModelByTownId()
            {
                Name = "Народни танци клуб Веселяци",
                Description = "Прецташлението ще се състои в зала Армеец",
                Date = "19-09-2023",
                Hour = "19:00",
                TownName = "Плевен",
                ImageURL = "https://ichef.bbci.co.uk/news/999/cpsprodpb/15951/production/_117310488_16.jpg",
            };

            await services.Create(newEvent);

            var AfterAdd = await repo.AllReadonly<Cultural_events>().ToListAsync();

            Assert.That(count + 1, Is.EqualTo(AfterAdd.Count()));
        }

        [Test]
        public void TestMethod_Createw_Eventl()
        {
            var repo = new Repository(context);
            services = new CultureEventService(repo);

            var newEvent = new CultureEventViewModelByTownId()
            {
                Name = "Народни танци клуб Веселяци",
                Description = "Прецташлението ще се състои в зала Армеец",
                Date = "19-09-2023",
                Hour = "19:00",
                TownName = "Уюиндол",
                ImageURL = "https://ichef.bbci.co.uk/news/999/cpsprodpb/15951/production/_117310488_16.jpg",
            };

            Assert.ThrowsAsync<ArgumentException>(async () => await services.Create(newEvent));
        }


        [Test]
        public async Task Test_Delete_Method_Remove_Event_Succssesfuly()
        {
            var repo = new Repository(context);
            services = new CultureEventService(repo);

            await repo.AddAsync(new Cultural_events()
            {
                Id = 25,
                Name = "Народни танци клуб Веселяци",
                Description = "Прецташлението ще се състои в зала Армеец",
                Date = "19-09-2023",
                Hour = "19:00",
                TownId = 5,
                ImageURL = "https://ichef.bbci.co.uk/news/999/cpsprodpb/15951/production/_117310488_16.jpg",
            });

            await repo.SaveChangesAsync();

            var itemDelite = await repo.GetByIdAsync<Cultural_events>(25);

            await services.Delete(itemDelite.Id);

            var allCategory = await services.AllEvent();
            var Delite = await repo.GetByIdAsync<Cultural_events>(25);

            Assert.That(allCategory.Count(), Is.EqualTo(15));
            Assert.That(Delite, Is.EqualTo(null));
        }

        [Test]
        public void Deleted_Method_Throw_Exeption_If_Not_Found_Event()
        {
            var repo = new Repository(context);
            services = new CultureEventService(repo);

            Assert.ThrowsAsync<NullReferenceException>(async () => await services.Delete(30));
            Assert.ThrowsAsync<NullReferenceException>(async () => await services.Delete(-1));
        }

        [Test]
        public async Task Test_Edit_Method_Update_Corectly_Event()
        {
            var repo = new Repository(context);
            services = new CultureEventService(repo);

            await repo.AddAsync(new Cultural_events()
            {
                Id = 25,
                Name = "Народни танци клуб Веселяци",
                Description = "Прецташлението ще се състои в зала Армеец",
                Date = "19-09-2023",
                Hour = "19:00",
                TownId = 5,
                ImageURL = "https://ichef.bbci.co.uk/news/999/cpsprodpb/15951/production/_117310488_16.jpg",
            });

            await repo.SaveChangesAsync();

            await services.Edit(new CultureEventViewModelByTownId()
            {
                Id = 25,
                Name = "културни Занимания",
                Description = "Изуюашане на традиците и обиюаите....",
                Date = "10-11-2023",
                Hour = "20:00",
                TownName = "Плевен",
                ImageURL = "https://ichef.bbci.co.uk/news/999/cpsprodpb/15951/production/_117310488_16.jpg"
            });

            var updatedEvent = await repo.GetByIdAsync<Cultural_events>(25);

            Assert.That(updatedEvent.Name, Is.EqualTo("културни Занимания"));
            Assert.That(updatedEvent.Description, Is.EqualTo("Изуюашане на традиците и обиюаите...."));
            Assert.That(updatedEvent.Date, Is.EqualTo("10-11-2023"));
            Assert.That(updatedEvent.Hour, Is.EqualTo("20:00"));
        }

        [Test]
        public async Task Test_Edit_Method_Throw_Exeption_Event()
        {
            var repo = new Repository(context);
            services = new CultureEventService(repo);

            await repo.AddAsync(new Cultural_events()
            {
                Id = 25,
                Name = "Народни танци клуб Веселяци",
                Description = "Прецташлението ще се състои в зала Армеец",
                Date = "19-09-2023",
                Hour = "19:00",
                TownId = 5,
                ImageURL = "https://ichef.bbci.co.uk/news/999/cpsprodpb/15951/production/_117310488_16.jpg",
            });

            await repo.SaveChangesAsync();

            Assert.ThrowsAsync<NullReferenceException>(async () => await services.Edit(new CultureEventViewModelByTownId()
            {
                Id = 25,
                Name = " ",
                Description = "Изуюашане на традиците и обиюаите....",
                Date = "10-11-2023",
                Hour = "20:00",
                TownName = "Плевен",
                ImageURL = "https://ichef.bbci.co.uk/news/999/cpsprodpb/15951/production/_117310488_16.jpg"
            }));
        }


        [Test]
        public async Task Test_Edit_Method_Throw_Exeption_Town_Count_is_Null()
        {
            var repo = new Repository(context);
            services = new CultureEventService(repo);

            await repo.AddAsync(new Cultural_events()
            {
                Id = 25,
                Name = "Народни танци клуб Веселяци",
                Description = "Прецташлението ще се състои в зала Армеец",
                Date = "19-09-2023",
                Hour = "19:00",
                TownId = 5,
                ImageURL = "https://ichef.bbci.co.uk/news/999/cpsprodpb/15951/production/_117310488_16.jpg",
            });

            await repo.SaveChangesAsync();

            Assert.ThrowsAsync<NullReferenceException>(async () => await services.Edit(new CultureEventViewModelByTownId()
            {
                Id = 25,
                Name = " ",
                Description = "Изуюашане на традиците и обиюаите....",
                Date = "10-11-2023",
                Hour = "20:00",
                TownName = "",
                ImageURL = "https://ichef.bbci.co.uk/news/999/cpsprodpb/15951/production/_117310488_16.jpg"
            }));
        }

        [Test]
        public async Task Test_Method_GetById_Reeturn_Corect_Model()
        {
            var repo = new Repository(context);
            services = new CultureEventService(repo);

            var all = await services.EventByTownId(4);

            Assert.That(all.Name, Is.EqualTo("Белослава 22 "));
        }


        [Test]
        public void Test_Method_GetById_Throw_Exeption_Not_Found()
        {
            var repo = new Repository(context);
            services = new CultureEventService(repo);

            Assert.ThrowsAsync<ArgumentNullException>(async () => await services.EventByTownId(29));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
