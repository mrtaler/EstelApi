using EstelApi.Core.Entities;
using EstelApi.Domain.DataAccessLayer.Context.Context.Base;
using EstelApi.Domain.DataAccessLayer.Context.EntityDbMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace EstelApi.Domain.DataAccessLayer.Context.Context
{
    // Add-Migration Init -Context GomelEstel.Infra.Data.Context.EstelContext -OutputDir Migrations -project GomelEstel.Infra.Data
    // update-database -Project GomelEstel.Infra.Data -Context GomelEstel.Infra.Data.Context.EstelContext
    internal class EstelContext : BaseContext
    {
        private readonly IHostingEnvironment _env;

        public EstelContext(IHostingEnvironment env)
        {
            _env = env;
        }

        public EstelContext(DbContextOptions<EstelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CourseType> CourseTypes { get; set; }
        public virtual DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new CourseTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CoursesConfiguration());

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
                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"))
                    .EnableSensitiveDataLogging(true)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                //,x => x.MigrationsAssembly("GomelEstel.Infra.Data"));}
            }
        }
    }
}
