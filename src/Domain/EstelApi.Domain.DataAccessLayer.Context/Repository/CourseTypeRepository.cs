namespace EstelApi.Domain.DataAccessLayer.Context.Repository
{
    using EstelApi.Domain.DataAccessLayer.Context.Context;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
    using EstelApi.Domain.DataAccessLayer.Context.Repository.Base;

    /// <inheritdoc cref="ICourseTypeRepository" />
    /// <summary>
    /// The course type repository.
    /// </summary>
    public class CourseTypeRepository : Repository<CourseType>, ICourseTypeRepository
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:EstelApi.Domain.DataAccessLayer.Context.Repository.CourseTypeRepository" /> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public CourseTypeRepository(EstelContext context) : base(context)
        {
        }
    }
}