namespace EstelApi.CrossCutting.IoC
{
    using Autofac;

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
