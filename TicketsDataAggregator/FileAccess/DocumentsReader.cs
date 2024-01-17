using UglyToad.PdfPig;

namespace TicketsDataAggregator.FileAccess;

public class DocumentsReader : IDocumentsReader
{
    public IEnumerable<string> Read(string folder, string fileTemplate)
    {
        foreach (var filePath in Directory.GetFiles(folder, fileTemplate))
        {
            using PdfDocument ticket = PdfDocument.Open(filePath);

            foreach (var page in ticket.GetPages())
            {
                yield return page.Text;
            }
        }
    }
}
