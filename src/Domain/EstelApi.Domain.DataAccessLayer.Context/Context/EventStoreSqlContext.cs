using EstelApi.Core.Cqrs.Events;
using EstelApi.Domain.DataAccessLayer.Context.EntityDbMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace EstelApi.Domain.DataAccessLayer.Context.Context
{
    // Add-Migration Init_EventStoreSQLContext -Context EventStoreSQLContext -project EstelApi.Domain.DataAccessLayer.Context -OutputDir Migrations\EventStore
    // update-database                         -Context EventStoreSQLContext -project EstelApi.Domain.DataAccessLayer.Context
    public class EventStoreSqlContext : DbContext
    {
        public DbSet<StoredEvent> StoredEvent { get; set; }

        private readonly IHostingEnvironment _env;

        public EventStoreSqlContext(IHostingEnvironment env)
        {
            _env = env;
        }

        public EventStoreSqlContext(DbContextOptions<EventStoreSqlContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(_env.ContentRootPath)
                    .AddJsonFile("appsettings.json")
                    .Build();

                // define the database to use
                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            }
        }
    }
}