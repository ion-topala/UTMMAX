namespace UTMMAX.Service;

public interface IPasswordService
{
    string CreatePassword(int length);
    bool   IsPasswordEqual(string plainPassword, string hashPassword);
    string HashPassword(string plainPassword);
}