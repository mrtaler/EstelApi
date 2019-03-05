using System.Reflection;
using Autofac;
using EstelApi.Core.Cqrs.Notifications;
using EstelApi.Domain.Cqrs.Base;
using EstelApi.Domain.Cqrs.Commands.CustomerCommands;
using EstelApi.Domain.Cqrs.Commands.CustomerCommands.Commands;
using EstelApi.Domain.Cqrs.Commands.CustomerCommands.Events;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using Module = Autofac.Module;

namespace EstelApi.Domain.Cqrs
{
    public class EstelApiDomainCqrsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ContainerBuilderExtensions.AddMediatR(builder, IntrospectionExtensions.GetTypeInfo(typeof(CommandHandler)).Assembly);
            builder.RegisterType<DomainNotificationHandler>().As<INotificationHandler<DomainNotification>>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerEventHandler>().As<INotificationHandler<CustomerRegisteredEvent>>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerEventHandler>().As<INotificationHandler<CustomerUpdatedEvent>>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerEventHandler>().As<INotificationHandler<CustomerRemovedEvent>>().InstancePerLifetimeScope();

            builder.RegisterType<CustomerCommandHandler>().As<IRequestHandler<RegisterNewCustomerCommand, bool>>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerCommandHandler>().As<IRequestHandler<UpdateCustomerCommand, bool>>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerCommandHandler>().As<IRequestHandler<RemoveCustomerCommand, bool>>().InstancePerLifetimeScope();

        }
    }
}
