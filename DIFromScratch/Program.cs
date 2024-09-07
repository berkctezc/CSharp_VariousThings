var services = new DiServiceCollection();

// services.RegisterSingleton(new GetUnixTime());
// services.RegisterSingleton<GetUnixTime>();

// services.RegisterTransient<GetUnixTime>();
// services.RegisterTransient<ISomeService, SomeServiceOne>();
services.RegisterSingleton<ISomeService, SomeServiceOne>();
services.RegisterTransient<IRandomGuidProvider, RandomGuidProvider>();

services.RegisterSingleton<MainApp>();

var container = services.Build();

var service1 = container.GetService<ISomeService>();
Thread.Sleep(1000);
var service2 = container.GetService<ISomeService>();

var mainApp = container.GetService<MainApp>();

await MainApp.StartAsync();

service1.PrintGuid();
service2.PrintGuid();
