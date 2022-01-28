using System.Text.RegularExpressions;
using serialize.JSON;

namespace serialize;

using System.Text;
using System.Security.Cryptography;
public class Hash
{
    private static string ComputeSha256Hash(string rawData)
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

    public static bool ComparePAsswordHash(string? inputPassword, string? databaseHash)
    {
        return ComputeSha256Hash(inputPassword) == databaseHash;
    }

    public static void HashIfNotSecure()
    {
        var regex = new Regex("^[a-f0-9]{64}$");
        var datas = Serializer.Deserialize("databackup.json");
            // rechùerche les éléments de Users qui ne match pas avec la regex
        foreach (var user in datas.Users.Where(user => !regex.IsMatch(user.Password)))
        {
            Console.WriteLine("HASHING UNSAFE PASSWORD");
            user.Password = ComputeSha256Hash(user.Password);
        }
        Serializer.Serialize(datas,"databackup.json");
    }
}