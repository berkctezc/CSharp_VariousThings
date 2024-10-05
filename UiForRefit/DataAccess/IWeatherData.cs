namespace UiForRefit.DataAccess;

public interface IWeatherData
{
    [Get("/WeatherForecast")]
    Task<List<WeatherForecast>?> GetWeather();
}
