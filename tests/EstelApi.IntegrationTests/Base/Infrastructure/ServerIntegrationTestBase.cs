namespace EstelApi.IntegrationTests.Base.Infrastructure
{
    using System.Net.Http;

    using EstelApi.IntegrationTests.Base.Fixture;

    using Microsoft.AspNetCore.TestHost;

    public abstract class ServerIntegrationTestBase<TStartup> : IntegrationTestBase
        where TStartup : class
    {
        /// <inheritdoc />
        protected ServerIntegrationTestBase(ServerInitializationFixture<TStartup> initializationFixture)
            : base(initializationFixture)
        {
            this.Client = initializationFixture.Client;
            this.Server = initializationFixture.Server;
        }

        /// <summary>
        /// Gets the client.
        /// </summary>
        protected HttpClient Client { get; }

        /// <summary>
        /// Gets the server.
        /// </summary>
        protected TestServer Server { get; }
    }
}