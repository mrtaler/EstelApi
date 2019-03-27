namespace EstelApi.IntegrationTests.Base.Fixture.Collection
{
    using Autofac;

    using EstelApi.IntegrationTests.Base.Init;

    using Localization.IntegrationTests.Base;

   public class DataAccessInitializationFixture : IInitializationFixture
    {
        private readonly IDatabaseManager _databaseManager;

        public DataAccessInitializationFixture()
        {
            this.Container = CreateContainer();
            this._databaseManager = this.Container.Resolve<IDatabaseManager>();

            //    var dataAccessOptions = this.Container.Resolve<IOptionsSnapshot<DataAccessOptions>>();

            // Force all database interactions to be sequential
            GlobalLock.Database.Wait();
        }

        public IContainer Container { get; }

        /// <inheritdoc />
        public void Dispose()
        {
            this._databaseManager.Dispose();
            GlobalLock.Database.Release();
        }

        private static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<IntegrationTestsModule>();
            return builder.Build();
        }
    }
}