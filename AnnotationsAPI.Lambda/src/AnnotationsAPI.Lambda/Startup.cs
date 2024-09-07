namespace AnnotationsAPI.Lambda;

[LambdaStartup]
public class Startup
{
	public void ConfigureServices(IServiceCollection services)
	{
		var builder = new ConfigurationBuilder()
		// .AddSystemsManager("/app/settings")
		.AddJsonFile("appsettings.json", true);

		var configuration = builder.Build();
		services.AddSingleton<IConfiguration>(configuration);
	}
}
