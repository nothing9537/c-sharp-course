namespace TicketsDataAggregator.FileAccess;

public interface IDocumentsReader
{
    IEnumerable<string> Read(string folder, string fileTemplate);
}
