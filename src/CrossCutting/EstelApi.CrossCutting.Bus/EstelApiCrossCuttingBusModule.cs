﻿namespace EstelApi.CrossCutting.Bus
{
    using Autofac;

    /// <inheritdoc />
    public class EstelApiCrossCuttingBusModule : Module
    {
        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder)
        {
            // builder
            // .RegisterType<InMemoryBus>()
            // .As<IMediatorHandler>()
            // .InstancePerLifetimeScope();
        }
    }
}
