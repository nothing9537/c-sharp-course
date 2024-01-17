using System.Globalization;
using System.Text;
using TicketsDataAggregator.Extentions;
using TicketsDataAggregator.FileAccess;

namespace TicketsDataAggregator.TicketsAggregator;

public class TicketsAggregator
{
    private readonly string _ticketsFolder;
    private readonly string _outputFilename;
    private readonly IFileWriter _fileWriter;
    private readonly IDocumentsReader _documentsReader;
    private static readonly string[] _separator = ["Title:", "Date:", "Time:", "Visit us:"];
    private static readonly Dictionary<string, CultureInfo> _domainToCultureMap = new()
    {
        [".com"] = new CultureInfo("en-US"),
        [".fr"] = new CultureInfo("fr-FR"),
        [".jp"] = new CultureInfo("ja-JP"),
    };

    public TicketsAggregator(string ticketsFolder, string outputFilename, IFileWriter fileWriter, IDocumentsReader documentsReader)
    {
        _ticketsFolder = ticketsFolder;
        _outputFilename = outputFilename;
        _fileWriter = fileWriter;
        _documentsReader = documentsReader;
    }

    public void Run()
    {
        var stringBuilder = new StringBuilder();
        var ticketDocuments = _documentsReader.Read(_ticketsFolder, "*.pdf");

        foreach (var document in ticketDocuments)
        {
            var lines = ProcessDocument(document);

            stringBuilder.AppendLine(string.Join(Environment.NewLine, lines));
        }

        _fileWriter.Write(stringBuilder.ToString(), _ticketsFolder, _outputFilename);
    }

    private static IEnumerable<string> ProcessDocument(string document)
    {
        var split = document.Split(_separator, StringSplitOptions.None);

        var domain = split.Last().ExtractDomain();
        var cultureInfo = _domainToCultureMap[domain];

        for (int i = 1; i < split.Length - 3; i += 3)
        {
            yield return BuildTicketData(split, i, cultureInfo);
        }
    }

    private static string BuildTicketData(string[] split, int i, CultureInfo cultureInfo)
    {
        var title = split[i];
        var dateAsString = split[i + 1];
        var timeAsString = split[i + 2];

        var date = DateOnly.Parse(dateAsString, cultureInfo);
        var time = TimeOnly.Parse(timeAsString, cultureInfo);

        var dateAsStringInvariant = date.ToString(CultureInfo.InvariantCulture);
        var timeAsStringInvariant = time.ToString(CultureInfo.InvariantCulture);

        var ticketData = $"{title,-40}| {dateAsStringInvariant} | {timeAsStringInvariant}";

        return ticketData;
    }
}
