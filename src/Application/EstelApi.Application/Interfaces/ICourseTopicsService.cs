namespace EstelApi.Application.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EstelApi.Application.Dto;
    using EstelApi.Core.Seedwork.Specifications.Interfaces;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    public interface ICourseTopicsService
    {
        Task<CourseTopics> CreateCourseTopics(CreateNewCourseTopicsDto processingEntity);

        Task<bool> DeleteCourseTopics(RemoveEntity<CourseTopics> processingEntity);

        Task<CourseTopics> UpdateCourseTopics(UpdateCourseTopicsDto processingEntity);

        Task<CourseTopics> GetCourseTopic(ISpecification<CourseTopics> criteria = null);

        Task<IEnumerable<CourseTopics>> GetCourseTopics(ISpecification<CourseTopics> criteria = null);
    }
}