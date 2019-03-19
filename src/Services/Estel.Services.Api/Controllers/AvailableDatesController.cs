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

    [ApiVersion("1.0")]
    public class AvailableDatesController : ApiController
    {
        public AvailableDatesController(INotificationHandler<DomainNotification> notifications, IMediator mediator)
            : base(notifications, mediator)
        {
        }

        [HttpGet("GetAllAvailableDates")]
        public async Task<IActionResult> Get()
        {
            var result = await this.mediator.Send(new AllEntitiesQuery<AvailableDates>());
            return this.Response(result);
        }

        [HttpGet("GetAvailableDatesById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.mediator.Send(new EntityByIdQuery<AvailableDates>(id));
            return this.Response(result);
        }

        [HttpDelete("DeleteAvailableDatesById")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.mediator.Send(new RemoveEntityCommand<AvailableDates>(id));
            return this.Response(result);
        }


        [HttpPost("CreateNewAvailableDates")]
        public async Task<IActionResult> Post([FromBody] CreateAvailableDatesViewModel createCustomerViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                this.NotifyModelStateErrors();
                return this.Response(createCustomerViewModel);
            }

            var command = createCustomerViewModel.ProjectedAs<CreateNewAvailableDatesCommand>();
            var resp = await this.mediator.Send(command);
            return this.Response(resp);
        }

        [HttpPut("UpdateAvailableDates")]
        public async Task<IActionResult> Put([FromBody] UpdateAvailableDatesViewModel updateCustomerViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                this.NotifyModelStateErrors();
                return this.Response(updateCustomerViewModel);
            }

            var command = updateCustomerViewModel.ProjectedAs<UpdateAvailableDatesCommand>();
            var resp = await this.mediator.Send(command);
            return this.Response(resp);
        }
    }
}