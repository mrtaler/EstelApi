using EstelApi.CrossCutting.Identity.IdentityModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EstelApi.CrossCutting.Identity.IdentityContext
{
    // Add-Migration Init_IdentityEstelContext -Context IdentityEstelContext -OutputDir Migrations -project EstelApi.CrossCutting.Identity
    // update-database -Project EstelApi.CrossCutting.Identity
    public class IdentityEstelContext : IdentityDbContext<
        ApplicationUser,
        ApplicationRole,
        int,
        ApplicationUserClaim,
        ApplicationUserRole,
        ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        private readonly IHostingEnvironment _env;

        public IdentityEstelContext(
            DbContextOptions<IdentityEstelContext> options,
            IHostingEnvironment env) : base(options)
        {
            _env = env;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
