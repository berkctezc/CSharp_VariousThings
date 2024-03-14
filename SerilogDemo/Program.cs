namespace SerilogDemo;

public static class Program
{
	public static void Main(string[] args)
	{
		var configuration = new ConfigurationBuilder()
			.AddJsonFile("appsettings.json")
			.Build();

		Log.Logger = new LoggerConfiguration()
			.ReadFrom.Configuration(configuration)
			.CreateLogger();


		try
		{
			Log.Information("Application Starting Up");
			CreateHostBuilder(args).Build().Run();
		}
		catch (Exception ex)
		{
			Log.Fatal(ex, "application failed to start correctly");
		}
		finally
		{
			Log.CloseAndFlush();
		}
	}

	public static IHostBuilder CreateHostBuilder(string[] args)
	{
		return Host.CreateDefaultBuilder(args)
			.UseSerilog()
			.ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
	}
}
