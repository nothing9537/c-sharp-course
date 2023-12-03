using CookieCookbook.DataAccess.BaseRepository;
using System.Text.Json;

namespace CookieCookbok.DataAccess;

class JSONTextualRepository : BaseRepository
{
    public override List<string> Read(string filePath)
    {
        if (File.Exists(filePath))
        {
            var fileContent = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<string>>(fileContent)!;
        }

        return new List<string>();
    }

    public override void Write(string filePath, List<int> ids)
    {
        string dataToWrite = string.Join(',', ids);
        var existingData = Read(filePath);

        existingData.Add(dataToWrite);

        File.WriteAllText(filePath, JsonSerializer.Serialize(existingData));
    }
}