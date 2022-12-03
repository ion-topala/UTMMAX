using System.Reflection;
using UTMMAX.Service;

namespace UTMMAX.Files
{
    public class FileService : IFileService
    {
        public string GetAvatarIcon()
        {
            var rand                  = new Random();
            var path                  = ProfileImageDirectoryPath();
            var allFilesFromDirectory = Directory.GetFiles(path, "*.png");
            var randomChosenImage     = allFilesFromDirectory[rand.Next(allFilesFromDirectory.Length)];

            var imageArray                = File.ReadAllBytes(randomChosenImage);
            var base64ImageRepresentation = Convert.ToBase64String(imageArray);

            return base64ImageRepresentation;
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