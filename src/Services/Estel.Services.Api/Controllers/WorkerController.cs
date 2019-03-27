namespace Estel.Services.Api.Controllers
{
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands.CreateCommands;
    using EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands.UpdateCommands;
    using EstelApi.Application.ApplicationCqrs.Queries;
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

        /// <summary>
        /// Get All Worker.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("GetAllWorker")]
        public async Task<IActionResult> Get()
        {
            var result = await this.Mediator.Send(new AllEntitiesQuery<Worker>());
            return this.Response(result);
        }

        /// <summary>
        /// Get Worker By Id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("GetWorkerById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.Mediator.Send(new EntityByIdQuery<Worker>(id));
            return this.Response(result);
        }

        /// <summary>
        /// Delete Worker By Id
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpDelete("DeleteWorkerById")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.Mediator.Send(new RemoveEntityCommand<Worker>(id));
            return this.Response(result);
        }

        /// <summary>
        /// Create New Worker.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost("CreateNewWorker")]
        public async Task<IActionResult> Post([FromBody] CreateNewWorkerCommand command)
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
        /// Update Worker.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPut("UpdateWorker")]
        public async Task<IActionResult> Put([FromBody] UpdateWorkerCommand command)
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