namespace RedisDemo.Data;

/*
 #run redis in container with name redis-docker and specified port
 docker run --name redis-docker -p 5002:6379 -d redis
 #redis-cli
 docker exec -it redis-docker sh
*/
public class WeatherForecastService
{
    private static readonly string[] Summaries =
    {
        "Freezing",
        "Bracing",
        "Chilly",
        "Cool",
        "Mild",
        "Warm",
        "Balmy",
        "Hot",
        "Sweltering",
        "Scorching",
    };

    public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
    {
        var rng = new Random();
        await Task.Delay(1500);
        return Enumerable
            .Range(1, 5)
            .Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
            })
            .ToArray();
    }
}
