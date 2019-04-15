using System;

namespace EstelApi.IntegrationTests.Base.Init
{
    using Autofac;
    using Microsoft.Extensions.Configuration;
    using System.IO;
    using System.Linq;

    using EstelApi.CrossCutting.IoC;
    using EstelApi.IntegrationTests.Base.Settings;

    using Microsoft.Extensions.Options;

    using Serilog;
    using Serilog.Sinks.SystemConsole.Themes;

    internal class IntegrationTestsModule : Module
    {
        private static readonly IConfigurationRoot TestConfiguration =
            new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("testsettings.json")
                .AddEnvironmentVariables("LAIntegration:")
                .Build();
        private static readonly IConfigurationRoot AppConfiguration =
            new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables("LA:")
                .Build();

        static IntegrationTestsModule()
        {
            var rootPath = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent;
            var logFilePath = Path.Combine(rootPath.FullName, "logs", "la-integrationTests-.log");

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Verbose()
                .WriteTo.Console(
                    theme: AnsiConsoleTheme.Code,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Test}] [{Level}] {Message}{NewLine}{Exception}")
                .WriteTo.File(
                    logFilePath,
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Test}] [{Level}] {Message}{NewLine}{Exception}")
                .CreateLogger();

            PrintConfiguration("test", TestConfiguration);
            PrintConfiguration("app", AppConfiguration);
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .Register(_ => GetDatabaseManager())
                .As<IDatabaseManager>()
                .SingleInstance();
            builder.Register(_ => GetDataAccessOptions())
                .As<IOptionsSnapshot<DataAccessOptions>>()
                .SingleInstance();

            builder
                .Register(_ => GetMssqlOptions())
                .As<IOptionsSnapshot<MssqlDatabaseSettings>>()
                .SingleInstance();

            builder.RegisterModule<EstelApiCrossCuttingIoC>();
        }

        private static void PrintConfiguration(string target, IConfiguration configuration)
        {
            var allConfiguration = string.Join(
                Environment.NewLine,
                configuration.AsEnumerable().Select(conf => $"{conf.Key} = {conf.Value}").OrderBy(c => c));
            Log.Debug("Using {Target} configuration:\n{Configuration:l}", target, allConfiguration);
        }

        private static IDatabaseManager GetDatabaseManager()
        {
            var serverConfig = TestConfiguration.GetSection("ConnectionStrings").Get<DataAccessOptions>();
            return new DatabaseManagerMultiplexer(
                serverConfig.DefaultConnection,
                serverConfig.DatabaseName);
        }

        private static IOptionsSnapshot<DataAccessOptions> GetDataAccessOptions()
        {
            var settings = TestConfiguration.GetSection("ConnectionStrings").Get<DataAccessOptions>();
            return new DataAccessOptionsOptions(settings);
        }

        private static IOptionsSnapshot<MssqlDatabaseSettings> GetMssqlOptions()
        {
            var settings = AppConfiguration.GetSection("Databases").Get<MssqlDatabaseSettings>();
            return new TestMssqlDatabaseOptions(settings);
        }
    }
}
