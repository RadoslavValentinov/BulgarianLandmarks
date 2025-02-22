using Ganss.Xss;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<PictureService> logger;

        public PictureService(IRepository _repo,
            ILogger<PictureService> _logger)
        {
            repo = _repo;
            logger = _logger;
        }


        [Authorize]
        public async Task<AddPictureByUser> PictureByByteArray(AddPictureByUser model)
        {
            var picture = new PictureByUser
            {
                UserName = model.UserName,
                IsActive = model.IsActive,
                PictureData = model.PictureData 
            };

            await repo.AddAsync(picture);
            await repo.SaveChangesAsync();

            return model;
        }



        [Area("Administrator")]
        public async Task<int> AddPicture(AddPictureViewModel model)
        {

            try
            {
                var sanitizer = new HtmlSanitizer();

                string image = sanitizer.Sanitize(model.UrlImgAddres!);

                if (string.IsNullOrWhiteSpace(image) && model.PictureData != null)
                {
                    var newPicture = new Pictures()
                    {
                     
                        UrlImgAddres = image,
                        LandMarkId = model.LandMark,
                        TownId = model.Town,
                        JourneyId = model.Journey,
                        UserName = model.UserName,
                        ArrayPicture = model.PictureData
                    };

                    await repo.AddAsync(newPicture);
                    await repo.SaveChangesAsync();
                }


            }
            catch (ArgumentNullException ae)
            {
                logger.LogError(message: string.Format("Pictures not added"), ae);
            }

            return model.Id;
        }

        [Area("Administrator")]
        public async Task<AddPictureByUser> AddPictureByUser(AddPictureByUser model)
        {
            try
            {
                var sanitizer = new HtmlSanitizer();

                string image = sanitizer.Sanitize(model.UrlImgAddres!);

                if (string.IsNullOrWhiteSpace(image) && model.PictureData != null)
                {

                    var newPicture = new PictureByUser()
                    {
                        Id = model.Id,
                        UrlImgAddres = image,
                        UserName = model.UserName,
                        PictureData = model.PictureData
                    };

                    await repo.AddAsync(newPicture);
                    await repo.SaveChangesAsync();
                }

            }
            catch (ArgumentNullException ae)
            {
                logger.LogError(message: string.Format("Pictures not added"), ae);
            }

            return model;
        }

        public async Task<IEnumerable<PicturesViewModel>> AllPicture()
        {
            var all = await repo.AllReadonly<Pictures>()
                .Include(x => x.LandMark)
                .Include(x => x.Town)
                .Include(x => x.Journey)
                .Where(z => z.IsActiv == true)
                .Select(x => new PicturesViewModel()
                {
                    Id = x.Id,
                    UrlImgAddres = x.UrlImgAddres,
                    IsActive = x.IsActiv,
                    LandMark = x.LandMark!.Name,
                    Town = x.Town!.Name,
                    Journey = x.Journey!.Name,
                    UserName= x.UserName,
                    PictureData = x.ArrayPicture
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
                    PictureData = x.PictureData
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
            catch (ArgumentNullException ae)
            {
                logger.LogError(message: string.Format("This picture is not deleted"), ae);
            }
        }

        [Area("Administrator")]
        public async Task DeleteByUser(int Id)
        {
            var deletedItem = await repo.GetByIdAsync<PictureByUser>(Id);

            if (deletedItem == null)
            {
                throw new NullReferenceException("This picture is not deleted");
            }

            try
            {
                await repo.DeleteAsync<PictureByUser>(deletedItem.Id);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(string.Format("This picture is not deleted"), ex);
            }
        }

        [Area("Administrator")]
        public async Task<AddPictureViewModel> EditPicture(AddPictureViewModel model)
        {
            var sanitizer = new HtmlSanitizer();

            string Image = sanitizer.Sanitize(model.UrlImgAddres!);

            var editPictures = await repo.GetByIdAsync<Pictures>(model.Id);

            if (editPictures == null)
            {
                throw new NullReferenceException("No updated this picture");
            }


            try
            {
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
            catch (NullReferenceException ne)
            {
                logger.LogError(string.Format("No updated this picture"), ne);
            }

            return model;
        }

        public async Task<PictureByUser> GetByUserId(int id)
        {
            return await repo.GetByIdAsync<PictureByUser>(id);
        }




        public async Task<AddPictureViewModel> GetById(int id)
        {
            return await repo.AllReadonly<Pictures>()
                .Where(x => x.Id == id && x.IsActiv == true)
                .Include(x => x.Town)
                .Include(x => x.LandMark)
                .Include(x => x.Journey)
                .Select(x => new AddPictureViewModel()
                {
                    Id = id,
                    UrlImgAddres = x.UrlImgAddres,
                    LandMark = x.LandMarkId,
                    Town = x.TownId,
                    Journey = x.JourneyId,
                    PictureData = x.ArrayPicture
                })
                .FirstAsync();
        }


        public async Task<IEnumerable< AddPictureViewModel>> AllPictureOfUserUpload()
        {
            var allPicture = await repo.AllReadonly<Pictures>()
                .Where(x => x.UserName != null)
                .Select(x => new AddPictureViewModel()
                {
                    Id = x.Id,
                    UrlImgAddres = x.UrlImgAddres,
                    LandMark = x.LandMarkId,
                    Town = x.TownId,
                    Journey = x.JourneyId,
                    PictureData = x.ArrayPicture,
                    UserName = x.UserName

                }).ToListAsync();

            return allPicture;
        }
    }
}
