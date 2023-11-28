namespace Names_SRP.DataAccess;

class StringsTextualRepository
{
    private static readonly string _separator = Environment.NewLine;
    public List<string> Read(string filePath)
    {
        var fileContents = File.ReadAllText(filePath);
        return fileContents.Split(_separator).ToList();
    }

    public void Write(
        string filePath,
        List<string> strings
        ) => File.WriteAllText(filePath, string.Join(_separator, strings));
}
