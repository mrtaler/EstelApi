﻿using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Estel.Services.Api
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                //.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console(
                    theme: Serilog.Sinks.SystemConsole.Themes.AnsiConsoleTheme.Code,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level}:{EventId} [{SourceContext}] {Message}{NewLine}{Exception}")
                .CreateLogger();
            try
            {
                Log.Information("Starting web host");
                CreateWebHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseSerilog()
                .UseKestrel()
                .ConfigureAppConfiguration(
                    (hostingContext, config) =>
                    {
                        config.SetBasePath(Directory.GetCurrentDirectory());
                        config.AddJsonFile("appsettings.json", false, true);
                        config.AddCommandLine(args);
                        config.AddEnvironmentVariables();
                    })
                .UseApplicationInsights()
                .UseIISIntegration()
                .UseStartup<Startup>();
    }
}
