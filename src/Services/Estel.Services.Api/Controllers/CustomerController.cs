namespace Estel.Services.Api.Controllers
{
    using Estel.Services.Api.ViewModels.Customer;
    using EstelApi.Application.Dto;
    using EstelApi.Application.Interfaces;
    using EstelApi.Core.Seedwork.Adapter;
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
        [Route("customer-management/getallcustomers")]
        public IActionResult Get()
        {
            return this.Response(this.customerAppService.GetAllCustomers());
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
        [HttpGet]
        [Route("customer-management/GetById/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var customerViewModel = this.customerAppService.FindCustomer(id);

            return this.Response(customerViewModel);
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
        [HttpPost]
        [Route("customer-management/CreateNewCustomer")]
        public async Task<IActionResult> Post([FromBody] CreateCustomerViewModel createCustomerViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                this.NotifyModelStateErrors();
                return this.Response(createCustomerViewModel);
            }

            var dto = createCustomerViewModel.ProjectedAs<CustomerDto>();
            var resp = await this.customerAppService.AddNewCustomer(dto);
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
        [HttpPut]
        [Route("customer-management/UpdateCustomer")]
        public IActionResult Put([FromBody] UpdateCustomerViewModel updateCustomerViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                this.NotifyModelStateErrors();
                return this.Response(updateCustomerViewModel);
            }

            try
            {
                var dto = updateCustomerViewModel.ProjectedAs<CustomerDto>();
                this.customerAppService.UpdateCustomer(dto);

                return this.Response(updateCustomerViewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("ff", e);
            }
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
               this.customerAppService.RemoveCustomer(deleteCustomerViewModel.Id);

               return this.Response();
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
        public async Task<IActionResult> History(Guid id)
        {
            var customerHistoryData = await this.customerAppService.GetAllHistory(id);
            return this.Response(customerHistoryData);
        }
    }
}