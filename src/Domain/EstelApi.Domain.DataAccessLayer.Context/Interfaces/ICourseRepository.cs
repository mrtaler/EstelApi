namespace EstelApi.Domain.DataAccessLayer.Context.Interfaces
{
    using EstelApi.Core.Seedwork.Interfaces;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;

    /// <inheritdoc />
    /// <summary>
    /// The CourseRepository interface.
    /// </summary>
    public interface ICourseRepository : IRepository<Course>
    {
    }
}
