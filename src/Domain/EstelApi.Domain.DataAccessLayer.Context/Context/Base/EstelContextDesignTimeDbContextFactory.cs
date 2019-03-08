namespace EstelApi.Domain.DataAccessLayer.Context.Context.Base
{
    /// <inheritdoc />
    /// <summary>
    /// The estel context design time db context factory.
    /// </summary>
    internal class EstelContextDesignTimeDbContextFactory : DesignTimeDbContextFactory<EstelContext>
    {
        // get the configuration from the app settings
        /*      var config = new ConfigurationBuilder()
                  .SetBasePath(_env.ContentRootPath)
                  .AddJsonFile("appsettings.json")
                  .Build();

              // define the database to use
              optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"),x=>x.MigrationsAssembly("GomelEstel.Infra.Data"));*/
    }
}