using EstelApi.Application.Interfaces;
using EstelApi.Application.ViewModels.Customer;
using EstelApi.Core.Cqrs.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Estel.Services.Api.Controllers
{
    // [Authorize]
    [ApiVersion("1.0")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(
            ICustomerAppService customerAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediator mediator) : base(notifications, mediator)
        {
            _customerAppService = customerAppService;
        }

        [HttpGet]
        //  [AllowAnonymous]
        [Route("customer-management")]
        public IActionResult Get()
        {
            return Response(_customerAppService.GetAll());
        }

        [HttpGet]
        //   [AllowAnonymous]
        [Route("customer-management/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var customerViewModel = _customerAppService.GetById(id);

            return Response(customerViewModel);
        }

        [HttpPost]
        //  [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management")]
        public async Task<IActionResult> Post([FromBody]CreateCustomerViewModel createCustomerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(createCustomerViewModel);
            }

            var resp= await  _customerAppService.Register(createCustomerViewModel);
            return Response(resp);
        }

        [HttpPut]
        //    [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management")]
        public IActionResult Put([FromBody]UpdateCustomerViewModel UpdateCustomerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(UpdateCustomerViewModel);
            }

             _customerAppService.Update(UpdateCustomerViewModel);

            return Response(UpdateCustomerViewModel);
        }

        [HttpDelete]
        //  [Authorize(Policy = "CanRemoveCustomerData")]
        [Route("customer-management")]
        public IActionResult Delete([FromBody]DeleteCustomerViewModel deleteCustomerViewModel)
        {
            _customerAppService.Remove(deleteCustomerViewModel.Id);

            return Response();
        }

        [HttpGet]
        //   [AllowAnonymous]
        [Route("customer-management/history/{id:guid}")]
        public IActionResult History(Guid id)
        {
            var customerHistoryData = _customerAppService.GetAllHistory(id);
            return Response(customerHistoryData);
        }
    }
}