namespace EstelApi.Application.ApplicationCqrs
{
    using Autofac;

    using EstelApi.Application.Interfaces;
    using EstelApi.Application.Services;

    /// <inheritdoc />
    /// <summary>
    /// The estel api application cqrs module.
    /// </summary>
    public class EstelApiApplicationCqrsModule : Autofac.Module
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
            builder.RegisterType<AdditionalAmenityService>()
                .As<IAdditionalAmenityService>().InstancePerLifetimeScope();
            builder.RegisterType<AvailableDatesService>()
                .As<IAvailableDatesService>().InstancePerLifetimeScope();
            builder.RegisterType<CourseAttendanceService>()
                .As<ICourseAttendanceService>().InstancePerLifetimeScope();
            builder.RegisterType<CourseService>()
                .As<ICourseService>().InstancePerLifetimeScope();
            builder.RegisterType<CourseTopicsService>()
                .As<ICourseTopicsService>().InstancePerLifetimeScope();
            builder.RegisterType<PersonService>()
                .As<IPersonService>().InstancePerLifetimeScope();
        }
    }
}
