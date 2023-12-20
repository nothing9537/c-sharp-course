const string filePath = "sampleData.csv";

var data = new CsvReader().Read(filePath);

Console.ReadKey();
public class CsvReader
{
    private const string _separator = ",";
    public CsvData Read(string filePath)
    {
        using var streamReader = new StreamReader(filePath);

        var columns = streamReader.ReadLine()!.Split(_separator);
        var rows = new List<string[]>();

        while (!streamReader.EndOfStream)
        {
            var line = streamReader.ReadLine()!;
            var row = line.Split(_separator);

            rows.Add(row);
        }

        return new CsvData(columns, rows);
    }
}

public class CsvData
{
    public string[] Columns { get; }
    public IEnumerable<string[]> Rows { get; }

    public CsvData(string[] columns, IEnumerable<string[]> rows)
    {
        Columns = columns;
        Rows = rows;
    }
}