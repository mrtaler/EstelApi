﻿namespace Estel.Services.Api.Configurations
{
    using System;

    using AutoMapper;

    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// The auto mapper setup.
    /// </summary>
    public static class AutoMapperSetup
    {
        /// <summary>
        /// The add auto mapper setup.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        /// <exception cref="ArgumentNullException">if services is null
        /// </exception>
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddAutoMapper();

            // Registering Mappings automatically only works if the 
            // Automapper Profile classes are in ASP.NET project
         // AutoMapperConfig.RegisterMappings();

            /*
             services.AddScoped<ITypeAdapterFactory, AutomapperTypeAdapterFactory>();
             TypeAdapterFactory.SetCurrent(services.BuildServiceProvider().GetService<ITypeAdapterFactory>());
            */
        }
    }
}
