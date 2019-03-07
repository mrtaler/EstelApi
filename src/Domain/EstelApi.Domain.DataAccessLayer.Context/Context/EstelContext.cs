﻿using EstelApi.Domain.DataAccessLayer.Context.Context.Base;
using EstelApi.Domain.DataAccessLayer.Context.EntityDbMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace EstelApi.Domain.DataAccessLayer.Context.Context
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CountryAgg;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    // Add-Migration Init_EstelContext -Context EstelContext  -project EstelApi.Domain.DataAccessLayer.Context -OutputDir Migrations
    // update-database                 -Context EstelContext  -project EstelApi.Domain.DataAccessLayer.Context
    internal class EstelContext : BaseContext
    {
        private readonly IHostingEnvironment env;

        public EstelContext(IHostingEnvironment env)
        {
            this.env = env;
        }

        public EstelContext(DbContextOptions<EstelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; }
       
        public virtual DbSet<Country> Countries { get; }

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
                var config = new ConfigurationBuilder().SetBasePath(this.env.ContentRootPath)
                    .AddJsonFile("appsettings.json").Build();

                // define the database to use
                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"))
                    .EnableSensitiveDataLogging(true).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

                // ,x => x.MigrationsAssembly("GomelEstel.Infra.Data"));}
            }
        }
    }
}
