namespace StarWarsPlanetsStats.Interfaces;

public interface IAPICaller
{
    Task<T> Fetch<T>(string baseUrl, string queryUrl) where T : class;
}
