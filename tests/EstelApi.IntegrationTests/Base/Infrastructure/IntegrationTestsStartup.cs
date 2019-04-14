namespace EstelApi.IntegrationTests.Base.Infrastructure
{

    using Autofac;

    using Estel.Services.Api;

    using EstelApi.Domain.DataAccessLayer.Context.Context;
    using EstelApi.IntegrationTests.Base.Init;
    using EstelApi.IntegrationTests.Base.Settings;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;

    public class IntegrationTestsStartup : Startup
    {
        public IntegrationTestsStartup(IConfiguration env)
            : base(env)
        {


        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<IntegrationTestsModule>();
          
        }

        public new void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
        }
    }
}