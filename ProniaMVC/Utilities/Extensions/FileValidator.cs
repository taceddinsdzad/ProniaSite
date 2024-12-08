using ProniaMVC.Utilities.Enums;

namespace ProniaMVC.Utilities.Extensions
{
    public static class FileValidator
    {
        public static bool ValidateType(this IFormFile file, string type)
        {
            if (file.ContentType.Contains(type))
            {
                return true;
            }
            return false;
        }
        public static bool ValidateSize(this IFormFile file, FileSize fileSize, int size)
        {
            switch (fileSize)
            {
                case FileSize.Kb:
                    return file.Length <= size * 1024;
                case FileSize.Mb:
                    return file.Length <= size * 1024 * 1024;
                case FileSize.Gb:
                    return file.Length <= size * 1024 * 1024 * 1024;

            }
            return false;

        }
        public static async Task<string> CreateFileAsync(this IFormFile file, params string[] roots)
        {
            int lastDotIndex = file.FileName.LastIndexOf(".");
            string fileName = Guid.NewGuid().ToString().Substring(0, 15) + file.FileName.Substring(lastDotIndex, (file.FileName.Length - lastDotIndex));




            using (FileStream fileStream = new(fileName.GeneratePath(roots), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return fileName;
        }
        public static void DeleteFile(this string fileName, params string[] roots)
        {
            File.Delete(fileName.GeneratePath(roots));
        }

        private static string GeneratePath(this string fileName, params string[] roots)
        {
            string path = string.Empty;
            for (int i = 0; i < roots.Length; i++)
            {
                path = Path.Combine(path, roots[i]);
            }
            path = Path.Combine(path, fileName);
            return path;
        }


    }
}
