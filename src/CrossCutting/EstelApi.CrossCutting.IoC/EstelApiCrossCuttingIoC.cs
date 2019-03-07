﻿using Autofac;
using EstelApi.Application;
using EstelApi.Application.Cqrs.Commands;
using EstelApi.Application.Cqrs.Queries;
using EstelApi.Core.Seedwork.Adapter;
using EstelApi.Core.Seedwork.Adapter.Implementation;
using EstelApi.CrossCutting.Bus;
using EstelApi.CrossCutting.Identity;
using EstelApi.Domain.DataAccessLayer.Context;

namespace EstelApi.CrossCutting.IoC
{
    public class EstelApiCrossCuttingIoC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new EstelApiCrossCuttingBusModule());
            builder.RegisterModule(new EstelApiCrossCuttingIdentity());

            // 2
            builder.RegisterModule(new EstelApiDomainDataAccessLayerContextModule());

            // 3
            builder.RegisterModule(new EstelApiApplicationModule());
            builder.RegisterModule(new EstelApiApplicationCommandsModule());
            builder.RegisterModule(new EstelApiApplicationQueriesModule());

            builder.RegisterType<AutoMapperTypeAdapterFactory>().As<ITypeAdapterFactory>().InstancePerLifetimeScope();

            // services.AddScoped<ITypeAdapterFactory, AutomapperTypeAdapterFactory>();
        }
    }
}
