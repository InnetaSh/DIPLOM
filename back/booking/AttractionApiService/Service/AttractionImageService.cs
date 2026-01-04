using AttractionApiService.Models;
using AttractionApiService.Service.Interfaces;
using Globals.Sevices;
using Microsoft.EntityFrameworkCore;
using System;

namespace AttractionApiService.Service
{
    public class AttractionImageService : TableServiceBase<AttractionImage, AttractionContext>, IAttractionImageService
    {

        private readonly IWebHostEnvironment _env;

        public AttractionImageService(IWebHostEnvironment env ) : base()
        {
            _env = env;
        }


        public async Task<string> SaveImageAsync(IFormFile file, int attractionId)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Файл пустой", nameof(file));

            string folder = Path.Combine(_env.WebRootPath, "images", "attraction", attractionId.ToString());
            Directory.CreateDirectory(folder);

            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            string fullPath = Path.Combine(folder, fileName);

           
            await using (var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                await file.CopyToAsync(fs);
            }

            string url = $"/images/rentobj/{attractionId}/{fileName}";

            await using var db = new AttractionContext();
            var attractionImage = new AttractionImage
            {
                AttractionId = attractionId,
                Url = url
            };
            db.AttractionImages.Add(attractionImage);
            await db.SaveChangesAsync();

            return url;
        }



        public async Task<bool> DeleteImageAsync(int imageId)
        {
            await using var db = new AttractionContext();
            var image = await db.AttractionImages.FirstOrDefaultAsync(i => i.id == imageId);
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

            db.AttractionImages.Remove(image);
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

            await using var db = new AttractionContext();
            var image = await db.AttractionImages.FirstOrDefaultAsync(i => i.id == imageId);
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

            string folder = Path.Combine(_env.WebRootPath, "images", "rentobj", image.AttractionId.ToString());
            Directory.CreateDirectory(folder);

            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            string newPath = Path.Combine(folder, fileName);

            await using (var fs = new FileStream(newPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                await file.CopyToAsync(fs);
            }

            image.Url = $"/images/rentobj/{image.AttractionId}/{fileName}";
            await db.SaveChangesAsync();

            return true;
        }


    }
}
