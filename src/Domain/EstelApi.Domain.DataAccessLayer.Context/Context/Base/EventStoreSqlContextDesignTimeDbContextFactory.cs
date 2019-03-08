namespace EstelApi.Domain.DataAccessLayer.Context.Context.Base
{
    /// <inheritdoc />
    /// <summary>
    /// The event store sql context design time db context factory.
    /// </summary>
    internal class EventStoreSqlContextDesignTimeDbContextFactory : DesignTimeDbContextFactory<EventStoreSqlContext>
    {
        /*  // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            */
    }
}