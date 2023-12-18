using CookieCookbook.DataAccess.BaseRepository;
namespace CookieCookbok.DataAccess;

class StringsTextualRepository : IBaseRepository
{
    private readonly static string _separator = Environment.NewLine;
    public List<string> Read(string filePath)
    {
        if (File.Exists(filePath))
        {
            return File.ReadAllText(filePath).Split(_separator).ToList();
        }

        return [];
    }
    public void Write(string filePath, List<int> ids)
    {
        string dataToWrite = string.Join(',', ids);
        var existingData = Read(filePath);

        existingData.Add(dataToWrite);

        File.WriteAllText(filePath, string.Join(_separator, existingData));
    }
}
