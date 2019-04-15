namespace Estel.Services.Api.Controllers
{
    using System.Threading.Tasks;

    using EstelApi.Application.Dto;
    using EstelApi.Application.Interfaces;
    using EstelApi.Application.Specifications.FindByIdSpec;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    /// <inheritdoc />
    [ApiVersion("1.0")]
    public class WorkerController : ApiController
    {
        private IPersonService service;

        public WorkerController(IPersonService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get All Worker.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("GetAllWorker")]
        public async Task<IActionResult> Get()
        {
            var result = await this.service.GetWorkers();
            return this.Response(result);
        }

        /// <summary>
        /// Get Worker By Id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("GetWorkerById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.service.GetWorker(new FindWorkerById().SetId(id));
            return this.Response(result);
        }

        /// <summary>
        /// Delete Worker By Id
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpDelete("DeleteWorkerById")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.service.DeleteWorker(new RemoveEntity<Worker>(id));
            return this.Response(result);
        }

        /// <summary>
        /// Create New Worker.
        /// </summary>
        /// <param name="dto">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost("CreateNewWorker")]
        public async Task<IActionResult> Post([FromBody] CreateNewWorkerDto dto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.ResponseBad("Validation error");
            }

            var resp = await this.service.CreateNewWorker(dto);
            return this.Response(resp);
        }

        /// <summary>
        /// Update Worker.
        /// </summary>
        /// <param name="dto">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPut("UpdateWorker")]
        public async Task<IActionResult> Put([FromBody] UpdateWorkerDto dto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.ResponseBad("Validation error");
            }

            var resp = await this.service.UpdateWorker(dto);
            return this.Response(resp);
        }
    }
}