namespace EstelApi.IntegrationTests.Base.Fixture
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Reflection;

    using Autofac;
    using Autofac.Extensions.DependencyInjection;

    using Localization.IntegrationTests.Base;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;

    public sealed class ServerInitializationFixture<TStartup> : IInitializationFixture
        where TStartup : class
    {
        /// <summary>
        /// The _database manager.
        /// </summary>
        private readonly IDatabaseManager databaseManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerInitializationFixture{TStartup}"/> class.
        /// </summary>
        public ServerInitializationFixture()
        {
            var builder = new WebHostBuilder()
                .ConfigureServices(s => s.AddAutofac())
                .UseStartup<TStartup>();
            this.Server = new TestServer(builder);
            this.Container = GetContainer(this.Server.Host.Services);
            this.Client = this.Server.CreateClient();
            this.databaseManager = this.Container.Resolve<IDatabaseManager>();

            // Force all database interactions to be sequential
            GlobalLock.Database.Wait();
        }

        /// <summary>
        /// Gets or sets the server.
        /// </summary>
        public TestServer Server { get; set; }

        /// <summary>
        /// Gets the container.
        /// </summary>
        public IContainer Container { get; }

        /// <summary>
        /// Gets the client.
        /// </summary>
        public HttpClient Client { get; }

        /// <inheritdoc />
        public void Dispose()
        {
            this.Client.Dispose();
            this.Server.Dispose();
            this.databaseManager.Dispose();
            GlobalLock.Database.Release();
        }

        /// <summary>
        /// The get container.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="IContainer"/>.
        /// </returns>
        private static IContainer GetContainer(IServiceProvider value)
        {
            var startupComponentContext = value.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .SingleOrDefault(f => f.FieldType == typeof(IComponentContext));
            return (IContainer)startupComponentContext?.GetValue(value);
        }
    }
}