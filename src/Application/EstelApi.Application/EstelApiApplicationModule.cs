using Autofac;
using EstelApi.Application.Interfaces;
using EstelApi.Application.Services;

namespace EstelApi.Application
{
    public class EstelApiApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerAppService>().As<ICustomerAppService>().InstancePerLifetimeScope();
        }
    }
}
