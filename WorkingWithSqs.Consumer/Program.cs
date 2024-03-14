var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<SqsConsumerService>();
builder.Services.AddSingleton<IAmazonSQS>(_ => new AmazonSQSClient(RegionEndpoint.EUCentral1));

builder.Services.AddSingleton<MessageDispatcher>();

// builder.Services.AddScoped<CustomerCreatedHandler>();
// builder.Services.AddScoped<CustomerDeletedHandler>();

builder.Services.AddMessageHandlers();

var app = builder.Build();

app.Run();
