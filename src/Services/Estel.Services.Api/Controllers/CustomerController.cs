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

    // [Authorize]

    /// <summary>
    /// The customer controller.
    /// </summary>
    [ApiVersion("1.0")]
    public class UserController : ApiController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="notifications">
        /// The notifications.
        /// </param>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        public UserController(
            INotificationHandler<DomainEvent> notifications,
            IMediator mediator)
            : base(notifications, mediator)
        {
        }

        /// <summary>
        /// Work The getAll.
        /// </summary>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        /// [AllowAnonymous]
        [HttpGet("GetAllCustomer")]
        public async Task<IActionResult> Get()
        {
            var result = await this.Mediator.Send(new AllEntitiesQuery<User>());
            return this.Response(result);
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        /// [AllowAnonymous]
        [HttpGet("GetCustomerById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.Mediator.Send(new EntityByIdQuery<User>(id));
            return this.Response(result);
        }

        /// <summary>
        /// Create New Customer (work)
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// [Authorize(Policy = "CanWriteCustomerData")]
        [HttpPost("CreateNewCustomer")]
        public async Task<IActionResult> Post([FromBody] CreateNewUserCommand command)
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
        /// Update Customer. (work)
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        /// [Authorize(Policy = "CanWriteCustomerData")]
        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> Put([FromBody] UpdateUserCommand command)
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
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// current id
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// [Authorize(Policy = "CanRemoveCustomerData")]
        [HttpDelete("DeleteCustomerById")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.Mediator.Send(new RemoveEntityCommand<User>(id));
            return this.Response(result);
        }

        /// <summary>
        /// Customer history (work)
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        /// [AllowAnonymous]
        [HttpGet]
        [Route("customer-management/history/{id:guid}")]
        public IActionResult History(int id)
        {
            /*   var customerHistoryData = await this.customerAppService.GetAllHistory(id);
               return this.Response(customerHistoryData);*/
            return this.Ok();
        }
    }
}