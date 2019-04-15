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
            builder.RegisterType<CourseService>().As<ICourseService>().InstancePerLifetimeScope();

        }
    }
}
