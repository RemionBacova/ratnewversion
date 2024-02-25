using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RatServer.Core.Configurations;
using Serilog;
using System;
using System.IO;
using System.Threading.Tasks;

namespace RatServer
{
    public class Program
    {
        protected Program()
        {

        }

        [Obsolete]
        public static async Task Main(string[] args)
        {
            Log.Logger = SerilogConfigurator.CreateLogger();

            try
            {
                Log.Logger.Information("Starting up");
                _ = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddEnvironmentVariables()
                                    .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
                                    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
                                    .Build();
                using IHost webHost = CreateWebHostBuilder(args).Build();
                await webHost.RunAsync();
            }
            catch (Exception ex)
            {
                Log.Logger.Fatal(ex, "Application start-up failed");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        [Obsolete]
        public static IHostBuilder CreateWebHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    _ = webBuilder.UseStartup<Startup>()
                    .CaptureStartupErrors(true);
                }).UseSerilog((hostingContext, loggerConfiguration) =>
                {
                    string logConfigurationValue = hostingContext.Configuration.GetSection("LogConfig").Value;
                    if (logConfigurationValue == "Console")
                    {
                        string outputTemplate = hostingContext.Configuration.GetSection("Serilog:WriteToConsole:outputTemplate").Value;
                        _ = loggerConfiguration
                          .ReadFrom.Configuration(hostingContext.Configuration)
                          .WriteTo.Console(Serilog.Events.LogEventLevel.Information, outputTemplate);
                    }
                    else if (logConfigurationValue == "File")
                    {
                        string pathFormat = hostingContext.Configuration.GetSection("Serilog:WriteToFile:pathFormat").Value.Replace("{Date}", DateTime.Now.ToString("yyyy_MM_dd_HH_mm"));
                        string outputTemplate = hostingContext.Configuration.GetSection("Serilog:WriteToFile:outputTemplate").Value;
                        string rollingInterval = hostingContext.Configuration.GetSection("Serilog:WriteToFile:rollingInterval").Value;
                        string flushToDiskInterval = hostingContext.Configuration.GetSection("Serilog:WriteToFile:fileSizeLimitBytes").Value;
                        string rollOnFileSizeLimit = hostingContext.Configuration.GetSection("Serilog:WriteToFile:rollOnFileSizeLimit").Value;
                        string retainedFileCountLimit = hostingContext.Configuration.GetSection("Serilog:WriteToFile:retainedFileCountLimit").Value;

                        _ = loggerConfiguration
                        .ReadFrom.Configuration(hostingContext.Configuration)
                        .WriteTo.File(pathFormat, Serilog.Events.LogEventLevel.Information, outputTemplate);
                    }
                    else
                    {
                        _ = loggerConfiguration
                      .ReadFrom.Configuration(hostingContext.Configuration)
                      .WriteTo.ApplicationInsights(new TelemetryConfiguration { InstrumentationKey = hostingContext.Configuration.GetSection("ApplicationInsights:InstrumentationKey").Value }, TelemetryConverter.Traces);
                    }
                });
        }
    }

}
