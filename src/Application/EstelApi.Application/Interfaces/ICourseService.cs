namespace EstelApi.Application.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Commands.Course.CreateNewCourse;
    using EstelApi.Application.ApplicationCqrs.Commands.Course.UpdateAvailableDatesForCourse;
    using EstelApi.Application.ApplicationCqrs.Commands.Course.UpdateCourse;
    using EstelApi.Application.ApplicationCqrs.Commands.Course.UpdateCourseTopicsForCourse;
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