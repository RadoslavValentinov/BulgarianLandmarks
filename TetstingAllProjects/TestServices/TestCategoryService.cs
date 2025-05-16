using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyWebProject.Core.Models.Category;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Core.Services.Services;
using MyWebProject.Infrastructure.Data;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;

namespace TetstingAllProjects.TestServices
{
    [TestFixture]
    public class TestCategoryService
    {
        private CategoryService? services;
        private ApplicationDbContext context;
        private readonly ILogger<CategoryService>? logger;

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
        public async Task TestNew_category()
        {
            var repo = new Repository(context);
            services = new CategoryService(repo, logger!);

            await repo.AddAsync(new Category()
            {
                Name = "Test"
            });

            await repo.SaveChangesAsync();
            var all = await services.AllCategory();

            Assert.That(all.Count(), Is.EqualTo(9));
        }

        [Test]
        public void TestMethod_Create_Added_Trow_Exeption_Empty_Model()
        {
            var repo = new Repository(context);
            services = new CategoryService(repo, logger!);

            Assert.ThrowsAsync<NullReferenceException>(async () => await services.CreateCategory(new CreateCategoryViewModel()));
        }

        [Test]
        public async Task TestMethod_Create_Added_New_Category_Correctly()
        {
            var repo = new Repository(context);
            services = new CategoryService(repo, logger!);

            var model = new CreateCategoryViewModel()
            {
                Name = "A predicate is therefore an expression that"
            };

            await repo.SaveChangesAsync();
            var result = await services.CreateCategory(model);

            Assert.That(result.Name, Is.EqualTo(model.Name));

            var all = await services.GetById(9);
            Assert.That(all.Id, Is.EqualTo(9));
        }

        [Test]
        public void TestMethod_Create_Added_Trow_Exeption()
        {
            var repo = new Repository(context);
            services = new CategoryService(repo, logger!);

            Assert.Multiple(() =>
            {
                Assert.ThrowsAsync<NullReferenceException>(async () => await services.CreateCategory(new CreateCategoryViewModel() { Name = null! }));
                Assert.ThrowsAsync<NullReferenceException>(async () => await services.CreateCategory(new CreateCategoryViewModel() { Name = " " }));
            });
        }

        [Test]
        public void TestMethod_Create_Aow_Exeption()
        {
            var repo = new Repository(context);
            services = new CategoryService(repo, logger!);

            Assert.ThrowsAsync<NullReferenceException>(async () => await services.CreateCategory(new CreateCategoryViewModel() { Name = string.Empty }));
        }

        [Test]
        public async Task TestMethod_Edit_Set_New_Value_Correctly()
        {
            var repo = new Repository(context);
            services = new CategoryService(repo, logger!);

            await repo.AddAsync(new Category()
            {
                Id = 9,
                Name = "OldName"
            });

            await repo.SaveChangesAsync();

            await services.EditCategory(new CategoryViewModel()
            {
                Id = 9,
                Name = "NewName"
            });

            var dbHouse = await repo.GetByIdAsync<Category>(9);

            Assert.That(dbHouse.Name, Is.EqualTo("NewName"));
        }

        [Test]
        public async Task TestMethod_Edit_Method_Throw_Exeption()
        {
            var repo = new Repository(context);
            services = new CategoryService(repo, logger!);

            await repo.AddAsync(new Category()
            {
                Id = 9,
                Name = "OldName"
            });

            await repo.SaveChangesAsync();

            Assert.ThrowsAsync<NullReferenceException>(async () => await services.EditCategory(new CategoryViewModel() { Id = 9, Name = null! }));
            Assert.ThrowsAsync<NullReferenceException>(async () => await services.EditCategory(new CategoryViewModel() { Id = 9, Name = " " }));
        }

        [Test]
        public async Task Test_Delete_Category()
        {
            var repo = new Repository(context);
            services = new CategoryService(repo, logger!);

            await repo.AddAsync(new Category()
            {
                Id = 9,
                Name = "Deleted"
            });

            await repo.SaveChangesAsync();

            var itemDelite = await repo.GetByIdAsync<Category>(9);

            await services.Delete(itemDelite.Id);

            var allCategory = await services.AllCategory();
            var Delite = await repo.GetByIdAsync<Category>(9);

            Assert.Multiple(() =>
            {
                Assert.That(allCategory.Count(), Is.EqualTo(8));
                Assert.That(Delite, Is.EqualTo(null));
            });
        }

        [Test]
        public void TestDeleteIfCategoryIsNull()
        {
            var repo = new Repository(context);
            services = new CategoryService(repo, logger!);

            Assert.ThrowsAsync<NullReferenceException>(async () => await services.Delete(16));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}