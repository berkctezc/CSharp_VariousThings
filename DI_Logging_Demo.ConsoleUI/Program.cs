// Main

var builder = new ConfigurationBuilder();
BuildConfig(builder);

Log.Logger = new LoggerConfiguration()
	.ReadFrom.Configuration(builder.Build())
	.Enrich.FromLogContext()
	.WriteTo.Console()
	.CreateLogger();

Log.Logger.Information("Application Starting");

var host = Host.CreateDefaultBuilder()
	.ConfigureServices((_, serviceCollection) => { serviceCollection.AddTransient<IGreetingService, GreetingService>(); })
	.UseSerilog()
	.Build();

var svc = ActivatorUtilities.CreateInstance<GreetingService>(host.Services);
svc.Run();


static void BuildConfig(IConfigurationBuilder builder)
{
	builder.SetBasePath(Directory.GetCurrentDirectory())
		.AddJsonFile("appsettings.json", false, true)
		.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true);
}
