/*
 * setup aws-lambda-tools-defaults.json config
 * cd into project
 * dotnet lambda deploy-function
 * make requests
 * https://gia7xkajou4g7nunnhhratiwxi0kzdux.lambda-url.eu-central-1.on.aws/
 */

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add AWS Lambda support. When application is run in Lambda Kestrel is swapped out as the web server with Amazon.Lambda.AspNetCoreServer. This
// package will act as the webserver translating request and responses between the Lambda event source and ASP.NET Core.
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi); // changed from RestApi

var app = builder.Build();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => "Welcome to running ASP.NET Core Minimal API on AWS Lambda");

app.Run();
