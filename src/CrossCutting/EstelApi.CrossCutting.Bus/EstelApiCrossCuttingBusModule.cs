using Autofac;
//using EstelApi.Core.Cqrs.Bus;

namespace EstelApi.CrossCutting.Bus
{
    public class EstelApiCrossCuttingBusModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder
            //    .RegisterType<InMemoryBus>()
            //    .As<IMediatorHandler>()
            //    .InstancePerLifetimeScope();
        }
    }
}