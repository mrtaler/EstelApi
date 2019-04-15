namespace EstelApi.IntegrationTests.Base
{
    using EstelApi.IntegrationTests.Base.SqlHelpers;

    internal sealed class DatabaseManagerMultiplexer : IDatabaseManager
    {
        private static readonly object Lock = new object();

        private static int multiplexerCount;
        private static SingletonDatabaseManager singletonDatabaseManager;

        public DatabaseManagerMultiplexer(string connectionString, string databaseName)
        {
            lock (Lock)
            {
                if (multiplexerCount == 0)
                {
                    var sqlHelper = new MsSqlServerHelper();
                    singletonDatabaseManager = new SingletonDatabaseManager(connectionString, sqlHelper, databaseName);
                }

                multiplexerCount++;
            }
        }

        public void Dispose()
        {
            lock (Lock)
            {
                multiplexerCount--;

                if (multiplexerCount == 0)
                {
                    singletonDatabaseManager.Dispose();
                    singletonDatabaseManager = null;
                }
            }
        }

        public void Reset()
        {
            singletonDatabaseManager.Reset();
        }
    }
}