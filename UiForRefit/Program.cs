using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Refit;
using UiForRefit;
using UiForRefit.DataAccess;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
builder.Services.AddRefitClient<IGuestData>().ConfigureHttpClient(c =>
{
    c.BaseAddress = new Uri("https://localhost:5001/api");
});


await builder.Build().RunAsync();