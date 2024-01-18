var weatherDataAggregator = new WeatherDataAggregator();
var weatherStation = new WeatherStation();
var weatherBaloon = new WeatherBaloon();

weatherStation.WeatherMeasured += weatherDataAggregator.GetNotifiedAboutNewData;
weatherBaloon.WeatherMeasured += weatherDataAggregator.GetNotifiedAboutNewData;

weatherStation.Measure();
weatherBaloon.Measure();

public record struct WeatherData(int? Temperature, int? Humidity);

public class WeatherDataAggregator
{
    public IEnumerable<WeatherData> WeatherHistory => _weatherHistory;
    private List<WeatherData> _weatherHistory = new();

    public void GetNotifiedAboutNewData(object? sender, WeatherDataEventArgs eventArgs)
    {
        _weatherHistory.Add(eventArgs.WeatherData);
    }
}


public class WeatherStation
{
    public event EventHandler<WeatherDataEventArgs>? WeatherMeasured;

    public void Measure()
    {
        int temperature = 25;

        OnWeatherMeasured(temperature);
    }

    private void OnWeatherMeasured(int data)
    {
        WeatherMeasured?.Invoke(this, new WeatherDataEventArgs(new WeatherData(data, null)));
    }
}

public class WeatherBaloon
{
    public event EventHandler<WeatherDataEventArgs>? WeatherMeasured;

    public void Measure()
    {
        int humidity = 50;

        OnWeatherMeasured(humidity);
    }

    private void OnWeatherMeasured(int data)
    {
        WeatherMeasured?.Invoke(this, new WeatherDataEventArgs(new WeatherData(null, data)));
    }
}

public class WeatherDataEventArgs : EventArgs
{
    public WeatherData WeatherData { get; }

    public WeatherDataEventArgs(WeatherData weatherData)
    {
        WeatherData = weatherData;
    }
}