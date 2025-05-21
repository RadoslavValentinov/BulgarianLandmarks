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

        public PictureService(IRepository _repo, ILogger<PictureService> _logger)
        {
            repo = _repo;
            logger = _logger;
        }

        /// <summary>
        /// Increments the like count of a picture by its ID.
        /// </summary>
        /// <param name="id">The ID of the picture.</param>
        /// <returns>The ID of the picture.</returns>
        [Authorize]
        public async Task<int> UpLikeCount(int id)
        {
            try
            {
                var resultSearch = repo.All<Pictures>().Where(x => x.Id == id).FirstOrDefault();

                if (resultSearch != null)
                {
                    resultSearch!.LikeCount++;

                    repo.Update(resultSearch);

                    await repo.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"An error occurred while updating the picture data: {ex.Message}");
                throw;
            }

            return id;
        }



        /// <summary>
        /// Adds a picture by user using a byte array.
        /// </summary>
        /// <param name="model">The model containing picture data.</param>
        /// <returns>The model with the added picture data.</returns>
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



        /// <summary>
        /// Adds a picture to the database.
        /// </summary>
        /// <param name="model">The model containing picture data.</param>
        /// <returns>The ID of the added picture.</returns>
        [Area("Administrator")]
        public async Task<int> AddPicture(AddPictureViewModel model)
        {
            try
            {
                var sanitizer = new HtmlSanitizer();
                string image = sanitizer.Sanitize(model.UrlImgAddres!);

                if (!string.IsNullOrWhiteSpace(image) || model.PictureData != null || !string.IsNullOrEmpty(image))
                {
                    var newPicture = new Pictures()
                    {
                        Id = model.Id,
                        UrlImgAddres = image,
                        LandMarkId = model.LandMark,
                        TownId = model.Town,
                        JourneyId = model.Journey,
                        UserName = model.UserName,
                        ArrayPicture = model.PictureData
                    };

                    await repo.AddAsync(newPicture);
                    var deleteItem = repo.DeleteAsync<PictureByUser>(model.Id);
                    await repo.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentNullException("This picture is not added");
                }
            }
            catch (ArgumentNullException ae)
            {
                logger.LogError(message: string.Format("Pictures not added"), ae);
            }

            return model.Id;
        }



        /// <summary>
        /// Adds a picture by user to the database.
        /// </summary>
        /// <param name="model">The model containing picture data.</param>
        /// <returns>The model with the added picture data.</returns>
        [Area("Administrator")]
        public async Task<AddPictureByUser> AddPictureByUser(AddPictureByUser model)
        {
            try
            {
                var sanitizer = new HtmlSanitizer();
                string image = sanitizer.Sanitize(model.UrlImgAddres!);

                if (!string.IsNullOrWhiteSpace(image) || model.PictureData != null)
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
                else
                {
                    throw new ArgumentNullException("This picture is not added");
                }
            }
            catch (ArgumentNullException ae)
            {
                logger.LogError(message: string.Format("Pictures not added"), ae);
            }

            return model;
        }



        /// <summary>
        /// Retrieves all active pictures.
        /// </summary>
        /// <returns>A collection of pictures.</returns>
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
                    UserName = x.UserName,
                    LikeCount = x.LikeCount,
                    PictureData = x.ArrayPicture
                })
                .ToListAsync();

            return all;
        }




        /// <summary>
        /// Retrieves all active pictures uploaded by users.
        /// </summary>
        /// <returns>A collection of pictures uploaded by users.</returns>
        public async Task<IEnumerable<PicturesViewModel>> AllPictureUploadByUsers()
        {
            var all = await repo.AllReadonly<Pictures>()
                .Where(z => z.UserName != null && z.IsActiv == true)
                .Select(x => new PicturesViewModel()
                {
                    Id = x.Id,
                    UrlImgAddres = x.UrlImgAddres,
                    IsActive = x.IsActiv,
                    UserName = x.UserName,
                    LikeCount = x.LikeCount,
                    PictureData = x.ArrayPicture
                })
                .ToListAsync();

            return all;
        }



        /// <summary>
        /// Retrieves all active pictures by user.
        /// </summary>
        /// <returns>A collection of pictures by user.</returns>
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
                    LikeCount = x.LikeCount,
                    PictureData = x.PictureData
                })
                .ToListAsync();

            return all;
        }

        /// <summary>
        /// Deletes a picture by its ID.
        /// </summary>
        /// <param name="Id">The ID of the picture to delete.</param>
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



        /// <summary>
        /// Deletes a picture uploaded by a user by its ID.
        /// </summary>
        /// <param name="Id">The ID of the picture to delete.</param>
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



        /// <summary>
        /// Edits a picture's details.
        /// </summary>
        /// <param name="model">The model containing updated picture data.</param>
        /// <returns>The updated picture model.</returns>
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

        /// <summary>
        /// Retrieves a picture uploaded by a user by its ID.
        /// </summary>
        /// <param name="id">The ID of the picture.</param>
        /// <returns>The picture uploaded by the user.</returns>
        public async Task<PictureByUser> GetByUserId(int id)
        {
            return await repo.GetByIdAsync<PictureByUser>(id);
        }




        /// <summary>
        /// Retrieves a picture by its ID.
        /// </summary>
        /// <param name="id">The ID of the picture.</param>
        /// <returns>The picture model.</returns>
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
                    LikeCount = x.LikeCount,
                    PictureData = x.ArrayPicture
                })
                .FirstAsync();
        }
    }
}