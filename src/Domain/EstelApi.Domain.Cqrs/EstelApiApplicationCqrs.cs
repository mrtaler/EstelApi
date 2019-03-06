using System.Reflection;
using Autofac;
using EstelApi.Core.Cqrs.Events;
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
            //builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope(); 
            builder.AddMediatR(
                typeof(CustomerCommandHandler).GetTypeInfo().Assembly//,
              //  typeof(GetAreaAsIEnumerableQuery).GetTypeInfo().Assembly,
              /*  typeof(Area).GetTypeInfo().Assembly*/);

            //ContainerBuilderExtensions.AddMediatR(builder, IntrospectionExtensions.GetTypeInfo(typeof(CustomerCommandHandler)).Assembly);
            builder.RegisterType<DomainNotificationHandler>().As<INotificationHandler<DomainNotification>>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerEventHandler>().As<INotificationHandler<CustomerRegisteredEvent>>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerEventHandler>().As<INotificationHandler<CustomerUpdatedEvent>>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerEventHandler>().As<INotificationHandler<CustomerRemovedEvent>>().InstancePerLifetimeScope();

            builder.RegisterType<CustomerCommandHandler>().As<IRequestHandler<RegisterNewCustomerCommand, CommandResponse<CustomerDto>>>().InstancePerLifetimeScope();
          //  builder.RegisterType<CustomerCommandHandler>().As<IRequestHandler<UpdateCustomerCommand, CommandResponse>>().InstancePerLifetimeScope();
          //  builder.RegisterType<CustomerCommandHandler>().As<IRequestHandler<RemoveCustomerCommand, CommandResponse>>().InstancePerLifetimeScope();

        }
    }
}
