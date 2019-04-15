namespace EstelApi.Application
{
    using Autofac;

    using EstelApi.Application.Interfaces;
    using EstelApi.Application.Services;

    public class EstelApiApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<AdditionalAmenityService>()
                .As<IAdditionalAmenityService>()
                .InstancePerLifetimeScope();
            builder
              .RegisterType<AvailableDatesService>()
              .As<IAvailableDatesService>()
              .InstancePerLifetimeScope();
            builder
              .RegisterType<CourseAttendanceService>()
              .As<ICourseAttendanceService>()
              .InstancePerLifetimeScope();
            builder
                .RegisterType<CourseService>()
                .As<ICourseService>()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<CourseTopicsService>()
                .As<ICourseTopicsService>()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<CourseTypeService>()
                .As<ICourseTypeService>()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<PersonService>()
                .As<IPersonService>()
                .InstancePerLifetimeScope();
        }
    }
}
