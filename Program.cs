using System.Text.Json;

namespace serialize;

internal class Program
{
    private static void Main(string[] args)
    {
        /*
         * File.ReadAllLines("data.json");
         * serializeJSon
         */
        /*
         * Menu/mdp 
         */ 
        var data = File.ReadAllText("data.json");
        var root = JsonSerializer.Deserialize<Root>(data) ?? throw new InvalidOperationException("Error no json");
    }
}