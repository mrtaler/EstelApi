namespace EstelApi.Application.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EstelApi.Application.Dto;
    using EstelApi.Core.Seedwork.Specifications.Interfaces;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    public interface ICourseAttendanceService
    {
        Task<bool> DeleteCourseAttendance(RemoveEntity<CourseAttendance> processingEntity);

        Task<CourseAttendance> GetCourseAttendance(ISpecification<CourseAttendance> criteria = null);

        Task<IEnumerable<CourseAttendance>> GetCourseAttendances(ISpecification<CourseAttendance> criteria = null);
    }
}