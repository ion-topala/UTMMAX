using System.Text;
using BCryptNet = BCrypt.Net.BCrypt;

namespace UTMMAX.Service;

public class PasswordService : IPasswordService
{
    public string CreatePassword(int length)
    {
        const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        var          res   = new StringBuilder();
        var          rnd   = new Random();
        while (0 < length--)
        {
            res.Append(valid[rnd.Next(valid.Length)]);
        }

        return res.ToString();
    }

    public bool IsPasswordEqual(string plainPassword, string hashPassword)
    {
        return BCryptNet.Verify(plainPassword, hashPassword);
    }

    public string HashPassword(string plainPassword)
    {
        return BCrypt.Net.BCrypt.HashPassword(plainPassword);
    }
}