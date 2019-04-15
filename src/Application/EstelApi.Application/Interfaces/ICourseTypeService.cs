namespace EstelApi.Application.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EstelApi.Application.Dto;
    using EstelApi.Core.Seedwork.Specifications.Interfaces;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    public interface ICourseTypeService
    {
        Task<CourseType> CreateCourseType(CreateNewCourseTypeDto processingEntity);

        Task<bool> DeleteCourseType(RemoveEntity<CourseType> processingEntity);

        Task<CourseType> UpdateCourseType(UpdateCourseTypeDto processingEntity);

        Task<CourseType> GetCourseType(ISpecification<CourseType> criteria = null);

        Task<IEnumerable<CourseType>> GetCourseTypes(ISpecification<CourseType> criteria = null);
    }
}