namespace EstelApi.IntegrationTests.Base
{
    using System.Data.SqlClient;
    using System.IO;

    using EstelApi.IntegrationTests.Base.SqlHelpers;

    /// <inheritdoc />
    /// <summary>
    /// Manages database connection for tests. Can reset the database to initial state.
    /// </summary>
    /// <remarks>
    /// Must be a singleton.
    /// </remarks>
    internal sealed class SingletonDatabaseManager : IDatabaseManager
    {
        /// <summary>
        /// The name for snapshot database.
        /// </summary>
        private const string Snapshot = "Snapshot";

        /// <summary>
        /// The sql helper for work with sql commands.
        /// </summary>
        private readonly ISqlHelper sqlHelper;

        /// <summary>
        /// The connection string for database.
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// The _database name.
        /// </summary>
        private readonly string databaseName;

        /// <summary>
        /// The _snapshot name.
        /// </summary>
        private readonly string snapshotName;

        /// <summary>
        /// Initializes a new instance of the <see cref="SingletonDatabaseManager"/> class.
        /// </summary>
        /// <param name="connectionString">
        /// The connection string.
        /// </param>
        /// <param name="sqlHelper">
        /// The sql helper.
        /// </param>
        /// <param name="databaseName">
        /// The database name.
        /// </param>
        public SingletonDatabaseManager(
            string connectionString,
            ISqlHelper sqlHelper,
            string databaseName)
        {
            this.connectionString = connectionString;
            this.sqlHelper = sqlHelper;
            this.databaseName = databaseName;
            this.snapshotName = databaseName + Snapshot;

            this.CleanUpLastRun();
            this.CreateSnapshot();
        }

        /// <inheritdoc cref="ISqlHelper" />
        public void Dispose()
        {
            this.RestoreFromSnapshot();
            this.DropSnapshot();
        }

        /// <inheritdoc cref="ISqlHelper" />
        public void Reset()
        {
            this.RestoreFromSnapshot();
        }

        private void RestoreFromSnapshot()
        {
            using (var connection = this.sqlHelper.CreateConnection(this.connectionString))
            {
                var command =
                    "USE master;\n"
                    + $"ALTER DATABASE {this.databaseName} SET SINGLE_USER WITH ROLLBACK IMMEDIATE;\n"
                    + $"RESTORE DATABASE {this.databaseName} FROM DATABASE_SNAPSHOT = '{this.snapshotName}';\n"
                    + $"ALTER DATABASE {this.databaseName} SET MULTI_USER WITH ROLLBACK IMMEDIATE;\n";

                this.sqlHelper.ExecuteNonQuery(connection, command);

                SqlConnection.ClearAllPools();
            }
        }

        private void CreateSnapshot()
        {
            using (var connection = this.sqlHelper.CreateConnection(this.connectionString))
            {
                var commandString =
                    "SELECT mf.name, mf.physical_name FROM sys.master_files mf INNER JOIN sys.databases db  "
                    + $"ON db.database_id = mf.database_id WHERE mf.type = 0 AND db.name = '{this.databaseName}'";


                using (var rdr = this.sqlHelper.ExecuteReader(connection, commandString))
                {
                    while (rdr.Read())
                    {
                        dynamic logicalName = rdr["name"];
                        dynamic databaseFileName = rdr["physical_name"];
                        dynamic snapshotFileName = Path.ChangeExtension(databaseFileName, "ss");
                        string creteSnapshotCommand = $"CREATE DATABASE {this.snapshotName} \n"
                                                      + $"ON (NAME = {logicalName}, FILENAME = '{snapshotFileName}') \n"
                                                      + $"AS SNAPSHOT OF {this.databaseName}";
                        using (var connection1 = this.sqlHelper.CreateConnection(this.connectionString))
                        {
                            var rdr1 = this.sqlHelper.ExecuteReader(connection1, creteSnapshotCommand);
                        }
                        }
                }
            }
        }

        private void DropSnapshot()
        {
            using (var connection = this.sqlHelper.CreateConnection(this.connectionString))
            {
                var commandText = $"USE master; DROP DATABASE {this.snapshotName}";
                this.sqlHelper.ExecuteNonQuery(connection, commandText);
            }
        }

        private void CleanUpLastRun()
        {
            using (var connection = this.sqlHelper.CreateConnection(this.connectionString))
            {
                var commandText = $"SELECT 1 FROM sys.databases WHERE name = '{this.snapshotName}'";
                using (var rdr = this.sqlHelper.ExecuteReader(connection, commandText))
                {
                    while (rdr.Read())
                    {
                        this.RestoreFromSnapshot();

                        using (var connection1 = this.sqlHelper.CreateConnection(this.connectionString))
                        {
                            this.sqlHelper.ExecuteNonQuery(
                                connection1,
                                $"USE master; DROP DATABASE {this.snapshotName}");
                        }
                    }
                }
            }
        }
    }
}