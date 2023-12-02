using CookieCookbook.DataAccess.BaseRepository;
using System.Text.Json;

namespace CookieCookbok.DataAccess;

class JSONTextualRepository : BaseRepository
{
    public override List<int> Read(string filePath)
    {
        var result = new List<int>();
        var fileContent = File.ReadAllText(filePath);

        Console.WriteLine(fileContent);
        //return fileContent.Split(_separator).ToList();

        return result;
    }

    public override void Write(string filePath, List<int> data)
    {
        //var dataToJSON = JsonSerializer.Serialize(data);
        //File.WriteAllText(filePath, string.Join(_separator, dataToJSON));
    }
}