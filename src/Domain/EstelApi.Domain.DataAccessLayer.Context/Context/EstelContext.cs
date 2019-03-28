namespace EstelApi.Domain.DataAccessLayer.Context.Context
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    /// <inheritdoc />
    /// <summary>
    /// The estel context.
    /// </summary>
    public class EstelContext : DbContext// BaseContext
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

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<AdditionalAmenity> AdditionalAmenities { get; set; }

        public virtual DbSet<AvailableDates> AvailableDates { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<CourseAttendance> CourseAttendances { get; set; }

        public virtual DbSet<CourseType> CourseTypes { get; set; }

        public virtual DbSet<Worker> Workers { get; set; }

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerConfiguration());
            modelBuilder.ApplyConfiguration(new AvailableDatesCourseConfiguration());
            modelBuilder.ApplyConfiguration(new AdditionalAmenityConfiguration());
            modelBuilder.ApplyConfiguration(new AdditionalAmenityCourseConfiguration());
            modelBuilder.ApplyConfiguration(new AvailableDatesConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new CourseAttendanceConfiguration());
            modelBuilder.ApplyConfiguration(new CourseTopicsConfiguration());
            modelBuilder.ApplyConfiguration(new CourseTopicsCourseConfiguration());
            modelBuilder.ApplyConfiguration(new CourseTypeConfiguration());

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
                .EnableSensitiveDataLogging(true);

            // .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            // .UseLazyLoadingProxies()
            // ,x => x.MigrationsAssembly("GomelEstel.Infra.Data"));}
        }
    }
}
