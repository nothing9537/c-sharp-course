var weatherData = new WeatherData(25.1m, 65);
var weatherDataRecord = new WeatherDataRecord(25.1m, 65);

Console.WriteLine(weatherData); // Almost same result
Console.WriteLine(weatherDataRecord); // Almost same result

Console.ReadKey();

public record class WeatherDataRecord(decimal Temperature, int Humidity);
public record class WeatherDataRecordWithBody
{
    public decimal Temperature { get; }
    public int Humidity { get; }

    public WeatherDataRecordWithBody(decimal temperature, int humidity)
    {
        Temperature = temperature;
        Humidity = humidity;
    }
}

public class WeatherData : IEquatable<WeatherData>
{
    public decimal Temperature { get; }
    public int Humidity { get; }

    public WeatherData(decimal temperature, int humidity)
    {
        Temperature = temperature;
        Humidity = humidity;
    }

    public override string ToString() => $"Temperature: {Temperature}, Humidity: {Humidity}";

    public override bool Equals(object? obj)
    {
        return obj is WeatherData data && Equals(data);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Temperature, Humidity);
    }

    public bool Equals(WeatherData? other)
    {
        return Temperature == other!.Temperature && Humidity == other!.Humidity;
    }

    public static bool operator ==(WeatherData? left, WeatherData? right)
    {
        return EqualityComparer<WeatherData>.Default.Equals(left, right);
    }

    public static bool operator !=(WeatherData? left, WeatherData? right)
    {
        return !(left == right);
    }
}