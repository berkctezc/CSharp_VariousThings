var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var services = builder.Services;

services.AddAWSService<IAmazonS3>(configuration.GetAWSOptions());
services.AddSingleton<IBucketRepository, BucketRepository>();
services.AddSingleton<IFilesRepository, FilesRepository>();

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(a => a.Run(async context =>
{
    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
    var exp = exceptionHandlerPathFeature?.Error;

    var result = JsonConvert.SerializeObject(new {error = exp?.Message});
    context.Response.ContentType = "application/json";
    await context.Response.WriteAsync(result);
}));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{
}