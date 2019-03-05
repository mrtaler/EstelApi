using System;
using EstelApi.Application.Interfaces;
using EstelApi.Application.ViewModels;
using EstelApi.Core.Cqrs.Bus;
using EstelApi.Core.Cqrs.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Estel.Services.Api.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(
            ICustomerAppService customerAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _customerAppService = customerAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("customer-management")]
        public IActionResult Get()
        {
            return Response(_customerAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("customer-management/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var customerViewModel = _customerAppService.GetById(id);

            return Response(customerViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management")]
        public IActionResult Post([FromBody]CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(customerViewModel);
            }

            _customerAppService.Register(customerViewModel);

            return Response(customerViewModel);
        }

        [HttpPut]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management")]
        public IActionResult Put([FromBody]CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(customerViewModel);
            }

            _customerAppService.Update(customerViewModel);

            return Response(customerViewModel);
        }

        [HttpDelete]
        [Authorize(Policy = "CanRemoveCustomerData")]
        [Route("customer-management")]
        public IActionResult Delete(Guid id)
        {
            _customerAppService.Remove(id);

            return Response();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("customer-management/history/{id:guid}")]
        public IActionResult History(Guid id)
        {
            var customerHistoryData = _customerAppService.GetAllHistory(id);
            return Response(customerHistoryData);
        }
    }
}