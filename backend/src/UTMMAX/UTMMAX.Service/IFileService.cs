namespace UTMMAX.Service
{
    public interface IFileService
    {
        string GenerateProfileIcon();
        byte[] GetImage(string path);
    }
}