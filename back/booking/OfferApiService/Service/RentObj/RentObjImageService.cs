using Globals.Sevices;
using Microsoft.EntityFrameworkCore;
using OfferApiService.Models;
using OfferApiService.Models.RentObjModel;
using System;




namespace OfferApiService.Services.Interfaces.RentObj
{
    public class RentObjImageService : TableServiceBase<RentObjImage, OfferContext>, IRentObjImageService
    {

        private readonly IWebHostEnvironment _env;

        public RentObjImageService(IWebHostEnvironment env ) : base()
        {
            _env = env;
        }


        public async Task<string> SaveImageAsync(IFormFile file, int rentObjId)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Файл пустой", nameof(file));

            string folder = Path.Combine(_env.WebRootPath, "images", "rentobj", rentObjId.ToString());
            Directory.CreateDirectory(folder);

            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            string fullPath = Path.Combine(folder, fileName);

           
            await using (var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                await file.CopyToAsync(fs);
            }

            string url = $"/images/rentobj/{rentObjId}/{fileName}";

            await using var db = new OfferContext();
            var rentObjImage = new RentObjImage
            {
                RentObjId = rentObjId,
                Url = url
            };
            db.RentObjImages.Add(rentObjImage);
            await db.SaveChangesAsync();

            return url;
        }



        public async Task<bool> DeleteImageAsync(int imageId)
        {
            await using var db = new OfferContext();
            var image = await db.RentObjImages.FirstOrDefaultAsync(i => i.id == imageId);
            if (image == null) return false;

            string physicalPath = Path.Combine(_env.WebRootPath, image.Url.TrimStart('/'));

            if (File.Exists(physicalPath))
            {
                try { File.Delete(physicalPath); }
                catch (IOException ex)
                {
                    Console.WriteLine($"Не удалось удалить файл: {ex.Message}");
                }
            }

            db.RentObjImages.Remove(image);
            await db.SaveChangesAsync();

            string? folder = Path.GetDirectoryName(physicalPath);
            if (folder != null && Directory.Exists(folder) && !Directory.EnumerateFileSystemEntries(folder).Any())
                Directory.Delete(folder);

            return true;
        }




        public async Task<bool> UpdateImageAsync(int imageId, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return false;

            await using var db = new OfferContext();
            var image = await db.RentObjImages.FirstOrDefaultAsync(i => i.id == imageId);
            if (image == null) return false;

            string oldPath = Path.Combine(_env.WebRootPath, image.Url.TrimStart('/'));

            if (File.Exists(oldPath))
            {
                try { File.Delete(oldPath); }
                catch (IOException ex)
                {
                    Console.WriteLine($"Ошибка при удалении старого файла: {ex.Message}");
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
            await db.SaveChangesAsync();

            return true;
        }


    }
}
