namespace Bilet1.Extensions.FileManagmentExtensions
{
    public static class FileManagerExtension
    {
        public static bool IsTrueContent(this IFormFile formFile)
        {
            if (formFile.ContentType.Contains("image"))
            {
                return true;
            }
            return false;
        }
        public static bool IsValidLength(this IFormFile formFile)
        {
            if (formFile.Length <= 2 * 1024 * 1024)
            {
                return true;
            }
            return false;
        }
        public static string SaveUrl(this IFormFile formFile,string root,string folderPath)
        {
            string imageUrl = " ";
            if (formFile.FileName.Length >= 64)
            {
                imageUrl = $"{Guid.NewGuid().ToString()}{formFile.FileName.Substring(formFile.FileName.Length - 64, 64)}";
            }
            else
            {
                imageUrl = $"{Guid.NewGuid().ToString()}{formFile.FileName}";
            }
            string path = Path.Combine(root, folderPath, imageUrl);
            using (FileStream filestream = new FileStream(path, FileMode.Create))
            {
                formFile.CopyTo(filestream);
            }
            return imageUrl;
        }
        public static void DeleteFile(string root, string folderPath, string imageurl)
        {
            string path = Path.Combine(root, folderPath, imageurl);
            if (File.Exists(path))
            {
                File.Delete(path);

            }
        }
    }
}
