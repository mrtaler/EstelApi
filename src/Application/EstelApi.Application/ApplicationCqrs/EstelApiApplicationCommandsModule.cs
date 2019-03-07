namespace EstelApi.Application.ApplicationCqrs
{
    using System.Reflection;

    using Autofac;

    using EstelApi.Application.ApplicationCqrs.Commands.CustomerCommands;
    using EstelApi.Application.ApplicationCqrs.Commands.CustomerCommands.Events;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;

    using MediatR;

    public class EstelApiApplicationCommandsModule :Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope(); 
            builder.AddMediatR(
                typeof(CustomerCommandHandler).GetTypeInfo().Assembly// ,
                                                                     // typeof(GetAreaAsIEnumerableQuery).GetTypeInfo().Assembly,
                                                                     /*  typeof(Area).GetTypeInfo().Assembly*/);

            // ContainerBuilderExtensions.AddMediatR(builder, IntrospectionExtensions.GetTypeInfo(typeof(CustomerCommandHandler)).Assembly);
            builder.RegisterType<DomainNotificationHandler>().As<INotificationHandler<DomainNotification>>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerEventHandler>().As<INotificationHandler<CustomerRegisteredEvent>>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerEventHandler>().As<INotificationHandler<CustomerUpdatedEvent>>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerEventHandler>().As<INotificationHandler<CustomerRemovedEvent>>().InstancePerLifetimeScope();

            /* builder.Register(
                     ctx =>
                     {
                         var scope = ctx.Resolve<ILifetimeScope>();
                         return new Mapper(
                             ctx.Resolve<IConfigurationProvider>(),
                             scope.Resolve);
                     })
                 .As<IMapper>()
                 .InstancePerLifetimeScope();*/

            // builder.RegisterType<CustomerQueriesHandler>().As<IRequestHandler<RegisterNewCustomerCommand, CommandResponse<CustomerDto>>>().InstancePerLifetimeScope();
            // builder.RegisterType<CustomerCommandHandler>().As<IRequestHandler<UpdateCustomerCommand, CommandResponse>>().InstancePerLifetimeScope();
            // builder.RegisterType<CustomerCommandHandler>().As<IRequestHandler<RemoveCustomerCommand, CommandResponse>>().InstancePerLifetimeScope();
        }
    }
}
