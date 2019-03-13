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

            /* builder.Services.AddTransient<IBusMessageDispatcher, BusMessageDispatcher>();
             builder.Services.AddTransient<IQueueClient, QueueClient>();
             builder.Services.AddTransient<ITopicClient, TopicClient>();
             builder.Services.AddTransient<IMessageFactory, MessageFactory>();*/

            builder
            .RegisterType<BusMessageDispatcher>()
            .As<IBusMessageDispatcher>()
            .InstancePerLifetimeScope();

            builder
                .RegisterType<QueueClient>()
                .As<IQueueClient>()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<TopicClient>()
                .As<ITopicClient>()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<MessageFactory>()
                .As<IMessageFactory>()
                .InstancePerLifetimeScope();

            // builder
            // .RegisterType<InMemoryBus>()
            // .As<IMediatorHandler>()
            // .InstancePerLifetimeScope();
        }
    }
}
