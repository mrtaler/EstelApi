namespace Estel.Services.Api.Controllers
{
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands.CreateCommands;
    using EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands.UpdateCommands;
    using EstelApi.Application.ApplicationCqrs.Queries;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    /// <inheritdoc />
    /// <summary>
    /// The course type controller.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("Catalog")]
    public class CourseTypeController : ApiController
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Estel.Services.Api.Controllers.CourseTypeController" /> class.
        /// </summary>
        /// <param name="notifications">
        /// The notifications.
        /// </param>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        public CourseTypeController(INotificationHandler<DomainNotification> notifications, IMediator mediator)
            : base(notifications, mediator)
        {
        }

        /// <summary>
        /// Get All Course Types.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("CourseTypes")]
        public async Task<IActionResult> Get()
        {
            var result = await this.Mediator.Send(new AllEntitiesQuery<CourseType>());
            return this.Response(result);
        }

        /// <summary>
        /// Get Course Type By Id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("CourseType")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.Mediator.Send(new EntityByIdQuery<CourseType>(id));
            return this.Response(result);
        }

        /// <summary>
        /// Delete Course Type By Id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpDelete("CourseType")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.Mediator.Send(new RemoveEntityCommand<CourseType>(id));
            return this.Response(result);
        }

        /// <summary>
        /// Create New Course Type.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost("CourseType")]
        public async Task<IActionResult> Post([FromBody] CreateNewCourseTypeCommand command)
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
        /// Update Course Type.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPut("CourseType")]
        public async Task<IActionResult> Put([FromBody] UpdateCourseTypeCommand command)
        {
            if (!this.ModelState.IsValid)
            {
                this.NotifyModelStateErrors();
                return this.Response(command);
            }

            var resp = await this.Mediator.Send(command);
            return this.Response(resp);
        }
    }
}