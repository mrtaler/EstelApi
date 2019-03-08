namespace EstelApi.CrossCutting.Identity.IdentityContext
{
    using EstelApi.CrossCutting.Identity.IdentityModels;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// The identity estel context.
    /// </summary>
    public class IdentityEstelContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserClaim,
        ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        /// <summary>
        /// The env.
        /// </summary>
        private readonly IHostingEnvironment env;

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityEstelContext"/> class.
        /// </summary>
        /// <param name="options">
        /// The options.
        /// </param>
        /// <param name="env">
        /// The env.
        /// </param>
        public IdentityEstelContext(DbContextOptions<IdentityEstelContext> options, IHostingEnvironment env)
            : base(options)
        {
            this.env = env;
        }

        /// <inheritdoc />
        /// <summary>
        /// The on configuring.
        /// </summary>
        /// <param name="optionsBuilder">
        /// The options builder.
        /// </param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder().SetBasePath(this.env.ContentRootPath)
                .AddJsonFile("appsettings.json").Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
