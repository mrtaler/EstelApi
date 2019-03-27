namespace Estel.Services.Api.Controllers
{

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Queries;
    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    using System.Threading.Tasks;

    using Estel.Services.Api.ViewModels;

    using EstelApi.Application.ApplicationCqrs.Commands.Course.CreateNewCourse;
    using EstelApi.Application.ApplicationCqrs.Commands.Course.UpdateAvailableDatesForCourse;
    using EstelApi.Application.ApplicationCqrs.Commands.Course.UpdateCourse;
    using EstelApi.Application.ApplicationCqrs.Commands.Course.UpdateCourseTopicsForCourse;

    /// <inheritdoc />
    /// <summary>
    /// The course controller.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("Course")]
    public class CourseController : ApiController
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Estel.Services.Api.Controllers.CourseController" /> class.
        /// </summary>
        /// <param name="notifications">
        /// The notifications.
        /// </param>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        public CourseController(INotificationHandler<DomainNotification> notifications, IMediator mediator)
            : base(notifications, mediator)
        {
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("Courses")]
        public async Task<IActionResult> Get()
        {
            var result = await this.Mediator.Send(new AllEntitiesQuery<Course>());
            return this.Response(result);
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("Course")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.Mediator.Send(new EntityByIdQuery<Course>(id));
            var rs = result.ProjectedAs<CourseViewModel>();
            return this.Response(rs);
        }

        /// <summary>
        /// Delete Course By Id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpDelete("DeleteCourseById")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.Mediator.Send(new RemoveEntityCommand<Course>(id));
            return this.Response(result);
        }

        /// <summary>
        /// Create New Course.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost("Course")]
        public async Task<IActionResult> Post([FromBody] CreateNewCourseCommand command)
        {
            if (!this.ModelState.IsValid)
            {
                this.NotifyModelStateErrors();
                return this.Response(command);
            }

            var resp = await this.Mediator.Send(command);
            return this.Response(resp);
        }

        /// <summary>
        /// Update Course.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPut("Course")]
        public async Task<IActionResult> Put([FromBody] UpdateCourseCommand command)
        {
            if (!this.ModelState.IsValid)
            {
                this.NotifyModelStateErrors();
                return this.Response(command);
            }

            var resp = await this.Mediator.Send(command);
            return this.Response(resp);
        }

        [HttpPut("Course/{CourseId}/AvailableDate")]
        public async Task<IActionResult> Put(
            int CourseId,
            UpdateAvailableDatesForCourseCommand command)
        {
            var resp = await this.Mediator.Send(command);

            return this.Response(resp);
        }

        [HttpPut("Course/{CourseId}/CourseTopics")]
        public async Task<IActionResult> Put(
            int CourseId,
            UpdateCourseTopicsForCourseCommand command)
        {
           var resp = await this.Mediator.Send(command);

            return this.Response(resp);
        }


        [HttpPut("Course/{CourseId}/AdditionalAmenity")]
        public async Task<IActionResult> Put(
            int CourseId,
            UpdateAdditionalAmenityForCourseCommand command)
        {
            var resp = await this.Mediator.Send(command);

            return this.Response(resp);
        }

        // CourseAttendance

    }
}