using System.Reflection;
using UTMMAX.Service;

namespace UTMMAX.Files
{
    public class FileService : IFileService
    {
        public byte[] GetImage(string path)
        {
            return File.ReadAllBytes(path);
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