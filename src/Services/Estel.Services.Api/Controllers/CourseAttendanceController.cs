//namespace Estel.Services.Api.Controllers
//{
//    using System.Threading.Tasks;

//    using EstelApi.Application.ApplicationCqrs.Base;
//    using EstelApi.Application.ApplicationCqrs.Queries;
//    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

//    using MediatR;

//    using Microsoft.AspNetCore.Mvc;

//    /// <inheritdoc />
//    /// <summary>
//    /// The course attendance controller.
//    /// </summary>
//    [ApiVersion("1.0")]
//    [Route("Course")]
//    public class CourseAttendanceController : ApiController
//    {
//        /// <inheritdoc />
//        /// <summary>
//        /// Initializes a new instance of the <see cref="T:Estel.Services.Api.Controllers.CourseAttendanceController" /> class.
//        /// </summary>
//        /// <param name="notifications">
//        /// The notifications.
//        /// </param>
//        /// <param name="mediator">
//        /// The mediator.
//        /// </param>
//        public CourseAttendanceController(INotificationHandler<DomainEvent> notifications, IMediator mediator)
//            : base(notifications, mediator)
//        {
//        }

//        /// <summary>
//        /// Get All Course Attendance.
//        /// </summary>
//        /// <returns>
//        /// The <see cref="Task"/>.
//        /// </returns>
//        [HttpGet("CourseAttendances")]
//        public async Task<IActionResult> Get()
//        {
//            var result = await this.Mediator.Send(new AllEntitiesQuery<CourseAttendance>());
//            return this.Response(result);
//        }

//        /// <summary>
//        /// Get Course Attendance By Id.
//        /// </summary>
//        /// <param name="id">
//        /// The id.
//        /// </param>
//        /// <returns>
//        /// The <see cref="Task"/>.
//        /// </returns>
//        [HttpGet("CourseAttendance")]
//        public async Task<IActionResult> Get(int id)
//        {
//            var result = await this.Mediator.Send(new EntityByIdQuery<CourseAttendance>(id));
//            return this.Response(result);
//        }

//        /// <summary>
//        /// Delete Course Attendance By Id.
//        /// </summary>
//        /// <param name="id">
//        /// The id.
//        /// </param>
//        /// <returns>
//        /// The <see cref="Task"/>.
//        /// </returns>
//        [HttpDelete("CourseAttendance")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var result = await this.Mediator.Send(new RemoveEntityCommand<CourseAttendance>(id));
//            return this.Response(result);
//        }
//        }
//}