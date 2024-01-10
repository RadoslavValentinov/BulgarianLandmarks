using Ganss.Xss;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebProject.Core.Models.PictureModel;
using MyWebProject.Core.Services.IServices;
using MyWebProject.Infrastructure.Data.Common;
using MyWebProject.Infrastructure.Data.Models;

namespace MyWebProject.Core.Services.Services
{
    [Authorize]
    public class PictureService : IPictureService
    {

        private readonly IRepository repo;
        private  UserManager<Users> user;
     
        public PictureService(IRepository _repo)
        {
            repo = _repo;
        }


        [Area("Administrator")]
        public async Task<int> AddPicture(AddPictureViewModel model)
        {

            try
            {
                var sanitizer = new HtmlSanitizer();

                string image = sanitizer.Sanitize(model.UrlImgAddres);

                if (string.IsNullOrWhiteSpace(image))
                {
                    throw new ArgumentNullException("Pictures Url Connot by Empty");
                }

                var newPicture = new Pictures()
                {
                    Id = model.Id,
                    UrlImgAddres = image,
                    LandMarkId = model.LandMark,
                    TownId = model.Town,
                    JourneyId = model.Journey,
                    UserName = model.UserName
                };

                await repo.AddAsync(newPicture);
                await repo.SaveChangesAsync();

                return newPicture.Id;
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Pictures not added");
            }
        }

        [Area("Administrator")]
        public async Task<AddPictureByUser> AddPictureByUser(AddPictureByUser model)
        {
            try
            {
                var sanitizer = new HtmlSanitizer();

                string image = sanitizer.Sanitize(model.UrlImgAddres);

                if (string.IsNullOrWhiteSpace(image))
                {
                    throw new ArgumentNullException("Pictures Url Connot by Empty");
                }


                var newPicture = new PictureByUser()
                {
                    Id = model.Id,
                    UrlImgAddres = image,
                    UserName =model.UserName,
                };
              
                await repo.AddAsync(newPicture);
                await repo.SaveChangesAsync();

            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Pictures not added");
            }

            return model;
        }

        public async Task<IEnumerable<PicturesViewModel>> AllPicture()
        {
            var all = await repo.AllReadonly<Pictures>()
                .Include(x => x.LandMark)
                .Include(x => x.Town)
                .Include(x => x.Journey)
                .Select(x => new PicturesViewModel()
                {
                    Id = x.Id,
                    UrlImgAddres = x.UrlImgAddres,
                    IsActive = x.IsActiv,
                    LandMark = x.LandMark.Name,
                    Town = x.Town.Name,
                    Journey = x.Journey.Name
                })
                .ToListAsync();

            return all;
        }

        [Area("Administrator")]
        public async Task<IEnumerable<AddPictureByUser>> AllPictureByUser()
        {
            var all = await repo.AllReadonly<PictureByUser>()
                .Where(p => p.IsActive == true)
                .Select(x => new AddPictureByUser()
                {
                    Id = x.Id,
                    UrlImgAddres = x.UrlImgAddres,
                    UserName = x.UserName,
                })
                .ToListAsync();

            return all;
        }



        [Area("Administrator")]
        public async Task Delete(int Id)
        {
            try
            {
                var deletedItem = await repo.GetByIdAsync<Pictures>(Id);

                repo.Delete(deletedItem);
                await repo.SaveChangesAsync();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("This picture is not deleted");
            }
        }

        [Area("Administrator")]
        public async Task DeleteByUser(int Id)
        {
            try
            {
                var deletedItem = await repo.GetByIdAsync<PictureByUser>(Id);

                await repo.DeleteAsync<PictureByUser>(deletedItem.Id);
                await repo.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new NullReferenceException("This picture is not deleted");
            }
        }

        [Area("Administrator")]
        public async Task<AddPictureViewModel> EditPicture(AddPictureViewModel model)
        {
            var sanitizer = new HtmlSanitizer();

            string Image = sanitizer.Sanitize(model.UrlImgAddres);

            try
            {
                var editPictures = await repo.GetByIdAsync<Pictures>(model.Id);
                editPictures.UrlImgAddres = Image;

                if (model.LandMark != null)
                {
                    var land = await repo.GetByIdAsync<LandMark>(model.LandMark);
                    land.Pictures.Add(editPictures);
                }
                editPictures.LandMarkId = model.LandMark;

                if (model.Town != null)
                {
                    var town = await repo.GetByIdAsync<Town>(model.Town);
                    town.Picture.Add(editPictures);
                }
                editPictures.TownId = model.Town;

                if (model.Journey != null)
                {
                    var journey = await repo.GetByIdAsync<Journeys>(model.Journey);
                    journey.pictures.Add(editPictures);
                }
                editPictures.JourneyId = model.Journey;

                repo.Update(editPictures);
                await repo.SaveChangesAsync();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("No updated this picture");
            }

            return model;
        }

        public async Task<AddPictureViewModel> GetById(int id)
        {
            return await repo.AllReadonly<Pictures>()
                .Where(x => x.Id == id)
                .Include(x => x.Town)
                .Include(x => x.LandMark)
                .Include(x => x.Journey)
                .Select(x => new AddPictureViewModel()
                {
                    Id = id,
                    UrlImgAddres = x.UrlImgAddres,
                    LandMark = x.LandMarkId,
                    Town = x.TownId,
                    Journey = x.JourneyId
                })
                .FirstAsync();
        }
    }
}
