using TicketsDataAggregator.FileAccess;
using TicketsDataAggregator.TicketsAggregator;

const string TICKETS_FOLDER = "Tickets";
const string OUTPUT_FILENAME = "aggregatedTickets.txt";

try
{
    var ticketsAggregator = new TicketsAggregator(TICKETS_FOLDER, OUTPUT_FILENAME, new FileWriter(), new DocumentsReader());

    ticketsAggregator.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"An exception occured. Exception message: {ex.Message}");
}

Console.ReadKey();
