namespace EstelApi.Application.ApplicationCqrs
{
    using System.Reflection;

    using Autofac;

    using EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands;
    using EstelApi.Application.ApplicationCqrs.Commands._CustomerCommands;
    using EstelApi.Application.ApplicationCqrs.Commands._CustomerCommands.Events;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;

    using MediatR;
    using MediatR.Extensions.Autofac.DependencyInjection;

    /// <inheritdoc />
    /// <summary>
    /// The estel api application cqrs module.
    /// </summary>
    public class EstelApiApplicationCqrsModule : Autofac.Module
    {
        /// <inheritdoc />
        /// <summary>
        /// The load.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.AddMediatR(
                typeof(CreateUserCommandHandler).GetTypeInfo().Assembly);

            builder.RegisterType<DomainEventHandler>().As<INotificationHandler<DomainEvent>>().InstancePerLifetimeScope();


            builder.RegisterGeneric(typeof(PerformanceBehavior<,>))
                .As(typeof(IPipelineBehavior<,>))
                .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(ExceptionHandler<,>))
                .As(typeof(IPipelineBehavior<,>))
                .InstancePerLifetimeScope();
        }
    }
}
