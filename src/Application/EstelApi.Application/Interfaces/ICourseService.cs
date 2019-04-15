namespace EstelApi.Application.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EstelApi.Application.Dto;
    using EstelApi.Core.Seedwork.Specifications.Interfaces;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    public interface ICourseService
    {
        Task<Course> CreateNewCourse(CreateNewCourseDto processingEntity);

        Task<bool> UpdateAddiAmeForCourse(UpdateAdditionalAmenityForCourseDto processingEntity);

        Task<bool> UpdateAvailDateForCourse(UpdateAvailableDatesForCourseDto processingEntity);

        Task<Course> UpdateCourse(UpdateCourseDto processingEntity);

        Task<bool> UpdateCourseTopics(UpdateCourseTopicsForCourseDto processingEntity);

        Task<bool> DeleteCourse(RemoveEntityCommand<Course> processingEntity);

        Task<Course> GetGourse(ISpecification<Course> criteria = null);

        Task<IEnumerable<Course>> GetGourses(ISpecification<Course> criteria = null);

    }
}