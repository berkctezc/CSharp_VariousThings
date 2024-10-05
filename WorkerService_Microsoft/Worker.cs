namespace WorkerService_Microsoft;

public class Worker(ILogger<Worker> logger) : BackgroundService
{
    private HttpClient client;

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        client = new HttpClient();
        return base.StartAsync(cancellationToken);
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        client.Dispose();
        logger.LogInformation("Service has been stopped...");
        return base.StopAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var result = await client.GetAsync("https://www.google.com/", stoppingToken);

            if (result.IsSuccessStatusCode)
                logger.LogInformation(
                    "Website is up. {StatusCode} at {time}",
                    result.StatusCode,
                    DateTimeOffset.Now
                );
            else
                logger.LogError("Website is down. {StatusCode}", result.StatusCode);

            //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(2000, stoppingToken);
        }
    }
}
