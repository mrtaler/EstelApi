namespace EstelApi.IntegrationTests.Base.Fixture.Collection
{
    using Xunit;

    [CollectionDefinition("service")]
    public class ServicesIntegrationFixtureCollection 
        : ICollectionFixture<ServicesInitializationFixture>
    {
    }
}