﻿namespace Estel.Services.Api.Controllers
{
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Queries.CustomerQueries;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;

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
    }
}