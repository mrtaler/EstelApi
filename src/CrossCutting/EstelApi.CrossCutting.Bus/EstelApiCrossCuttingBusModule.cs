namespace EstelApi.CrossCutting.Bus
{
    using Autofac;

    /// <inheritdoc />
    public class EstelApiCrossCuttingBusModule : Module
    {
        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder)
        {
            // builder.Services.Configure<ServiceBusConfiguration>(configuration.GetSection(Constants.ServiceBusConfigurationSection));
            
            // builder
            // .RegisterType<InMemoryBus>()
            // .As<IMediatorHandler>()
            // .InstancePerLifetimeScope();
        }
    }
}
