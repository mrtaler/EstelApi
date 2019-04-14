namespace EstelApi.CrossCutting.IoC
{
    using Autofac;

    using EstelApi.Application;
    using EstelApi.Application.ApplicationCqrs;
    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.Core.Seedwork.Adapter.Implementation;
    using EstelApi.CrossCutting.Identity;
    using EstelApi.CrossCutting.Identity.IdentityContext;
    using EstelApi.Domain.DataAccessLayer.Context;

    /// <inheritdoc />
    public class EstelServicesApiModule : Module
    {
        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new EstelApiCrossCuttingIoC());
        }
    }
}
