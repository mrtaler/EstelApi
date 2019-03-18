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
    public class AdditionalAmenityController : ApiController
    {
        public AdditionalAmenityController(INotificationHandler<DomainNotification> notifications, IMediator mediator)
            : base(notifications, mediator)
        {
        }

        [HttpGet("GetAllAdditionalAmenity")]
        public async Task<IActionResult> Get()
        {
            var result = await this.mediator.Send(new AllEntitiesQuery<AdditionalAmenity>());
            return this.Response(result);
        }

        [HttpGet("GetAdditionalAmenityById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.mediator.Send(new EntityByIdQuery<AdditionalAmenity>(id));
            return this.Response(result);
        }

        [HttpDelete("DeleteAdditionalAmenityById")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.mediator.Send(new RemoveEntityCommand<AdditionalAmenity>(id));
            return this.Response(result);
        }

        [HttpPost("CreateNewAdditionalAmenity")]
        public async Task<IActionResult> Post([FromBody] CreateAdditionalAmenityViewModel createCustomerViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                this.NotifyModelStateErrors();
                return this.Response(createCustomerViewModel);
            }

            var command = createCustomerViewModel.ProjectedAs<CreateNewAdditionalAmenityCommand>();
            var resp = await this.mediator.Send(command);
            return this.Response(resp);
        }

        [HttpPut("UpdateAdditionalAmenity")]
        public async Task<IActionResult> Put([FromBody] UpdateAdditionalAmenityViewModel updateCustomerViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                this.NotifyModelStateErrors();
                return this.Response(updateCustomerViewModel);
            }

            var command = updateCustomerViewModel.ProjectedAs<UpdateAdditionalAmenityCommand>();
            var resp = await this.mediator.Send(command);
            return this.Response(resp);
        }
    }
}