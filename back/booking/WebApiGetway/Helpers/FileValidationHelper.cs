using Globals.Exceptions;

namespace WebApiGetway.Helpers
{
    public static class FileValidationHelper
    {
        private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long MaxFileSize = 5 * 1024 * 1024; // 5 MB

        public static void ValidateFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ValidationException("Файл пустой");

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!AllowedExtensions.Contains(extension))
                throw new ValidationException($"Недопустимый формат файла: {extension}");

            if (file.Length > MaxFileSize)
                throw new ValidationException($"Файл слишком большой: {file.Length} байт (макс {MaxFileSize})");
        }

        public static void ValidateFiles(IEnumerable<IFormFile> files)
        {
            if (files == null || !files.Any())
                throw new ValidationException("Файлы не переданы");

            foreach (var file in files)
            {
                ValidateFile(file);
            }
        }
    }
}
