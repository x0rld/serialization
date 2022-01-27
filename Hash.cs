using System.Text.RegularExpressions;

namespace serialize;

using System.Text;
using System.Security.Cryptography;
public class Hash
{
    public static string ComputeSha256Hash(string rawData)
    {
        using var sha256Hash = SHA256.Create();
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));  
        // Convert byte array to a string
        var hash = new StringBuilder();  
        foreach (var b in bytes)
        {
            hash.Append(b.ToString("x2"));
        }
        return hash.ToString();
    }

    public static bool ComparePAsswordHash(string inputPassword, string databaseHash)
    {
        return ComputeSha256Hash(inputPassword) == databaseHash;
    }

    public static void HashIfNotSecure()
    {
        var regex = new Regex("^[a-f0-9]{64}$");
        var datas = Serializer.Deserialize("databackup.json");
        foreach (var user in datas.Users)
        {
            if (regex.IsMatch(user.Password))
            {
               user.Password = ComputeSha256Hash(user.Password);
            }
            Serializer.Serialize(datas,"databackup.json");
        }
    }
}