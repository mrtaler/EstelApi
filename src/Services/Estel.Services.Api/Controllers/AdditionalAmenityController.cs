namespace Estel.Services.Api.Controllers
{
    using System.Threading.Tasks;

    using Estel.Services.Api.ViewModels;

    using EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands.CreateCommands;
    using EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands.UpdateCommands;
    using EstelApi.Application.ApplicationCqrs.Queries;
    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
    using EstelApi.Application.Dto;
    using EstelApi.Application.Interfaces;
    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    /// <inheritdoc />
    /// <summary>
    /// The additional amenity controller.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("Catalog")]
    public class AdditionalAmenityController : ApiController
    {
        private IAdditionalAmenityService service;
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
        public AdditionalAmenityController( IAdditionalAmenityService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get All Additional Amenity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     POST /Todo
        ///     {
        ///        "Id": 1,
        ///        "AdditionalAmenityName": "Item1",
        ///     }
        /// </remarks>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>    
        [HttpGet("AdditionalAmenities")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get()
        {
            var additionalAmenities = await this.service.GetAdditionalAmenities();
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
            
            var additionalAmenity = await this.service.GetAdditionalAmenity(new FindAdditionalAmenityById().SetId(id));
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
            var result = await this.service.DeleteAdditionalAmenity(new RemoveEntityCommand<AdditionalAmenity>(id));
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
        public async Task<IActionResult> Post([FromBody] CreateNewAdditionalAmenityDto createNewAdditionalAmenity)
        {
            if (!this.ModelState.IsValid)
            {
                return this.ResponseBad("Validation error");
            }

            var resp = await this.service.CreateAdditionalAmenity(createNewAdditionalAmenity);
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
        public async Task<IActionResult> Put([FromBody] UpdateAdditionalAmenityDto command)
        {
            if (!this.ModelState.IsValid)
            {
                return this.ResponseBad("Validation error");
            }

            var resp = await this.service.UpdateAdditionalAmenity(command);
            return this.Response(resp);
        }
    }
}