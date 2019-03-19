namespace Estel.Services.Api.Controllers
{
    using System.Threading.Tasks;

    using Estel.Services.Api.ViewModels.Create;
    using Estel.Services.Api.ViewModels.Update;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands.CreateCommands;
    using EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands.UpdateCommands;
    using EstelApi.Application.ApplicationCqrs.Queries;
    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    /// <inheritdoc />
    [ApiVersion("1.0")]
    public class CourseController : ApiController
    {
        /// <inheritdoc />
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
        [HttpGet("GetAllCourse")]
        public async Task<IActionResult> Get()
        {
            var result = await this.mediator.Send(new AllEntitiesQuery<Course>());
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
        [HttpGet("GetCourseById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.mediator.Send(new EntityByIdQuery<Course>(id));
            return this.Response(result);
        }

        [HttpDelete("DeleteCourseById")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.mediator.Send(new RemoveEntityCommand<Course>(id));
            return this.Response(result);
        }

        [HttpPost("CreateNewCourse")]
        public async Task<IActionResult> Post([FromBody] CreateCourseViewModel createCustomerViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                this.NotifyModelStateErrors();
                return this.Response(createCustomerViewModel);
            }

            var command = createCustomerViewModel.ProjectedAs<CreateNewCourseCommand>();
            var resp = await this.mediator.Send(command);
            return this.Response(resp);
        }

        [HttpPut("UpdateCourse")]
        public async Task<IActionResult> Put([FromBody] UpdateCourseViewModel updateCustomerViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                this.NotifyModelStateErrors();
                return this.Response(updateCustomerViewModel);
            }

            var command = updateCustomerViewModel.ProjectedAs<UpdateCourseCommand>();
            var resp = await this.mediator.Send(command);
            return this.Response(resp);
        }
    }
}