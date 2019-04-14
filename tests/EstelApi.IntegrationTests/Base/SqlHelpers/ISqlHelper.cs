namespace EstelApi.IntegrationTests.Base.SqlHelpers
{
    using System.Data;
    using System.Data.SqlClient;

    public interface ISqlHelper
    {
        IDbConnection CreateConnection(string connectionString);

        IDataReader ExecuteReader(IDbConnection connection, string commandText, params SqlParameter[] parameters);

        IDataReader ExecuteReader(IDbConnection connection, string commandText, CommandType commandType, params SqlParameter[] parameters);

        int ExecuteNonQuery(IDbConnection connection, string commandText, params SqlParameter[] parameters);

        T ExecuteScalar<T>(IDbConnection connection, string commandText, params SqlParameter[] parameters);

        int ExecuteNonQuery(IDbConnection connection, string commandText, CommandType commandType, params SqlParameter[] parameters);
    }
}