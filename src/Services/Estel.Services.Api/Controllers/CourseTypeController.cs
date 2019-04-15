namespace Estel.Services.Api.Controllers
{
    using System.Threading.Tasks;

    using EstelApi.Application.Dto;
    using EstelApi.Application.Interfaces;
    using EstelApi.Application.Specifications.FindByIdSpec;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    /// <inheritdoc />
    /// <summary>
    /// The course type controller.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("Catalog")]
    public class CourseTypeController : ApiController
    {
        private ICourseTypeService service;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Estel.Services.Api.Controllers.CourseTypeController" /> class.
        /// </summary>
        /// <param name="notifications">
        /// The notifications.
        /// </param>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        public CourseTypeController(ICourseTypeService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get All Course Types.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("CourseTypes")]
        public async Task<IActionResult> Get()
        {
            var result = await this.service.GetCourseTypes();
            return this.Response(result);
        }

        /// <summary>
        /// Get Course Type By Id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("CourseType")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.service.GetCourseType(new FindCourseTypeById().SetId(id));
            return this.Response(result);
        }

        /// <summary>
        /// Delete Course Type By Id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpDelete("CourseType")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.service.DeleteCourseType(new RemoveEntity<CourseType>(id));
            return this.Response(result);
        }

        /// <summary>
        /// Create New Course Type.
        /// </summary>
        /// <param name="dto">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost("CourseType")]
        public async Task<IActionResult> Post([FromBody] CreateNewCourseTypeDto dto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.ResponseBad("Validation error");
            }

            var resp = await this.service.CreateCourseType(dto);
            return this.Response(resp);
        }

        /// <summary>
        /// Update Course Type.
        /// </summary>
        /// <param name="dto">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPut("CourseType")]
        public async Task<IActionResult> Put([FromBody] UpdateCourseTypeDto dto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.ResponseBad("Validation error");
            }

            var resp = await this.service.UpdateCourseType(dto);
            return this.Response(resp);
        }
    }
}