namespace EstelApi.IntegrationTests.Base.Infrastructure
{

    using Autofac;

    using Estel.Services.Api;

    using EstelApi.IntegrationTests.Base.Init;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

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