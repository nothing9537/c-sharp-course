namespace TicketsDataAggregator.FileAccess;

public class FileWriter : IFileWriter
{
    public void Write(string content, params string[] pathParts)
    {
        var resPath = Path.Combine(pathParts);
        File.WriteAllText(resPath, content);
        Console.WriteLine($"Result saved to: {resPath}");
    }
}
