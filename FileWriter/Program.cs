const string filePath = "file.txt";

using var writer = new FileWriter(filePath);

writer.Write("some text");
writer.Write("some other text");

using var reader = new SpecificLineFromTextFileReader(filePath);

var third = reader.ReadLineNumber(3);
var fourth = reader.ReadLineNumber(4);

Console.WriteLine($"Third line is: {third}");
Console.WriteLine($"Fourth line is: {fourth}");

Console.ReadKey();
public class FileWriter : IDisposable
{
    private readonly StreamWriter _streamWriter;

    public FileWriter(string filePath)
    {
        _streamWriter = new StreamWriter(filePath, true);
    }

    public void Dispose()
    {
        _streamWriter.Dispose();
    }

    public void Write(string text)
    {
        _streamWriter.WriteLine(text);
        _streamWriter.Flush();
    }
}

public class SpecificLineFromTextFileReader : IDisposable
{
    private readonly StreamReader _streamReader;

    public SpecificLineFromTextFileReader(string filePath)
    {
        _streamReader = new StreamReader(filePath);
    }

    public void Dispose()
    {
        _streamReader.Dispose();
    }

    public string ReadLineNumber(int lineNumber)
    {
        _streamReader.DiscardBufferedData();
        _streamReader.BaseStream.Seek(0, SeekOrigin.Begin);

        for (int i = 0; i < lineNumber - 1; i++)
        {
            _streamReader.ReadLine();
        }

        return _streamReader.ReadLine()!;
    }
}