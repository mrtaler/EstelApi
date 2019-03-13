﻿namespace EstelApi.Application.ApplicationCqrs
{
    using System.Reflection;

    using Autofac;

    using EstelApi.Application.ApplicationCqrs.Commands.CustomerCommands;
    using EstelApi.Application.ApplicationCqrs.Commands.CustomerCommands.Events;
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
                typeof(CustomerCommandHandler).GetTypeInfo().Assembly);

            builder.RegisterType<DomainNotificationHandler>().As<INotificationHandler<DomainNotification>>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerEventHandler>().As<INotificationHandler<CustomerRegisteredEvent>>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerEventHandler>().As<INotificationHandler<CustomerUpdatedEvent>>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerEventHandler>().As<INotificationHandler<CustomerRemovedEvent>>().InstancePerLifetimeScope();
        }
    }
}