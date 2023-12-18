using CookieCookbook.DataAccess.BaseRepository;
using System.Text.Json;

namespace CookieCookbok.DataAccess;

class JSONTextualRepository : IBaseRepository
{
    public List<string> Read(string filePath)
    {
        if (File.Exists(filePath))
        {
            var fileContent = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<string>>(fileContent)!;
        }

        return [];
    }

    public void Write(string filePath, List<int> ids)
    {
        string dataToWrite = string.Join(',', ids);
        var existingData = Read(filePath);

        existingData.Add(dataToWrite);

        File.WriteAllText(filePath, JsonSerializer.Serialize(existingData));
    }
}