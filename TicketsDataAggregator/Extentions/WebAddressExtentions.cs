namespace TicketsDataAggregator.Extentions;

public static class WebAddressExtentions
{
    public static string ExtractDomain(this string webAddress)
    {
        var lastDotIndex = webAddress.LastIndexOf('.');

        return webAddress[lastDotIndex..];
    }
}