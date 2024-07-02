namespace MassTransitDemo;

public class PingPublisher(IBus bus) : BackgroundService
{
	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		while (!stoppingToken.IsCancellationRequested)
		{
			await Task.Yield();

			var keyPressed = Console.ReadKey(true);
			if (keyPressed.Key != ConsoleKey.Q)
			{
				// _logger.LogInformation("Pressed {Button}",keyPressed.Key.ToString());
				await bus.Publish(new Ping(keyPressed.Key.ToString()), stoppingToken);
			}

			await Task.Delay(200, stoppingToken);
		}
	}
}