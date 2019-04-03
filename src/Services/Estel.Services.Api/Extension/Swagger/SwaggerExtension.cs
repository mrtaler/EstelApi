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

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    // options.SubstituteApiVersionInUrl = true;
                });
            services.AddSwaggerGen(
                options =>
                    {
                        // resolve the IApiVersionDescriptionProvider service
                        // note: that we have to build a temporary service provider here because one has not been created yet
                        using (var serviceProvider = services.BuildServiceProvider())
                        {
                            var provider = serviceProvider.GetRequiredService<IApiVersionDescriptionProvider>();

                            // add a swagger document for each discovered API version
                            // note: you might choose to skip or document deprecated API versions differently
                            // foreach (var description in provider.ApiVersionDescriptions)
                            // {
                            // options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                            // }
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

                        // options.OperationFilter<FileUploadOperation>();
                        options.OperationFilter<VersionFilter>();
                        options.OperationFilter<SwaggerDefaultValues>();

                        // options.DocumentFilter<SecurityRequirementsDocumentFilter>();
                        options.DocumentFilter<VersionFilter>();
                        options.DescribeAllParametersInCamelCase();
                        options.IncludeXmlComments(XmlCommentsFilePath);

                        /*    options.AddSecurityDefinition(
                                                         "ApiSecurity",
                                                         new ApiKeyScheme
                                                         {
                                                             Name = "x-api-key",
                                                             In = "header",
                                                             Type = "apiKey"
                                                         }
                                                     );
                                                     options.AddSecurityDefinition(
                                                         "CorrelationId",
                                                         new ApiKeyScheme
                                                         {
                                                             Name = "correlationId",
                                                             In = "header",
                                                             Type = "apiKey"
                                                         }
                                                     );
                        // options.IncludeXmlComments(XmlCommentsFilePath);*/
                        options.DescribeAllParametersInCamelCase();

                    });
        }

        /*   /// <summary>
           /// The create info for api version.
           /// </summary>
           /// <param name="description">
           /// The description.
           /// </param>
           /// <returns>
           /// The <see cref="Info"/>.
           /// </returns>
           private static Info CreateInfoForApiVersion(ApiVersionDescription description)
           {
               var info = new Info()
               {
                   Title = $"Sample API {description.ApiVersion}",
                   Version = description.ApiVersion.ToString(),
                   Description = "A Super Ticket Api Endpoint with Swagger, Swashbuckle, and API versioning.",
                   Contact = new Contact() { Name = "Siarhei Linkevich", Email = "mrtaler@me.com" },
                   TermsOfService = "Shareware",
                   License = new License() { Name = "MIT", Url = "https://opensource.org/licenses/MIT" }
               };

               if (description.IsDeprecated)
               {
                   info.Description += " This API version has been deprecated.";
               }

               return info;
           }*/
    }
}