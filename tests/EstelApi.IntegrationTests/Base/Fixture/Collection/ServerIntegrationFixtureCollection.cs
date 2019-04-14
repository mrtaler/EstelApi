namespace EstelApi.IntegrationTests.Base.Fixture.Collection
{
    using EstelApi.IntegrationTests.Base.Infrastructure;

    using Xunit;

    [CollectionDefinition("server")]
    public class ServerIntegrationFixtureCollection 
        : ICollectionFixture<ServerInitializationFixture<IntegrationTestsStartup>>
    {
    }
}