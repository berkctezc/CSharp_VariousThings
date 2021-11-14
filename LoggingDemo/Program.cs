using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var logger = host.Services.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("Application has started");
            host.Run();
        }

        // Levels of Log
        /*
        - Trace: Lowest level, for heavy debugging. very detailed 
        - Debug: Detailed but not as low as Trace
        - Information: More friendly way to see the flow of the application
        - Warning: Exception like issues
        - Error: Unhandled things like crash and things we cannot fix
        - Critical: Only most critical level logs

        - Customize in appsettings.json to show
        */

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                // ILogger Configuration
                .ConfigureLogging((context, logging) =>
                {
                    logging.ClearProviders();
                    logging.AddConfiguration(context.Configuration.GetSection("Logging")); // Gets Configuration from appsettings.json
                    logging.AddDebug();
                    logging.AddConsole(); // EventSource, EventLog, TraceSource, AzureAppServicesFile, AzureAppServicesBlob
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
