namespace Estel.Services.Api.Controllers
{
    using System.Threading.Tasks;

    using Estel.Services.Api.ViewModels.Create;
    using Estel.Services.Api.ViewModels.Update;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Commands.CreateCommands;
    using EstelApi.Application.ApplicationCqrs.Commands.UpdateCommands;
    using EstelApi.Application.ApplicationCqrs.Queries;
    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    public class CourseTypeController : ApiController
    {
        public CourseTypeController(INotificationHandler<DomainNotification> notifications, IMediator mediator)
            : base(notifications, mediator)
        {
        }

        [HttpGet("GetAllCourseType")]
        public async Task<IActionResult> Get()
        {
            var result = await this.mediator.Send(new AllEntitiesQuery<CourseType>());
            return this.Response(result);
        }

        [HttpGet("GetCourseTypeById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.mediator.Send(new EntityByIdQuery<CourseType>(id));
            return this.Response(result);
        }

        [HttpDelete("DeleteCourseTypeById")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.mediator.Send(new RemoveEntityCommand<CourseType>(id));
            return this.Response(result);
        }

        [HttpPost("CreateNewCourseType")]
        public async Task<IActionResult> Post([FromBody] CreateCourseTypeViewModel createCustomerViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                this.NotifyModelStateErrors();
                return this.Response(createCustomerViewModel);
            }

            var command = createCustomerViewModel.ProjectedAs<CreateNewCourseTypeCommand>();
            var resp = await this.mediator.Send(command);
            return this.Response(resp);
        }

        [HttpPut("UpdateCourseType")]
        public async Task<IActionResult> Put([FromBody] UpdateCourseTypeViewModel updateCustomerViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                this.NotifyModelStateErrors();
                return this.Response(updateCustomerViewModel);
            }

            var command = updateCustomerViewModel.ProjectedAs<UpdateCourseTypeCommand>();
            var resp = await this.mediator.Send(command);
            return this.Response(resp);
        }
    }
}