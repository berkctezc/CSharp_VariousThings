namespace WorkerService_Microsoft;

public class Program
{
	public static void Main(string[] args)
	{
		Log.Logger = new LoggerConfiguration()
			.MinimumLevel.Debug()
			.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
			.WriteTo.File(@"C:\temp\workerservice\LogFile.txt")
			.CreateLogger();

		try
		{
			Log.Information("starting up");
			CreateHostBuilder(args).Build().Run();
		}
		catch (Exception e)
		{
			Log.Fatal(e, "Problem");
			throw;
		}
		finally
		{
			Log.CloseAndFlush();
		}
	}

	public static IHostBuilder CreateHostBuilder(string[] args)
	{
		return Host.CreateDefaultBuilder(args)
			.UseWindowsService()
			.ConfigureServices((hostContext, services) => { services.AddHostedService<Worker>(); })
			.UseSerilog();
	}
}