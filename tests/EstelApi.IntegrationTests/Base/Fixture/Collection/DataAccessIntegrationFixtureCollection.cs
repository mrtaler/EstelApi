namespace EstelApi.IntegrationTests.Base.Fixture.Collection
{
    using Xunit;

    [CollectionDefinition("DataAccess")]
    public class DataAccessIntegrationFixtureCollection
        : ICollectionFixture<DataAccessInitializationFixture>
    {
    }
}
