var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddControllers();
services.AddAWSService<IAmazonDynamoDB>();
services.AddDefaultAWSOptions(
	new AWSOptions
	{
		Region = RegionEndpoint.EUCentral1
	});

services.AddSingleton<IMovieRankService, MovieRankService>();
services.AddSingleton<IMovieRankRepository, MovieRankRepository>();
services.AddSingleton<IMapper, Mapper>();
services.AddSingleton<ISetupService, SetupService>();


services.AddSwaggerGen();

var app = builder.Build();
var env = builder.Environment;

if (env.IsDevelopment())
{
	app.UseDeveloperExceptionPage();

	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseRouting();

app.UseEndpoints(e => { e.MapControllers(); });

app.Run();

namespace DynamoDb_MovieRank
{
	public partial class Program
	{
	}
}
