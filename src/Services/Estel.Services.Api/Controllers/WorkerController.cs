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
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    /// <inheritdoc />
    [ApiVersion("1.0")]
    public class WorkerController : ApiController
    {
        /// <inheritdoc />
        public WorkerController(INotificationHandler<DomainNotification> notifications, IMediator mediator)
            : base(notifications, mediator)
        {
        }

        [HttpGet("GetAllWorker")]
        public async Task<IActionResult> Get()
        {
            var result = await this.mediator.Send(new AllEntitiesQuery<Worker>());
            return this.Response(result);
        }

        [HttpGet("GetWorkerById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.mediator.Send(new EntityByIdQuery<Worker>(id));
            return this.Response(result);
        }

        [HttpDelete("DeleteWorkerById")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.mediator.Send(new RemoveEntityCommand<Worker>(id));
            return this.Response(result);
        }

        [HttpPost("CreateNewWorker")]
        public async Task<IActionResult> Post([FromBody] CreateWorkerViewModel createCustomerViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                this.NotifyModelStateErrors();
                return this.Response(createCustomerViewModel);
            }

            var command = createCustomerViewModel.ProjectedAs<CreateNewWorkerCommand>();
            var resp = await this.mediator.Send(command);
            return this.Response(resp);
        }

        [HttpPut("UpdateWorker")]
        public async Task<IActionResult> Put([FromBody] UpdateWorkerViewModel updateCustomerViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                this.NotifyModelStateErrors();
                return this.Response(updateCustomerViewModel);
            }

            var command = updateCustomerViewModel.ProjectedAs<UpdateWorkerCommand>();
            var resp = await this.mediator.Send(command);
            return this.Response(resp);
        }
    }
}