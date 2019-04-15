namespace Estel.Services.Api.Controllers
{

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Queries;
    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    using System.Threading.Tasks;

    using Estel.Services.Api.ViewModels;

    using EstelApi.Application.ApplicationCqrs.Commands.Course.CreateNewCourse;
    using EstelApi.Application.ApplicationCqrs.Commands.Course.UpdateAvailableDatesForCourse;
    using EstelApi.Application.ApplicationCqrs.Commands.Course.UpdateCourse;
    using EstelApi.Application.ApplicationCqrs.Commands.Course.UpdateCourseTopicsForCourse;
    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
    using EstelApi.Application.Interfaces;

    /// <inheritdoc />
    /// <summary>
    /// The course controller.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("Course")]
    public class CourseController : ApiController
    {
        private ICourseService courseService;
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Estel.Services.Api.Controllers.CourseController" /> class.
        /// </summary>
        /// <param name="notifications">
        /// The notifications.
        /// </param>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("Courses")]
        public async Task<IActionResult> Get()
        {
            var result = await courseService.GetGourses();
            return this.Response(result);
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("Course")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await courseService.GetGourse(new FindCourseById().SetId(id));
            var rs = result.ProjectedAs<CourseViewModel>();
            return this.Response(rs);
        }

        /// <summary>
        /// Delete Course By Id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpDelete("DeleteCourseById")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await courseService.DeleteCourse(new RemoveEntityCommand<Course>(id));
            return this.Response(result);
        }

        /// <summary>
        /// Create New Course.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateNewCourseDto command)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Response(command);
            }

            var resp = await this.courseService.CreateNewCourse(command);
            return this.Response(resp);
        }

        /// <summary>
        /// Update Course.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateCourseDto command)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Response(command);
            }

            var resp = await this.courseService.UpdateCourse(command);
            return this.Response(resp);
        }

        [HttpPut("{courseId}/AvailableDate")]
        public async Task<IActionResult> Put(
            int courseId,
            UpdateAvailableDatesForCourseDto command)
        {
            command.CourseId = courseId;
            var resp = await this.courseService.UpdateAvailDateForCourse(command);

            return this.Response(resp); 
        }

        [HttpPut("{CourseId}/CourseTopics")]
        public async Task<IActionResult> Put(
            int courseId,
            UpdateCourseTopicsForCourseDto command)
        {
           var resp = await this.courseService.UpdateCourseTopics(command);

            return this.Response(resp);
        }


        [HttpPut("{CourseId}/AdditionalAmenity")]
        public async Task<IActionResult> Put(int courseId, UpdateAdditionalAmenityForCourseDto command)
        {
            var resp = await this.courseService.UpdateAddiAmeForCourse(command);

            return this.Response(resp);
        }
    }
}