namespace Estel.Services.Api.Controllers
{
    using EstelApi.Application.Interfaces;
    using EstelApi.Application.ViewModels.Customer;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    // [Authorize]

    /// <summary>
    /// The customer controller.
    /// </summary>
    [ApiVersion("1.0")]
    public class CustomerController : ApiController
    {
        /// <summary>
        /// The customer app service.
        /// </summary>
        private readonly ICustomerAppService customerAppService;

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
            ICustomerAppService customerAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediator mediator)
            : base(notifications, mediator)
        {
            this.customerAppService = customerAppService;
        }

        /// <summary>
        /// Work The getAll.
        /// </summary>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        /// [AllowAnonymous]
        [HttpGet]
        [Route("customer-management")]
        public IActionResult Get()
        {
            return this.Response(this.customerAppService.GetAll());
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
        [HttpGet]

        // [AllowAnonymous]
        [Route("customer-management/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var customerViewModel = this.customerAppService.GetById(id);

            return this.Response(customerViewModel);
        }

        /// <summary>
        /// The post.
        /// </summary>
        /// <param name="createCustomerViewModel">
        /// The create customer view model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]

        // [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management")]
        public async Task<IActionResult> Post([FromBody] CreateCustomerViewModel createCustomerViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                this.NotifyModelStateErrors();
                return this.Response(createCustomerViewModel);
            }

            var resp = await this.customerAppService.Register(createCustomerViewModel);
            return this.Response(resp);
        }

        /// <summary>
        /// The put.
        /// </summary>
        /// <param name="updateCustomerViewModel">
        /// The update customer view model.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpPut]

        // [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management")]
        public IActionResult Put([FromBody] UpdateCustomerViewModel updateCustomerViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                this.NotifyModelStateErrors();
                return this.Response(updateCustomerViewModel);
            }

            this.customerAppService.Update(updateCustomerViewModel);

            return this.Response(updateCustomerViewModel);
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
        [HttpDelete]

        // [Authorize(Policy = "CanRemoveCustomerData")]
        [Route("customer-management")]
        public IActionResult Delete([FromBody] DeleteCustomerViewModel deleteCustomerViewModel)
        {
            this.customerAppService.Remove(deleteCustomerViewModel.Id);

            return this.Response();
        }

        /// <summary>
        /// The history.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpGet]

        // [AllowAnonymous]
        [Route("customer-management/history/{id:guid}")]
        public IActionResult History(Guid id)
        {
            var customerHistoryData = this.customerAppService.GetAllHistory(id);
            return this.Response(customerHistoryData);
        }
    }
}