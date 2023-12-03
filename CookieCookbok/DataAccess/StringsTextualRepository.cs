using CookieCookbook.DataAccess.BaseRepository;
namespace CookieCookbok.DataAccess;

class StringsTextualRepository : BaseRepository
{
    public override List<string> Read(string filePath)
    {
        if (File.Exists(filePath))
        {
            return File.ReadAllText(filePath).Split(_separator).ToList();
        }

        return new List<string>();
    }
    public override void Write(string filePath, List<int> ids)
    {
        string dataToWrite = string.Join(',', ids);
        var existingData = Read(filePath);

        existingData.Add(dataToWrite);

        File.WriteAllText(filePath, string.Join(_separator, existingData));
    }
}
