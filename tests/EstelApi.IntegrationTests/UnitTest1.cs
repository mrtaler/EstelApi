namespace EstelApi.IntegrationTests
{
    using System.Threading.Tasks;

    using Autofac;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.IntegrationTests.Base.Fixture;
    using EstelApi.IntegrationTests.Base.Fixture.Collection;
    using EstelApi.IntegrationTests.Base.Infrastructure;

    using Serilog;

    using Xunit;
    using Xunit.Priority;

    [Collection("DataAccess")]
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class GetEntitiesFromDataAccessLayerTest : IntegrationTestBase
    {
        public GetEntitiesFromDataAccessLayerTest(DataAccessInitializationFixture initializationFixture)
              : base(initializationFixture)
        {
        }

        [Fact, Priority(0)]
        public async Task GetCulture_CultureExist_ReturnCultures()
        {
            Log.Information("FirstTest");
            var database = this.Container.Resolve<IUserRepository>();
            var entitiesFromDatabase = database.GetAll();
            Assert.NotEmpty(entitiesFromDatabase);
        }
    }
}
