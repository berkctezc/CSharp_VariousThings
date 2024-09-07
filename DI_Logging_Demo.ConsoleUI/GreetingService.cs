using Microsoft.Extensions.Logging;

namespace DI_Logging_Demo.ConsoleUI;

public class GreetingService(ILogger<GreetingService> log, IConfiguration config) : IGreetingService
{
	private readonly int _loopTimes = config.GetValue<int>("LoopTimes");
	private readonly int _sleep = config.GetValue<int>("SleepDuration");

	public void Run()
	{
		for (var i = 0; i < _loopTimes; i++)
		{
			log.LogInformation("Run number {RunNumber}", i);
			Thread.Sleep(_sleep);
		}
	}
}
