using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyWebProject.Core.Models.FactOfBulgaria;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Core.Services.Services;
using MyWebProject.Infrastructure.Data;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;

namespace TetstingAllProjects.TestServices
{
    [TestFixture]
    public class TestingFactService
    {
        private IFactsService? service;
        private ApplicationDbContext context;
        private readonly ILogger<FactsService> logger;


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
        public async Task TestMethodAdd_Insert_In_Database_Fact_Corectly()
        {
            var repo = new Repository(context);
            service = new FactsService(repo, logger);

            await repo.AddAsync(new InterestingFacts()
            {
                Id = 100,
                Description = "Fact of bulgarian history and natural",
                CategoryId = 8
            });

            var getNewFact = await repo.GetByIdAsync<InterestingFacts>(100);

            Assert.That(getNewFact.Description, Is.EqualTo("Fact of bulgarian history and natural"));
            Assert.That(getNewFact.CategoryId, Is.EqualTo(8));
        }


        [Test]
        public void Test_MethodAdd_Throw_Exeption_is_Moidel_NotValid()
        {
            var repo = new Repository(context);
            service = new FactsService(repo, logger);


            Assert.ThrowsAsync<NullReferenceException>(() => service.AddFacts(new FactOfCountry()
            {
                Id = 100,
                Description = "Fact of bulgarian history and natural",
                CategoryId = 20
            }));

            Assert.ThrowsAsync<NullReferenceException>(() => service.AddFacts(new FactOfCountry()
            {
                Id = 100,
                Description = " ",
                CategoryId = 4
            }));

            Assert.ThrowsAsync<NullReferenceException>(() => service.AddFacts(new FactOfCountry()
            {
                Id = 100,
                Description = null!,
                CategoryId = 4
            }));
        }

        [Test]
        public async Task TestMethodAdd_Insert_In_Database_Fact_Corectly_By_Service()
        {
            var repo = new Repository(context);
            service = new FactsService(repo, logger);

            await service.AddFacts(new FactOfCountry()
            {
                Id = 100,
                Description = "Fact of bulgarian history and natural",
                CategoryId = 8
            });


            var getNewFact = await service.GetFactById(100);

            Assert.That(getNewFact.Description, Is.EqualTo("Fact of bulgarian history and natural"));
            Assert.That(getNewFact.CategoryId, Is.EqualTo(8));
        }

        [Test]
        public async Task Test_Method_AllCategory_Return_Data_Corectly()
        {
            var repo = new Repository(context);
            service = new FactsService(repo, logger);

            var allCategoryOService = await service.AllCategory();

            var allDBCategory = await repo.AllReadonly<Category>().ToListAsync();

            Assert.That(allCategoryOService.Count(), Is.EqualTo(allDBCategory.Count()));
        }

        [Test]
        public async Task Test_Method_AllFacts_Return_Data_Corectly()
        {
            var repo = new Repository(context);
            service = new FactsService(repo, logger);

            var allFactsOService = await service.AllFacts();

            var allDBFacts = await repo.AllReadonly<InterestingFacts>().ToListAsync();

            Assert.That(allFactsOService.Count(), Is.EqualTo(allDBFacts.Count()));
        }

        [Test]
        public async Task TestMethod_Delete_Remove_Corectly_Facts()
        {
            var repo = new Repository(context);
            service = new FactsService(repo, logger);

            var all = await service.AllFacts();

            await service.AddFacts(new FactOfCountry()
            {
                Id = 100,
                Description = "Fact of bulgarian history and natural",
                CategoryId = 8
            });
            await repo.SaveChangesAsync();

            var getDelFact = await repo.AllReadonly<InterestingFacts>().ToListAsync();

            await service.Delete(100);

            Assert.That(all.Count(), Is.EqualTo(getDelFact.Count() - 1));
        }

        [Test]
        public void TestMethod_Delete_Throw_Exeption_If_Not_Found_ID()
        {
            var repo = new Repository(context);
            service = new FactsService(repo, logger);

            Assert.ThrowsAsync<ArgumentNullException>(async () => await service.Delete(-1));
        }

        [Test]
        public async Task Test_Edit_Method_Update_Proparty_of_Fact_Corectly()
        {
            var repo = new Repository(context);
            service = new FactsService(repo, logger);

            await repo.AddAsync(new InterestingFacts()
            {
                Id = 100,
                Description = "Since then Bulgaria is the only one that hasn’t changed its name. Despite " +
                "the fact that the country has been under Byzantine and Ottoman rule throughout its history, " +
                "the term Bulgaria has been used for over 1,300 years.",
                CategoryId = 7
            });

            await repo.SaveChangesAsync();

            await service.EditFact(new FactOfCountry()
            {
                Id = 100,
                Description = "Bulgaria has been used for over 1, 300 years",
                CategoryId = 8
            });

            var updatedFact = await repo.GetByIdAsync<InterestingFacts>(100);

            Assert.That(updatedFact.Description, Is.EqualTo("Bulgaria has been used for over 1, 300 years"));
            Assert.That(updatedFact.CategoryId, Is.EqualTo(8));
        }

        [Test]
        public async Task Test_Edit_Method_Throw_Exeption_If_InputModel_is_Not_Valid()
        {
            var repo = new Repository(context);
            service = new FactsService(repo, logger);

            await repo.AddAsync(new InterestingFacts()
            {
                Id = 100,
                Description = "Since then Bulgaria is the only one that hasn’t changed its name. Despite " +
                "the fact that the country has been under Byzantine and Ottoman rule throughout its history, " +
                "the term Bulgaria has been used for over 1,300 years.",
                CategoryId = 7
            });

            await repo.SaveChangesAsync();

            Assert.ThrowsAsync<NullReferenceException>(async () => await service.EditFact(new FactOfCountry()
            {
                Id = 101,
                Description = "Bulgaria has been used for over 1, 300 years",
                CategoryId = 60
            }));
        }


        /// <summary>
        /// test not run corectly
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Test_Edit_Method_Throw_Exeption_If_Save_Database()
        {
            var repo = new Repository(context);
            service = new FactsService(repo, logger);

            await repo.AddAsync(new InterestingFacts()
            {
                Id = 100,
                Description = "Since then Bulgaria is the only one that hasn’t changed its name. Despite " +
                "the fact that the country has been under Byzantine and Ottoman rule throughout its history, " +
                "the term Bulgaria has been used for over 1,300 years.",
                CategoryId = 7
            });

            await repo.SaveChangesAsync();

            Assert.ThrowsAsync<NullReferenceException>(async () => await service.EditFact(new FactOfCountry()
            {
                Id = 100,
                Description = string.Empty,
                CategoryId = -1
            }));
        }


        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
