using System;
using AutoMapper;
using EstelApi.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Estel.Services.Api.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper();

            // Registering Mappings automatically only works if the 
            // Automapper Profile classes are in ASP.NET project
         //   AutoMapperConfig.RegisterMappings();

            /*
             services.AddScoped<ITypeAdapterFactory, AutomapperTypeAdapterFactory>();
             TypeAdapterFactory.SetCurrent(services.BuildServiceProvider().GetService<ITypeAdapterFactory>());
            */
        }
    }
}
