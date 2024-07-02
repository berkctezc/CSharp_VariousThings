namespace DynamoDb_MovieRank.IntegrationTests.Setup;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
	protected override void ConfigureWebHost(IWebHostBuilder builder)
	{
		builder.ConfigureTestServices(services =>
			services.AddSingleton<IAmazonDynamoDB>(cc =>
			{
				var clientConfig = new AmazonDynamoDBConfig { ServiceURL = "http://localhost:8000" };
				return new AmazonDynamoDBClient(clientConfig);
			}));
	}
}