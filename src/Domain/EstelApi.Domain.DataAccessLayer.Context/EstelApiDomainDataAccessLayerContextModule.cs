﻿namespace EstelApi.Domain.DataAccessLayer.Context
{
    using Autofac;

    using EstelApi.Domain.DataAccessLayer.Context.Context;
    using EstelApi.Domain.DataAccessLayer.Context.Context.Base;
    using EstelApi.Domain.DataAccessLayer.Context.Context.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

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
            builder
                .RegisterType<EstelContext>()
                .AsSelf()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<UnitOfWork>()
                .As<IQueryableUnitOfWork>()
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
