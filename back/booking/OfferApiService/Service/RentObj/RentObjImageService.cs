using Globals.Sevices;
using Microsoft.EntityFrameworkCore;
using OfferApiService.Models;
using OfferApiService.Models.RentObjModel;
using System;




namespace OfferApiService.Services.Interfaces.RentObj
{
    public class RentObjImageService : TableServiceBaseNew<RentObjImage, OfferContext>, IRentObjImageService
    {

        private readonly IWebHostEnvironment _env;

        public RentObjImageService(
            OfferContext context,
            ILogger<RentObjImageService> logger,
            IWebHostEnvironment env) : base(context, logger)
        {
            _env = env;
        }

        //==================================================================================================================

       

        //public RentObjImageService(IWebHostEnvironment env ) : base()
        //{
        //    _env = env;
        //}


        public async Task<string> SaveImageAsync(IFormFile file, int rentObjId)
        {
            if (file == null || file.Length == 0)
            {
                _logger.LogWarning("Attempted to save an empty file for RentObjId {RentObjId}", rentObjId);
                throw new ArgumentException("File is empty", nameof(file));
            }


            string folder = Path.Combine(_env.WebRootPath, "images", "rentobj", rentObjId.ToString());
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
                _logger.LogInformation("Created folder for images: {Folder}", folder);
            }

            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            string fullPath = Path.Combine(folder, fileName);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                _logger.LogInformation("File {FullPath} overwritten", fullPath);
            }


            await using (var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                await file.CopyToAsync(fs);
            }

            string url = $"/images/rentobj/{rentObjId}/{fileName}";

            var rentObjImage = new RentObjImage
            {
                RentObjId = rentObjId,
                Url = url
            };
            _context.RentObjImages.Add(rentObjImage);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Image for RentObjId {RentObjId} saved with Url {Url}", rentObjId, url);
            return url;
        }



        //==================================================================================================================


        public async Task<bool> DeleteImageAsync(int imageId)
        {
            var image = await _context.RentObjImages.FirstOrDefaultAsync(i => i.id == imageId);
            if (image == null)
            {
                _logger.LogWarning("Attempted to delete a non-existing image with Id {ImageId}", imageId);
                return false;
            }

            string physicalPath = Path.Combine(_env.WebRootPath, image.Url.TrimStart('/'));

            if (File.Exists(physicalPath))
            {
                try
                {
                    File.Delete(physicalPath);
                    _logger.LogInformation("Image file {Path} deleted", physicalPath);
                }
                catch (IOException ex)
                {
                    _logger.LogError(ex, "Failed to delete image file {Path}", physicalPath);
                }
            }

            _context.RentObjImages.Remove(image);
            await _context.SaveChangesAsync();
            _logger.LogInformation("RentObjImage entity with Id {ImageId} deleted from database", imageId);


            string? folder = Path.GetDirectoryName(physicalPath);
            if (folder != null && Directory.Exists(folder) && !Directory.EnumerateFileSystemEntries(folder).Any())
            {
                Directory.Delete(folder);
                _logger.LogInformation("Empty folder {Folder} deleted", folder);
            }

            return true;
        }


        //==================================================================================================================



        public async Task<bool> UpdateImageAsync(int imageId, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                _logger.LogWarning("Attempted to update image with Id {ImageId} using an empty file", imageId);
                return false;
            }


            var image = await _context.RentObjImages.FirstOrDefaultAsync(i => i.id == imageId);
            if (image == null)
            {
                _logger.LogWarning("Image with Id {ImageId} not found for update", imageId);
                return false;
            }

            string oldPath = Path.Combine(_env.WebRootPath, image.Url.TrimStart('/'));

            if (File.Exists(oldPath))
            {
                try
                {
                    File.Delete(oldPath);
                    _logger.LogInformation("Old image file {Path} deleted", oldPath);
                }
                catch (IOException ex)
                {
                    _logger.LogError(ex, "Error deleting old image file {Path}", oldPath);
                }
            }

            string folder = Path.Combine(_env.WebRootPath, "images", "rentobj", image.RentObjId.ToString());
            Directory.CreateDirectory(folder);

            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            string newPath = Path.Combine(folder, fileName);

            await using (var fs = new FileStream(newPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                await file.CopyToAsync(fs);
            }

            image.Url = $"/images/rentobj/{image.RentObjId}/{fileName}";
            await _context.SaveChangesAsync();

            _logger.LogInformation("Image with Id {ImageId} updated, new Url {Url}", imageId, image.Url);
            return true;
        }


    }
}
