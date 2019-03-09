namespace EstelApi.Domain.DataAccessLayer.Context.Context
{
    using EstelApi.Domain.DataAccessLayer.Context.Context.Base;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CountryAgg;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.EntityDbMapper;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    /// <inheritdoc />
    /// <summary>
    /// The estel context.
    /// </summary>
    internal class EstelContext : BaseContext
    {
        /// <summary>
        /// The env.
        /// </summary>
        private readonly IHostingEnvironment env;
        private readonly ILoggerFactory loggerFactory;

        /// <inheritdoc />
        public EstelContext(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            this.env = env;
            this.loggerFactory = loggerFactory;
        }

        /// <inheritdoc />
        public EstelContext(DbContextOptions<EstelContext> options, ILoggerFactory loggerFactory)
            : base(options)
        {
            this.loggerFactory = loggerFactory;
        }

        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        public virtual DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the countries.
        /// </summary>
        public virtual DbSet<Country> Countries { get; set; }

        /// <summary>
        /// Gets or sets the course types.
        /// </summary>
        public virtual DbSet<CourseType> CourseTypes { get; set; }

        /// <summary>
        /// Gets or sets the courses.
        /// </summary>
        public virtual DbSet<Course> Courses { get; set; }

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());

            /*       modelBuilder.ApplyConfiguration(new CourseTypeConfiguration());
                        modelBuilder.ApplyConfiguration(new CoursesConfiguration());
            */
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// The on configuring.
        /// </summary>
        /// <param name="optionsBuilder">
        /// The options builder.
        /// </param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().SetBasePath(this.env.ContentRootPath)
                    .AddJsonFile("appsettings.json").Build();

                // define the database to use
                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"))
                    .UseLoggerFactory(this.loggerFactory)
                    .EnableSensitiveDataLogging(true)

                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

                // ,x => x.MigrationsAssembly("GomelEstel.Infra.Data"));}
            }
        }
    }
}
