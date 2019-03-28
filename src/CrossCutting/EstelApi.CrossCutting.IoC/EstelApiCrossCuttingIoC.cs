namespace EstelApi.CrossCutting.IoC
{
    using Autofac;

    using EstelApi.Application;
    using EstelApi.Application.ApplicationCqrs;
    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.Core.Seedwork.Adapter.Implementation;
    using EstelApi.CrossCutting.Bus;
    using EstelApi.CrossCutting.Identity;
    using EstelApi.Domain.DataAccessLayer.Context;

    /// <inheritdoc />
    public class EstelApiCrossCuttingIoC : Module
    {
        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new EstelApiCrossCuttingBusModule());
            builder.RegisterModule(new EstelApiCrossCuttingIdentity());

            // 2
            builder.RegisterModule(new EstelApiDomainDataAccessLayerContextModule());

            // 3
            builder.RegisterModule(new EstelApiApplicationModule());
            builder.RegisterModule(new EstelApiApplicationCqrsModule());

            builder.RegisterType<AutoMapperTypeAdapterFactory>().As<ITypeAdapterFactory>().SingleInstance();
        }
    }
}
