namespace EstelApi.Domain.DataAccessLayer.Context.Context
{
    using EstelApi.Core.Seedwork.CoreCqrs.Events;
    using EstelApi.Domain.DataAccessLayer.Context.EntityDbMapper;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;

    /// <inheritdoc />
    public class EventStoreSqlContext : DbContext
    {
        /// <summary>
        /// The env.
        /// </summary>
        private readonly IHostingEnvironment env;

        /// <inheritdoc />
        public EventStoreSqlContext(IHostingEnvironment env)
        {
            this.env = env;
        }

        /// <inheritdoc />
        public EventStoreSqlContext(DbContextOptions<EventStoreSqlContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the stored event.
        /// </summary>
        public DbSet<StoredEvent> StoredEvent { get; set; }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventMap());

            base.OnModelCreating(modelBuilder);
        }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().SetBasePath(this.env.ContentRootPath)
                    .AddJsonFile("appsettings.json").Build();

                // define the database to use
                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            }
        }
    }
}