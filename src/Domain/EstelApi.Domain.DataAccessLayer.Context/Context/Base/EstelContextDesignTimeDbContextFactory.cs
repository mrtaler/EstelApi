namespace EstelApi.Domain.DataAccessLayer.Context.Context.Base
{
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