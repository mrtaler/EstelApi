namespace EstelApi.IntegrationTests.Base.Fixture
{
    using Autofac;

    using EstelApi.IntegrationTests.Base.Init;

    using Localization.IntegrationTests.Base;

    public sealed class ServicesInitializationFixture : IInitializationFixture
    {
        private readonly IDatabaseManager databaseManager;

        public ServicesInitializationFixture()
        {
            this.Container = CreateContainer();
            this.databaseManager = this.Container.Resolve<IDatabaseManager>();

            // Force all database interactions to be sequential
            GlobalLock.Database.Wait();
        }

        public IContainer Container { get; }

        private static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<IntegrationTestsModule>();
            return builder.Build();
        }

        public void Dispose()
        {
            this.databaseManager.Dispose();
            GlobalLock.Database.Release();
        }
    }
}