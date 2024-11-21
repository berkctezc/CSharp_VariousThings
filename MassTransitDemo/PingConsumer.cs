namespace MassTransitDemo;

public class PingConsumer(ILogger<PingConsumer> logger) : IConsumer<Ping>
{
	public Task Consume(ConsumeContext<Ping> context)
	{
		var button = context.Message.Button;
		logger.LogInformation("Button Pressed {Button}", button);

		return Task.CompletedTask;
	}
}