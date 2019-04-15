namespace Estel.Services.Api
{
    using Autofac;

    using EstelApi.CrossCutting.IoC;

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
