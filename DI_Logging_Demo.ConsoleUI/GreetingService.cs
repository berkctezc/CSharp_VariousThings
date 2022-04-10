using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DI_Logging_Demo.ConsoleUI;

public class GreetingService : IGreetingService
{
    private readonly ILogger<GreetingService> _log;
    private readonly int _loopTimes;
    private readonly int _sleep;

    public GreetingService(ILogger<GreetingService> log, IConfiguration config)
    {
        _log = log;

        _loopTimes = config.GetValue<int>("LoopTimes");
        _sleep = config.GetValue<int>("SleepDuration");
    }

    public void Run()
    {
        for (var i = 0; i < _loopTimes; i++)
        {
            _log.LogInformation("Run number {RunNumber}", i);
            Thread.Sleep(_sleep);
        }
    }
}