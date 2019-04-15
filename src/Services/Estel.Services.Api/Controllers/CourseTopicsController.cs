namespace Estel.Services.Api.Controllers
{
    using System.Threading.Tasks;

    using EstelApi.Application.Dto;
    using EstelApi.Application.Interfaces;
    using EstelApi.Application.Specifications.FindByIdSpec;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using Microsoft.AspNetCore.Mvc;

    /// <inheritdoc />
    /// <summary>
    /// The course topics controller.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("Catalog")]
    public class CourseTopicsController : ApiController
    {
        private ICourseTopicsService service;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Estel.Services.Api.Controllers.CourseTopicsController" /> class.
        /// </summary>
        /// <param name="notifications">
        /// The notifications.
        /// </param>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        public CourseTopicsController( ICourseTopicsService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get All Course Topics.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("CourseTopics")]
        public async Task<IActionResult> Get()
        {
            var result = await this.service.GetCourseTopics();
            return this.Response(result);
        }

        /// <summary>
        /// Get Course Topics By Id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("CourseTopic")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.service.GetCourseTopic(new FindCourseTopicsById().SetId(id));
            return this.Response(result);
        }

        /// <summary>
        /// Delete Course Topics By Id
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpDelete("CourseTopic")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.service.DeleteCourseTopics(new RemoveEntity<CourseTopics>(id));
            return this.Response(result);
        }

        /// <summary>
        /// Create New Course Topics.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost("CourseTopic")]
        public async Task<IActionResult> Post([FromBody] CreateNewCourseTopicsDto command)
        {
            if (!this.ModelState.IsValid)
            {
                return this.ResponseBad("Validation error");
            }

            var resp = await this.service.CreateCourseTopics(command);
            return this.Response(resp);
        }

        /// <summary>
        /// Update Course Topics.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPut("CourseTopic")]
        public async Task<IActionResult> Put([FromBody] UpdateCourseTopicsDto command)
        {
            if (!this.ModelState.IsValid)
            {
                return this.ResponseBad("Validation error");
            }

            var resp = await this.service.UpdateCourseTopics(command);
            return this.Response(resp);
        }
    }
}