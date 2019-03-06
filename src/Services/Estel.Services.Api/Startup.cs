using Autofac;
using Estel.Services.Api.Configurations;
using Estel.Services.Api.Extension.Exception;
using Estel.Services.Api.Extension.Swagger;
using EstelApi.CrossCutting.Identity.IdentityContext;
using EstelApi.CrossCutting.Identity.IdentityModels;
using EstelApi.CrossCutting.Identity.IdentityServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Linq;
using Autofac.Extensions.DependencyInjection;
using EstelApi.CrossCutting.Identity.Authorization;
using Serilog;
using EstelApi.CrossCutting.IoC;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using ILogger = Serilog.ILogger;

namespace Estel.Services.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            services.AddDbContext<IdentityEstelContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddUserStore<ApplicationUserStore>()
                .AddUserManager<ApplicationUserManager>()
                .AddRoleStore<ApplicationRoleStore>()
                .AddRoleManager<ApplicationRoleManager>()
                .AddSignInManager<ApplicationSignInManager>()
                .AddEntityFrameworkStores<IdentityEstelContext>()
                .AddDefaultTokenProviders();
            services.AddSwaggerDocumentation();

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddMvcCore(options =>
            {
                options.Filters.Add<ApiExceptionFilterAttribute>();
                //  options.Filters.Add<ValidateMimeMultipartContentFilter>();
            });

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
            });
            services.AddCors();
            services.AddMvc(options =>
                {
                    options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                    options.UseCentralRoutePrefix(new RouteAttribute("api/v{api-version:apiVersion}"));
                    // options.UseCentralRoutePrefix(new RouteAttribute("api/v{version}"));
                })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAutoMapperSetup();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanWriteCustomerData", policy => policy.Requirements.Add(new ClaimRequirement("Customers", "Write")));
                options.AddPolicy("CanRemoveCustomerData", policy => policy.Requirements.Add(new ClaimRequirement("Customers", "Remove")));
            });

            
            builder.Populate(services);
            builder.Register<ILogger>((c, p) =>
            {
                return new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    //.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                    .Enrich.FromLogContext()
                    .WriteTo.Console(
                        theme: Serilog.Sinks.SystemConsole.Themes.AnsiConsoleTheme.Code,
                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level}:{EventId} [{SourceContext}] {Message}{NewLine}{Exception}")
                    .CreateLogger();
            }).SingleInstance();

            builder.RegisterModule(new EstelApiCrossCuttingIoC());
            var container = builder.Build();
            return new AutofacServiceProvider(container);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            IApiVersionDescriptionProvider provider,
            ILoggerFactory loggerFactory,
            ILogger logger)
        {
            LogConfiguration(logger);
            loggerFactory.AddSerilog();


            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            // if (env.IsDevelopment())
            //  {
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
            //  }
            //   else
            //    {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
            //   }

            app.UseDefaultFiles();

            var staticFilePath = Path.Combine(Directory.GetCurrentDirectory(), "ContentFolder");
            if (!Directory.Exists(staticFilePath))
            {
                Directory.CreateDirectory(staticFilePath);
            }
            var strFileOptions = new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(staticFilePath),
                ServeUnknownFileTypes = true
            };

            app.UseStaticFiles(strFileOptions);
            //app.UseCors(builder =>builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            app.UseCors(c => { c.AllowAnyHeader(); c.AllowAnyMethod(); c.AllowAnyOrigin(); });

            app.UseHttpsRedirection();
            app.UseAuthentication();


            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    // build a swagger endpoint for each discovered API version
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });
            app.UseMvc();
        }

        private void LogConfiguration(Serilog.ILogger logger)
        {
            logger.Information("Using environment: {Environment}");
            logger.Debug(
                "Using configuration: {NewLine:l}{Configuration:l}",
                Environment.NewLine,
                string.Join(
                    Environment.NewLine,
                    Configuration.AsEnumerable().Select(conf => $"{conf.Key} = {conf.Value}")
                )
            );
        }
    }
}