namespace EstelApi.IntegrationTests.Base.SqlHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;

    public abstract class SqlHelper<T> : ISqlHelper
        where T : DbConnection
    {
        /// <inheritdoc />>
        public IDataReader ExecuteReader(
            IDbConnection connection,
            string commandText,
            params SqlParameter[] parameters)
        {
            return CreateDbCommand(
                connection,
                commandText,
                new CommandType?(),
                parameters).ExecuteReader();
        }

        /// <inheritdoc />>
        public IDataReader ExecuteReader(
            IDbConnection connection,
            string commandText,
            CommandType commandType,
            params SqlParameter[] parameters)
        {
            return CreateDbCommand(
                connection,
                commandText,
                commandType,
                parameters).ExecuteReader();
        }

        /// <inheritdoc />>
        public IDbConnection CreateConnection(string connectionString)
        {
            var instance = (T)Activator.CreateInstance(typeof(T), connectionString);
            instance.Open();
            return instance;
        }

        /// <inheritdoc />>
        public int ExecuteNonQuery(
            IDbConnection connection,
            string commandText,
            params SqlParameter[] parameters)
        {
            return CreateDbCommand(
                connection,
                commandText,
                new CommandType?(),
                parameters).ExecuteNonQuery();
        }

        /// <inheritdoc />>
        public TD ExecuteScalar<TD>(
            IDbConnection connection,
            string commandText,
            params SqlParameter[] parameters)
        {
            return (TD)CreateDbCommand(
                connection,
                commandText,
                new CommandType?(),
                parameters).ExecuteScalar();
        }

        /// <inheritdoc />
        public int ExecuteNonQuery(
            IDbConnection connection,
            string commandText,
            CommandType commandType,
            params SqlParameter[] parameters)
        {
            return CreateDbCommand(
                connection,
                commandText,
                commandType,
                parameters).ExecuteNonQuery();
        }

        private static IDbCommand CreateDbCommand(
            IDbConnection connection,
            string commandText,
            CommandType? commandType,
            IEnumerable<SqlParameter> parameters)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            IDbCommand dataBaseCommand = command;
            CommandType? nullable = commandType;

            int num = nullable.HasValue ? (int)nullable.GetValueOrDefault() : 1;
            dataBaseCommand.CommandType = (CommandType)num;

            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            /*   foreach (Parameter parameter1 in parameters)
               {
                   IDbDataParameter parameter2 = command.CreateParameter();
                   parameter2.ParameterName = parameter1.Key;
                   parameter2.Value = parameter1.Value ?? (object)DBNull.Value;
                   command.Parameters.Add((object)parameter2);
               }
               */
            return command;
        }
    }
}