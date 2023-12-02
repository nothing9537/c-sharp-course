using CookieCookbook.DataAccess.BaseRepository;
namespace CookieCookbok.DataAccess;

class StringsTextualRepository : BaseRepository
{
    public override List<int> Read(string filePath)
    {
        List<int> list = new List<int>();

        var fileContent = File.ReadAllText(filePath);

        //return fileContent.Split(_separator).ToList();

        return list;
    }
    public override void Write(string filePath, List<int> ids)
    {
        string dataToWrite = string.Join(',', ids);
        string fileData = File.ReadAllText(filePath);
        var existingData = fileData.Split(_separator).ToList();

        existingData.Add(dataToWrite);

        File.WriteAllText(filePath, string.Join(_separator, existingData));
    }
}
