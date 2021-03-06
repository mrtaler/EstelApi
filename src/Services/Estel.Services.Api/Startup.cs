﻿namespace Estel.Services.Api
{
    using System;
    using System.IO;
    using System.Linq;

    using Autofac;
    using Autofac.Extensions.DependencyInjection;

    using AutoMapper;

    using Estel.Services.Api.Configurations;
    using Estel.Services.Api.Extension.Exception;
    using Estel.Services.Api.Extension.Swagger;

    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.CrossCutting.Identity.Authorization;
    using EstelApi.CrossCutting.Identity.IdentityContext;
    using EstelApi.CrossCutting.Identity.IdentityModels;
    using EstelApi.CrossCutting.Identity.IdentityServices;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.AspNetCore.Mvc.Formatters;
    using Microsoft.AspNetCore.Rewrite;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.FileProviders;
    using Microsoft.Extensions.Logging;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    using Serilog;
    using Serilog.Events;

    using ILogger = Serilog.ILogger;

    /// <summary>
    /// The startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        /// <returns>
        /// The <see cref="IServiceProvider"/>.
        /// </returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            var builder = new ContainerBuilder();
            services.AddDbContext<IdentityEstelContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddUserStore<ApplicationUserStore>()
                .AddUserManager<ApplicationUserManager>()
                .AddRoleStore<ApplicationRoleStore>()
                .AddRoleManager<ApplicationRoleManager>()
                .AddSignInManager<ApplicationSignInManager>()
                .AddEntityFrameworkStores<IdentityEstelContext>()
                .AddDefaultTokenProviders();
            services.AddSwaggerDocumentation();

            services.Configure<IdentityOptions>(
                options =>
                    {
                        // Password settings.
                        options.Password.RequireDigit = false;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequiredLength = 2;
                        options.Password.RequiredUniqueChars = 1;

                        // Lockout settings.
                        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(50);
                        options.Lockout.MaxFailedAccessAttempts = 5;
                        options.Lockout.AllowedForNewUsers = true;

                        // User settings.
                        options.User.AllowedUserNameCharacters =
                            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                        options.User.RequireUniqueEmail = false;
                    });

            services.ConfigureApplicationCookie(options =>
                {
                    // Cookie settings
                    options.Cookie.HttpOnly = true;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(50);
                    options.LoginPath = "/account";
                    options.SlidingExpiration = true;
                });

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddMvcCore(options =>
                {
                    options.Filters.Add<ApiExceptionFilterAttribute>();

                    // options.Filters.Add<ValidateMimeMultipartContentFilter>();
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
                    })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanRead", policy => policy.Requirements.Add(new ClaimRequirement("Customers", "Read")));
                options.AddPolicy("CanRemoveCustomerData", policy => policy.Requirements.Add(new ClaimRequirement("Customers", "Remove")));
            });
            services.AddAutoMapper();

            builder.Populate(services);
            builder.Register<ILogger>((c, p) => new LoggerConfiguration().MinimumLevel.Debug()

                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console(
                    theme: Serilog.Sinks.SystemConsole.Themes.AnsiConsoleTheme.Code,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level}:{EventId} [{SourceContext}] {Message}{NewLine}{Exception}")
                .CreateLogger())
                .SingleInstance();

            builder.RegisterModule(new EstelServicesApiModule());
            var container = builder.Build();
            TypeAdapterFactory.SetCurrent(container.Resolve<ITypeAdapterFactory>());
            IdentityInit.IdentityDataInit(container).Wait();
            return new AutofacServiceProvider(container);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        /// <param name="env">
        /// The env.
        /// </param>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <param name="loggerFactory">
        /// The logger factory.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            IApiVersionDescriptionProvider provider,
            ILoggerFactory loggerFactory,
            ILogger logger)
        {
            this.LogConfiguration(logger);
            loggerFactory.AddSerilog();

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();

            app.UseHsts();
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

            app.UseCors(
                c =>
                    {
                        c.AllowAnyHeader();
                        c.AllowAnyMethod();
                        c.AllowAnyOrigin();
                    });

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                    {
                        // build a swagger endpoint for each discovered API version
                        foreach (var description in provider.ApiVersionDescriptions)
                        {
                            options.SwaggerEndpoint(
                                $"/swagger/{description.GroupName}/swagger.json",
                                description.GroupName.ToUpperInvariant());
                        }
                    });
            app.UseMvc();
        }

        /// <summary>
        /// The log configuration.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        private void LogConfiguration(ILogger logger)
        {
            logger.Information("Using environment: {Environment}");
            logger.Debug(
                "Using configuration: {NewLine:l}{Configuration:l}",
                Environment.NewLine,
                string.Join(Environment.NewLine, this.Configuration.AsEnumerable().Select(conf => $"{conf.Key} = {conf.Value}")));
        }
    }
}