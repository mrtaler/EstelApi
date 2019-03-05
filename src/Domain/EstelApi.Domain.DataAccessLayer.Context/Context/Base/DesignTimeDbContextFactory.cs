using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EstelApi.Domain.DataAccessLayer.Context.Context.Base
{
    internal class DesignTimeDbContextFactory<T> : IDesignTimeDbContextFactory<T>
        where T : DbContext
    {
        public T CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
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