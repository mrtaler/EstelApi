namespace EstelApi.IntegrationTests.Base.Fixture.Collection
{
    using Autofac;

    using EstelApi.Domain.DataAccessLayer.Context.Context;
    using EstelApi.IntegrationTests.Base.Init;
    using EstelApi.IntegrationTests.Base.Settings;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;

    /// <inheritdoc />
    public class DataAccessInitializationFixture : IInitializationFixture
    {
        private readonly IDatabaseManager databaseManager;

        public DataAccessInitializationFixture()
        {
            this.Container = CreateContainer();
            this.databaseManager = this.Container.Resolve<IDatabaseManager>();
            
            // var dataAccessOptions = this.Container.Resolve<IOptionsSnapshot<DataAccessOptions>>();

            // Force all database interactions to be sequential
            GlobalLock.Database.Wait();
        }

        public IContainer Container { get; }

        /// <inheritdoc />
        public void Dispose()
        {
            this.databaseManager.Dispose();
            GlobalLock.Database.Release();
        }

        private static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            builder.Register(
                c =>
                    {
                        var dataAccessOptions = c.Resolve<IOptionsSnapshot<DataAccessOptions>>();
                        var dbContextBuilder = new DbContextOptionsBuilder<EstelContext>();

                        dbContextBuilder.UseSqlServer(dataAccessOptions.Value.DefaultConnection);

                        return dbContextBuilder.Options;
                    }); // DesignTimeDbContextFactory
            builder.RegisterModule<IntegrationTestsModule>();
            return builder.Build();
        }
    }
}