namespace EstelApi.IntegrationTests.Base.Fixture
{
    using Autofac;

    using EstelApi.IntegrationTests.Base.Init;

    public sealed class RepositoriesInitializationFixture : IInitializationFixture
    {
        /// <summary>
        /// The _database manager.
        /// </summary>
        private readonly IDatabaseManager databaseManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoriesInitializationFixture"/> class.
        /// </summary>
        public RepositoriesInitializationFixture()
        {
            this.Container = CreateContainer();
            this.databaseManager = this.Container.Resolve<IDatabaseManager>();

            // Force all database interactions to be sequential
            GlobalLock.Database.Wait();
        }

        /// <inheritdoc />
        public IContainer Container { get; }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.databaseManager.Dispose();
            GlobalLock.Database.Release();
        }

        /// <summary>
        /// The create container.
        /// </summary>
        /// <returns>
        /// The <see cref="IContainer"/>.
        /// </returns>
        private static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<IntegrationTestsModule>();
            return builder.Build();
        }
    }
}