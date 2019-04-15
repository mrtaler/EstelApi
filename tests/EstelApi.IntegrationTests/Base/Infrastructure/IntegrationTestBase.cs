namespace EstelApi.IntegrationTests.Base.Infrastructure
{
    using Autofac;

    using EstelApi.IntegrationTests.Base.Fixture;

    /// <summary>
    /// The integration test base.
    /// </summary>
    [LogTestName]
    public abstract class IntegrationTestBase
    {
        /// <summary>
        /// The _database manager.
        /// </summary>
        private readonly IDatabaseManager databaseManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationTestBase"/> class.
        /// </summary>
        /// <param name="initializationFixture">
        /// The initialization fixture.
        /// </param>
        protected IntegrationTestBase(IInitializationFixture initializationFixture)
        {
            this.Container = initializationFixture.Container;
            this.databaseManager = this.Container.Resolve<IDatabaseManager>();
        }

        /// <summary>
        /// Gets the container.
        /// </summary>
        protected IContainer Container { get; }

        protected void ResetDatabase()
        {
            this.databaseManager.Reset();
        }
    }
}
