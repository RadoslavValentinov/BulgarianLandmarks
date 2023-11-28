﻿using Ganss.Xss;
using Microsoft.EntityFrameworkCore;
using MyWebProject.Core.Models.PictureModel;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Core.Services.Services;
using MyWebProject.Infrastructure.Data;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;

namespace TetstingAllProjects.TestServices
{
    [TestFixture]
    public class TestPictureService
    {
        private IPictureService service;
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
        public void TestMethod_Create_Trow_Exeption_of_Model_Not_Valid()
        {
            var repo = new Repository(context);
            service = new PictureService(repo);


            Assert.ThrowsAsync<ArgumentNullException>(async ()=> await service.AddPicture(new AddPictureViewModel()));
        }

        [Test]
        public void TestMethod_AddByUser_Trow_Exeption_of_Model_Not_Valid()
        {
            var repo = new Repository(context);
            service = new PictureService(repo);

            Assert.ThrowsAsync<ArgumentNullException>(async () => await service.AddPictureByUser(new AddPictureByUser()));
        }


        [Test]
        public async Task TestMethod_Create_Successfully_Added_Picture()
        {
            var repo = new Repository(context);
            service = new PictureService(repo);

            await service.AddPicture(new AddPictureViewModel()
            {
                Id = 200,
                UrlImgAddres = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSMOmtDqIJ11kMRKmRhlQngs6fuiDKj9fibe2z8p6Vl&s",
                LandMark = 4,
                Town = 2,
                Journey = 5
            });

            var getNewPicture = await service.GetById(200);
            var url = new HtmlSanitizer();

            Assert.That(getNewPicture.UrlImgAddres, Is.EqualTo(url.Sanitize("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSMOmtDqIJ11kMRKmRhlQngs6fuiDKj9fibe2z8p6Vl&s")));
            Assert.That(getNewPicture.Id, Is.EqualTo(200));
            Assert.That(getNewPicture.LandMark, Is.EqualTo(4));
            Assert.That(getNewPicture.Town, Is.EqualTo(2));
            Assert.That(getNewPicture.Journey, Is.EqualTo(5));
        }

        [Test]
        public async Task TestMethod_AddByUser_Successfully_Added_Picture_in_Database()
        {
            var repo = new Repository(context);
            service = new PictureService(repo);

            await service.AddPictureByUser(new AddPictureByUser()
            {
                Id = 100,
                UrlImgAddres = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSMOmtDqIJ11kMRKmRhlQngs6fuiDKj9fibe2z8p6Vl&s",
                UserName = "user",
            });

            var getNewPicture = await repo.GetByIdAsync<PictureByUser>(100);
            var url = new HtmlSanitizer();

            Assert.That(getNewPicture.UrlImgAddres, Is.EqualTo(url.Sanitize("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSMOmtDqIJ11kMRKmRhlQngs6fuiDKj9fibe2z8p6Vl&s")));
            Assert.That(getNewPicture.Id, Is.EqualTo(100));
            Assert.That(getNewPicture.UserName, Is.EqualTo("user"));
            Assert.That(getNewPicture.IsActive, Is.EqualTo(true));
           
        }


        [Test]
        public async Task TestMethod_AllPictures_Return_data_Corectly()
        {
            var repo = new Repository(context);
            service = new PictureService(repo);

            var allPictureService = await service.AllPicture();

           var dbAllPicture = await repo.AllReadonly<Pictures>().ToListAsync();

            Assert.That(allPictureService.Count(), Is.EqualTo(dbAllPicture.Count()));
        }

        [Test]
        public async Task TestMethod_AllPicturesByUser_Return_data_Corectly()
        {
            var repo = new Repository(context);
            service = new PictureService(repo);

            var allPictureService = await service.AllPictureByUser();

            var dbAllPictureByUser = await repo.AllReadonly<PictureByUser>().ToListAsync();

            Assert.That(allPictureService.Count(), Is.EqualTo(dbAllPictureByUser.Count()));
        }

        [Test]
        public async Task TestMethod_Delete_Remove_Picture_Successfully()
        {
            var repo = new Repository(context);
            service = new PictureService(repo);

            var allPictureService = await service.AllPicture();

            await service.AddPicture(new AddPictureViewModel()
            {
                Id = 200,
                UrlImgAddres = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSMOmtDqIJ11kMRKmRhlQngs6fuiDKj9fibe2z8p6Vl&s",
                LandMark = 4,
                Town = 2,
                Journey = 5
            });

            await service.Delete(200);

            var dbAllPicture = await repo.AllReadonly<Pictures>().ToListAsync();


            Assert.That(allPictureService.Count(), Is.EqualTo(dbAllPicture.Count()));
            Assert.That(await repo.GetByIdAsync<Pictures>(200), Is.EqualTo(null));
        }


        [Test]
        public async Task TestMethod_DeleteByUser_Remove_PictureByUser_Successfully()
        {
            var repo = new Repository(context);
            service = new PictureService(repo);

            var allPictureByUser = await service.AllPictureByUser();

            await service.AddPictureByUser(new AddPictureByUser()
            {
                Id = 30,
                UrlImgAddres = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSMOmtDqIJ11kMRKmRhlQngs6fuiDKj9fibe2z8p6Vl&s",
                UserName = "Test",
            });

            await service.DeleteByUser(30);

            var dbAllPictureByUser = await repo.AllReadonly<PictureByUser>().ToListAsync();


            Assert.That(allPictureByUser.Count(), Is.EqualTo(dbAllPictureByUser.Count()));
            Assert.That(await repo.GetByIdAsync<PictureByUser>(30), Is.EqualTo(null));
        }


        [Test]
        public void TestMethod_DeleteByUser_throw_Exeption_If_Id_Not_Found_Picture()
        {
            var repo = new Repository(context);
            service = new PictureService(repo);

            Assert.ThrowsAsync<NullReferenceException>(async () => await service.DeleteByUser(370));
        }




        [Test]
        public void TestMethod_Delete_throw_Exeption_If_Id_Not_Found()
        {
            var repo = new Repository(context);
            service = new PictureService(repo);

            Assert.ThrowsAsync<ArgumentNullException>(async ()=> await service.Delete(370));
        }


        [Test]
        public async Task TestMethod_Edit_Update_Info_Succsessfuly()
        {
            var repo = new Repository(context);
            service = new PictureService(repo);

            await service.AddPicture(new AddPictureViewModel()
            {
                Id = 200,
                UrlImgAddres = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSMOmtDqIJ11kMRKmRhlQngs6fuiDKj9fibe2z8p6Vl&s",
                LandMark = 4,
                Town = 2,
                Journey = 5
            });

            await service.EditPicture(new AddPictureViewModel()
            {
                Id = 200,
                UrlImgAddres = "https://media.istockphoto.com/id/615112296/photo/sofia-in-orange.jpg?s=2048x2048&w=is&k=20&c=C1KyGCCex6kLGAWT9e_h_hvathr03dLSYHtMjHN1mVg=",
                LandMark = 9,
                Town = 5,
                Journey = 5
            });

            var getUpdatedPicture = await service.GetById(200);

            var contains = new HtmlSanitizer();

            
            Assert.That(getUpdatedPicture.UrlImgAddres, Is.EqualTo(contains.Sanitize("https://media.istockphoto.com/id/615112296/photo/sofia-in-orange.jpg?s=2048x2048&w=is&k=20&c=C1KyGCCex6kLGAWT9e_h_hvathr03dLSYHtMjHN1mVg=")));
            Assert.That(getUpdatedPicture.LandMark, Is.EqualTo(9));
            Assert.That(getUpdatedPicture.Town, Is.EqualTo(5));
            Assert.That(getUpdatedPicture.Journey, Is.EqualTo(5));
        }

        [Test]
        public void TestMethod_Edit_Trow_Exeption_If_Model_is_Not_Valid()
        {
            var repo = new Repository(context);
            service = new PictureService(repo);

            Assert.ThrowsAsync<NullReferenceException>(async () => await service.EditPicture(new AddPictureViewModel()));
        }


        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
