namespace Estel.Services.Api.Controllers
{
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
    using EstelApi.Application.Dto;
    using EstelApi.Application.Interfaces;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using Microsoft.AspNetCore.Mvc;

    /// <inheritdoc />
    /// <summary>
    /// The available dates controller.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("Catalog")]
    public class AvailableDatesController : ApiController
    {
        private IAvailableDatesService service;
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Estel.Services.Api.Controllers.AvailableDatesController" /> class.
        /// </summary>
        public AvailableDatesController(IAvailableDatesService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get All Available Dates.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("AvailableDates")]
        public async Task<IActionResult> Get()
        {
            var result = await this.service.GetAvailableDates();
            return this.Response(result);
        }

        /// <summary>
        /// Get Available Dates By Id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("AvailableDate")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.service.GetAvailableDate(new FindAvailableDatesById().SetId(id));
            return this.Response(result);
        }

        /// <summary>
        /// Delete Available Dates By Id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpDelete("AvailableDate")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.service.DeleteAvailableDate(new RemoveEntityCommand<AvailableDates>(id));
            return this.Response(result);
        }

        /// <summary>
        /// Create New Available Dates.
        /// </summary>
        /// <param name="dto">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost("AvailableDate")]
        public async Task<IActionResult> Post([FromBody] CreateNewAvailableDatesDto dto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.ResponseBad("Validation error");
            }

            var resp = await this.service.CreateAvailableDates(dto);
            return this.Response(resp);
        }

        /// <summary>
        /// Update Available Dates.
        /// </summary>
        /// <param name="dto">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPut("AvailableDate")]
        public async Task<IActionResult> Put([FromBody] UpdateAvailableDatesDto dto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.ResponseBad("Validation error");
            }

            var resp = await this.service.UpdateAvailableDate(dto);
            return this.Response(resp);
        }
    }
}