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
    public class EstelContext :DbContext// BaseContext
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
        public EstelContext(DbContextOptions<EstelContext> options)
            : base(options)
        {
        }

        private DbSet<Country> countries;
        private DbSet<Customer> customers;
        private DbSet<CourseType> courseTypes;
        private DbSet<Course> courses;

        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        public virtual DbSet<Customer> Customers => this.customers ?? (this.customers = base.Set<Customer>());

        /// <summary>
        /// Gets the countries.
        /// </summary>
        public virtual DbSet<Country> Countries => this.countries ?? (this.countries = base.Set<Country>());

        /// <summary>
        /// Gets or sets the course types.
        /// </summary>
        public virtual DbSet<CourseType> CourseTypes => this.courseTypes ?? (this.courseTypes = base.Set<CourseType>());

        /// <summary>
        /// Gets or sets the courses.
        /// </summary>
        public virtual DbSet<Course> Courses => this.courses ?? (this.courses = base.Set<Course>());

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
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            var config = new ConfigurationBuilder().SetBasePath(this.env.ContentRootPath)
                .AddJsonFile("appsettings.json").Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"))
                .UseLoggerFactory(this.loggerFactory)
                .EnableSensitiveDataLogging(true);//;.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);/*
              //  .UseLazyLoadingProxies()

               // */
         //   ;

            // ,x => x.MigrationsAssembly("GomelEstel.Infra.Data"));}
        }
    }
}
