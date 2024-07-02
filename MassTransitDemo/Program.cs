var builder = WebApplication.CreateBuilder();
var services = builder.Services;

services.AddMassTransit(x =>
{
	x.AddConsumers(typeof(Program).Assembly);
	x.UsingInMemory((ctx, cfg) => { cfg.ConfigureEndpoints(ctx); });
	x.UsingRabbitMq((ctx, cfg) =>
	{
		cfg.Host("localhost", "/", h =>
		{
			h.Username("guest");
			h.Password("guest");
		});
		cfg.ConfigureEndpoints(ctx);
	});
});

services.AddHostedService<PingPublisher>();

var app = builder.Build();

app.Run();