namespace Estel.Services.Api.Controllers
{
    using Estel.Services.Api.ViewModels.Create;
    using Estel.Services.Api.ViewModels.Update;
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Commands.CreateCommands;
    using EstelApi.Application.ApplicationCqrs.Commands.UpdateCommands;
    using EstelApi.Application.ApplicationCqrs.Queries;
    //using EstelApi.Application.Dto;
    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    // [Authorize]

    /// <summary>
    /// The customer controller.
    /// </summary>
    [ApiVersion("1.0")]
    public class CustomerController : ApiController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        /// </summary>
        /// <param name="customerAppService">
        /// The customer app service.
        /// </param>
        /// <param name="notifications">
        /// The notifications.
        /// </param>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        public CustomerController(
            INotificationHandler<DomainNotification> notifications,
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
            var result = await this.mediator.Send(new AllEntitiesQuery<Customer>());
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
            var result = await this.mediator.Send(new EntityByIdQuery<Customer>(id));
            return this.Response(result);
        }

        /// <summary>
        /// Create New Customer (work)
        /// </summary>
        /// <param name="createCustomerViewModel">
        /// The create customer view model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// [Authorize(Policy = "CanWriteCustomerData")]
        [HttpPost("CreateNewCustomer")]
        public async Task<IActionResult> Post([FromBody] CreateCustomerViewModel createCustomerViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                this.NotifyModelStateErrors();
                return this.Response(createCustomerViewModel);
            }

            var command = createCustomerViewModel.ProjectedAs<CreateNewCustomerCommand>();
            var resp = await this.mediator.Send(command);
            return this.Response(resp);
        }

        /// <summary>
        /// Update Customer. (work)
        /// </summary>
        /// <param name="updateCustomerViewModel">
        /// The update customer view model.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        /// [Authorize(Policy = "CanWriteCustomerData")]
        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> Put([FromBody] UpdateCustomerViewModel updateCustomerViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                this.NotifyModelStateErrors();
                return this.Response(updateCustomerViewModel);
            }

            var command = updateCustomerViewModel.ProjectedAs<UpdateCustomerCommand>();
            var resp = await this.mediator.Send(command);
            return this.Response(resp);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="deleteCustomerViewModel">
        /// The delete customer view model.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        // [Authorize(Policy = "CanRemoveCustomerData")]
        [HttpDelete("DeleteCustomerById")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.mediator.Send(new RemoveEntityCommand<Customer>(id));
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
        public async Task<IActionResult> History(int id)
        {
            /*   var customerHistoryData = await this.customerAppService.GetAllHistory(id);
               return this.Response(customerHistoryData);*/
            return this.Ok();
        }
    }
}