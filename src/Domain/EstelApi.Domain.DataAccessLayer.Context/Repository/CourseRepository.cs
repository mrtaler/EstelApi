namespace EstelApi.Domain.DataAccessLayer.Context.Repository
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
    using EstelApi.Domain.DataAccessLayer.Context.Repository.Base;

    /// <inheritdoc cref="ICourseRepository" />
    /// <summary>
    /// The course repository.
    /// </summary>
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:EstelApi.Domain.DataAccessLayer.Context.Repository.CourseRepository" /> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public CourseRepository(IQueryableUnitOfWork context) : base(context)
        {
        }
    }
}