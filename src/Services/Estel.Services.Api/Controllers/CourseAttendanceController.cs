namespace Estel.Services.Api.Controllers
{
    using System.Threading.Tasks;

    using EstelApi.Application.Dto;
    using EstelApi.Application.Interfaces;
    using EstelApi.Application.Specifications.FindByIdSpec;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using Microsoft.AspNetCore.Mvc;

    /// <inheritdoc />
    /// <summary>
    /// The course attendance controller.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("Course")]
    public class CourseAttendanceController : ApiController
    {
        private ICourseAttendanceService service;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Estel.Services.Api.Controllers.CourseAttendanceController" /> class.
        /// </summary>
        public CourseAttendanceController( ICourseAttendanceService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get All Course Attendance.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("CourseAttendances")]
        public async Task<IActionResult> Get()
        {
            var result = await this.service.GetCourseAttendances();
            return this.Response(result);
        }

        /// <summary>
        /// Get Course Attendance By Id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("CourseAttendance")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.service.GetCourseAttendance(new FindCourseAttendanceById().SetId(id));
            return this.Response(result);
        }

        /// <summary>
        /// Delete Course Attendance By Id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpDelete("CourseAttendance")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.service.DeleteCourseAttendance(new RemoveEntity<CourseAttendance>(id));
            return this.Response(result);
        }
    }
}