namespace serialize.JSON;
public class Root
{
    public List <User> Users { get; set; }
    public List <string> Questions { get; set; }
    public List <string> Responses { get; set; }
    public Result Result { get; set; }
        
    public List<List<string>> UserResponses { get; set; }
}