namespace EstelApi.Domain.DataAccessLayer.Context
{
    using Autofac;

    using EstelApi.Core.Seedwork.CoreCqrs.Events;
    using EstelApi.Domain.DataAccessLayer.Context.Context;
    using EstelApi.Domain.DataAccessLayer.Context.Context.Base;
    using EstelApi.Domain.DataAccessLayer.Context.Context.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.EventSourcing;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
    using EstelApi.Domain.DataAccessLayer.Context.Repository.EventSourcing;

    /// <inheritdoc />
    /// <summary>
    /// The estel api domain data access layer context module.
    /// </summary>
    public class EstelApiDomainDataAccessLayerContextModule : Module
    {
        /// <inheritdoc />
        /// <summary>
        /// The load.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        protected override void Load(ContainerBuilder builder)
        {
            /*builder.Register(c => new EstelContext(
                                                new DbContextOptionsBuilder<EstelContext>()
                                                    .UseSqlServer(c.Resolve<IOptions<ConnectionSettings>>().Value.EFConnectionString)
                                                    // .UseLazyLoadingProxies()
                                                    .Options
                                            ))  .AsSelf().InstancePerLifetimeScope(); ;*/
            builder
                .RegisterType<EstelContext>()
                .AsSelf()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<UnitOfWork>()
                .As<IQueryableUnitOfWork>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<EventStoreSqlContext>()
                .AsSelf()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<SqlEventStore>()
                .As<IEventStore>()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<EventStoreSqlRepository>()
                .As<IEventStoreRepository>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<WorkerRepository>()
                .As<IWorkerRepository>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<AdditionalAmenityRepository>()
                .As<IAdditionalAmenityRepository>()
                .InstancePerLifetimeScope();
            builder
                    .RegisterType<AvailableDatesRepository>()
                    .As<IAvailableDatesRepository>()
                    .InstancePerLifetimeScope();
            builder
                .RegisterType<CourseRepository>()
                .As<ICourseRepository>()
                .InstancePerLifetimeScope();
            builder
                 .RegisterType<CourseAttendanceRepository>()
                 .As<ICourseAttendanceRepository>()
                 .InstancePerLifetimeScope();
            builder
                .RegisterType<CourseTopicsRepository>()
                .As<ICourseTopicsRepository>()
                .InstancePerLifetimeScope();
            builder
              .RegisterType<CourseTypeRepository>()
              .As<ICourseTypeRepository>()
              .InstancePerLifetimeScope();

            builder
                .RegisterType<CourseRepository>()
                .As<ICourseRepository>()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<CourseTypeRepository>()
                .As<ICourseTypeRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
