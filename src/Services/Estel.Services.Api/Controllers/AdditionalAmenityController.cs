namespace Estel.Services.Api.Controllers
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands.CreateCommands;
    using EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands.UpdateCommands;
    using EstelApi.Application.ApplicationCqrs.Queries;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    using Estel.Services.Api.ViewModels;

    using EstelApi.Core.Seedwork.Adapter;

    /// <inheritdoc />
    /// <summary>
    /// The additional amenity controller.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("Catalog")]
    public class AdditionalAmenityController : ApiController
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Estel.Services.Api.Controllers.AdditionalAmenityController" /> class.
        /// </summary>
        /// <param name="notifications">
        /// The notifications.
        /// </param>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        public AdditionalAmenityController(INotificationHandler<DomainNotification> notifications, IMediator mediator)
            : base(notifications, mediator)
        {
        }

        /// <summary>
        /// Get All Additional Amenity.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("AdditionalAmenities")]
        public async Task<IActionResult> Get()
        {
            var additionalAmenities = await this.Mediator.Send(new AllEntitiesQuery<AdditionalAmenity>());
            var result = additionalAmenities.ProjectedAsCollection<AdditionalAmenityViewModel>();
            return this.Response(result);
        }

        /// <summary>
        /// Get Additional Amenity By Id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("AdditionalAmenity")]
        public async Task<IActionResult> Get(int id)
        {
            var additionalAmenity = await this.Mediator.Send(new EntityByIdQuery<AdditionalAmenity>(id));
            var result = additionalAmenity.ProjectedAs<AdditionalAmenityViewModel>();  
            return this.Response(result);
        }

        /// <summary>
        /// Delete Additional Amenity By Id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpDelete("AdditionalAmenity")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.Mediator.Send(new RemoveEntityCommand<AdditionalAmenity>(id));
            return this.Response(result);
        }

        /// <summary>
        /// Create New Additional Amenity.
        /// </summary>
        /// <param name="createNewAdditionalAmenity">
        /// The create New Additional Amenity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost("AdditionalAmenity")]
        public async Task<IActionResult> Post([FromBody] CreateNewAdditionalAmenityCommand createNewAdditionalAmenity)
        {
            if (!this.ModelState.IsValid)
            {
                this.NotifyModelStateErrors();
                return this.Response(createNewAdditionalAmenity);
            }

            var resp = await this.Mediator.Send(createNewAdditionalAmenity);
            return this.Response(resp);
        }

        /// <summary>
        /// Update Additional Amenity.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPut("AdditionalAmenity")]
        public async Task<IActionResult> Put([FromBody] UpdateAdditionalAmenityCommand command)
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