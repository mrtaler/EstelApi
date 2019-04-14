namespace Estel.Services.Api.Extension.Swagger
{
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.PlatformAbstractions;
    using Swashbuckle.AspNetCore.Swagger;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// The swagger extension.
    /// </summary>
    public static class SwaggerExtension
    {
        /// <summary>
        /// Gets the xml comments file path.
        /// </summary>
        private static string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }

        /// <summary>
        /// The add swagger documentation.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        public static void AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                });
            services.AddSwaggerGen(
                options =>
                    {
                        using (var serviceProvider = services.BuildServiceProvider())
                        {
                            var provider = serviceProvider.GetRequiredService<IApiVersionDescriptionProvider>();

                            foreach (var description in provider.ApiVersionDescriptions)
                            {
                                options.SwaggerDoc(
                                    description.GroupName,
                                    new Info
                                    {
                                        Title = $"Gomel Estel API {description.ApiVersion}",
                                        Version = description.ApiVersion.ToString()
                                    });
                            }
                        }

                        options.OperationFilter<VersionFilter>();
                   //     options.OperationFilter<SwaggerDefaultValues>();

                        options.DocumentFilter<VersionFilter>();
                        options.IncludeXmlComments(XmlCommentsFilePath);
                        options.DescribeAllParametersInCamelCase();
                    });
        }
    }
}