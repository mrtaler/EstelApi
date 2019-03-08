namespace EstelApi.Domain.DataAccessLayer.Context.Context.Base
{
    using System;
    using System.IO;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    /// <inheritdoc />
    /// <summary>
    /// The design time db context factory.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    internal class DesignTimeDbContextFactory<T> : IDesignTimeDbContextFactory<T>
        where T : DbContext
    {
        /// <inheritdoc />
        /// <summary>
        /// The create db context.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <returns>
        /// The <see cref="!:T" />.
        /// </returns>
        public T CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<T>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            var dbContext = (T)Activator.CreateInstance(
                typeof(T),
                builder.Options);

            return dbContext;
        }
    }
}