using System.Reflection;
using UTMMAX.Service;

namespace UTMMAX.Files
{
    public class FileService : IFileService
    {
        public string GetImage(string path)
        {
            var imageArray = File.ReadAllBytes(path);
            return "data:image/jpg;base64," + Convert.ToBase64String(imageArray);
        }

        public string GenerateProfileIcon()
        {
            var rand                  = new Random();
            var imageDirectoryPath    = ProfileImageDirectoryPath();
            var allFilesFromDirectory = Directory.GetFiles(imageDirectoryPath, "*.png");
            var randomChosenImage     = allFilesFromDirectory[rand.Next(allFilesFromDirectory.Length)];

            return randomChosenImage;
        }

        private static string ProfileImageDirectoryPath()
        {
            var assemblyPath      = Assembly.GetExecutingAssembly().Location;
            var assemblyDirectory = Path.GetDirectoryName(assemblyPath);
            var directory         = new DirectoryInfo(assemblyDirectory);
            var filesPath         = Path.Combine(directory.FullName, "ProfileIcons");

            return filesPath;
        }
    }
}