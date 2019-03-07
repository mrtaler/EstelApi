namespace EstelApi.CrossCutting.Identity
{
    using Autofac;

    using EstelApi.Core.Seedwork.Interfaces;
    using EstelApi.CrossCutting.Identity.Authorization;
    using EstelApi.CrossCutting.Identity.IdentityContext;
    using EstelApi.CrossCutting.Identity.IdentityModels;
    using EstelApi.CrossCutting.Identity.IdentityServices;
    using EstelApi.CrossCutting.Identity.IdentityServices.ExternalServices;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    /// <inheritdoc />
    public class EstelApiCrossCuttingIdentity : Module
    {
        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<AspNetUser>()
                .As<IUser>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<AuthEmailMessageSender>()
                .As<IEmailSender>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<AuthSmsMessageSender>()
                .As<ISmsSender>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<ClaimsRequirementHandler>()
                .As<IAuthorizationHandler>()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<HttpContextAccessor>()
                .As<IHttpContextAccessor>()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<ClaimsRequirementHandler>()
                .As<IAuthorizationHandler>()
                .InstancePerLifetimeScope();


            builder
                .RegisterType<ApplicationRoleManager>()
                .As<RoleManager<ApplicationRole>>()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<ApplicationRoleStore>()
                .As<RoleStore<ApplicationRole, IdentityEstelContext, int, ApplicationUserRole, ApplicationRoleClaim>>()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<ApplicationSignInManager>()
                .As<SignInManager<ApplicationUser>>()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<ApplicationUserManager>()
                .As<UserManager<ApplicationUser>>()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<ApplicationUserStore>()
                .As<UserStore<ApplicationUser, ApplicationRole, IdentityEstelContext, int, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationUserToken, ApplicationRoleClaim>>()
                .InstancePerLifetimeScope();
        }
    }
}
