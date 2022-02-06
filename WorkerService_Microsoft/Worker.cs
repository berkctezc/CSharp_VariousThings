using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerService_Microsoft;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private HttpClient client;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        client = new HttpClient();
        return base.StartAsync(cancellationToken);
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        client.Dispose();
        _logger.LogInformation("Service has been stopped...");
        return base.StopAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var result = await client.GetAsync("https://www.google.com/", stoppingToken);

            if (result.IsSuccessStatusCode)
                _logger.LogInformation("Website is up. {StatusCode} at {time}", result.StatusCode, DateTimeOffset.Now);
            else
                _logger.LogError("Website is down. {StatusCode}", result.StatusCode);

            //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(2000, stoppingToken);
        }
    }
}