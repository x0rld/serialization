using System.Text.Json;

namespace serialize.JSON;

public class Serializer
{
    public static Root Deserialize(string path)
    {
        return JsonSerializer.Deserialize<Root>(File.ReadAllText(path)) ?? throw new InvalidOperationException("Error no json");
    }

    public static void Serialize(Root classToJson,string path)
    {
        using var writer = new StreamWriter(path);
        writer.Write(JsonSerializer.Serialize(classToJson));
    }
}