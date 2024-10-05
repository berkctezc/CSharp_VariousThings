var serviceProvider = new ServiceCollection()
    // .AddTransient<PrintToConsole.Handler>()
    .AddMediator(ServiceLifetime.Scoped, typeof(Program))
    .BuildServiceProvider();

// var handlerDetails = new Dictionary<Type, Type>()
// {
//     {typeof(PrintToConsole.Request), typeof(PrintToConsole.Handler)}
// };

var request = new PrintToConsole.Request("Hello from Mediator");

// IMediator mediator = new Mediator(serviceProvider.GetRequiredService, handlerDetails);
var mediator = serviceProvider.GetRequiredService<IMediator>();

await mediator.SendAsync(request);
