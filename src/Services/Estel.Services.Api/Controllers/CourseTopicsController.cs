//namespace Estel.Services.Api.Controllers
//{
//    using System.Threading.Tasks;

//    using EstelApi.Application.ApplicationCqrs.Base;
//    using EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands.CreateCommands;
//    using EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands.UpdateCommands;
//    using EstelApi.Application.ApplicationCqrs.Queries;
//    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

//    using MediatR;

//    using Microsoft.AspNetCore.Mvc;

//    /// <inheritdoc />
//    /// <summary>
//    /// The course topics controller.
//    /// </summary>
//    [ApiVersion("1.0")]
//    [Route("Catalog")]
//    public class CourseTopicsController : ApiController
//    {
//        /// <inheritdoc />
//        /// <summary>
//        /// Initializes a new instance of the <see cref="T:Estel.Services.Api.Controllers.CourseTopicsController" /> class.
//        /// </summary>
//        /// <param name="notifications">
//        /// The notifications.
//        /// </param>
//        /// <param name="mediator">
//        /// The mediator.
//        /// </param>
//        public CourseTopicsController(INotificationHandler<DomainEvent> notifications, IMediator mediator)
//            : base(notifications, mediator)
//        {
//        }

//        /// <summary>
//        /// Get All Course Topics.
//        /// </summary>
//        /// <returns>
//        /// The <see cref="Task"/>.
//        /// </returns>
//        [HttpGet("CourseTopics")]
//        public async Task<IActionResult> Get()
//        {
//            var result = await this.Mediator.Send(new AllEntitiesQuery<CourseTopics>());
//            return this.Response(result);
//        }

//        /// <summary>
//        /// Get Course Topics By Id.
//        /// </summary>
//        /// <param name="id">
//        /// The id.
//        /// </param>
//        /// <returns>
//        /// The <see cref="Task"/>.
//        /// </returns>
//        [HttpGet("CourseTopic")]
//        public async Task<IActionResult> Get(int id)
//        {
//            var result = await this.Mediator.Send(new EntityByIdQuery<CourseTopics>(id));
//            return this.Response(result);
//        }

//        /// <summary>
//        /// Delete Course Topics By Id
//        /// </summary>
//        /// <param name="id">
//        /// The id.
//        /// </param>
//        /// <returns>
//        /// The <see cref="Task"/>.
//        /// </returns>
//        [HttpDelete("CourseTopic")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var result = await this.Mediator.Send(new RemoveEntityCommand<CourseTopics>(id));
//            return this.Response(result);
//        }

//        /// <summary>
//        /// Create New Course Topics.
//        /// </summary>
//        /// <param name="command">
//        /// The command.
//        /// </param>
//        /// <returns>
//        /// The <see cref="Task"/>.
//        /// </returns>
//        [HttpPost("CourseTopic")]
//        public async Task<IActionResult> Post([FromBody] CreateNewCourseTopicsCommand command)
//        {
//            if (!this.ModelState.IsValid)
//            {
//                this.NotifyModelStateErrors();
//                return this.Response(command);
//            }

//            var resp = await this.Mediator.Send(command);
//            return this.Response(resp);
//        }

//        /// <summary>
//        /// Update Course Topics.
//        /// </summary>
//        /// <param name="command">
//        /// The command.
//        /// </param>
//        /// <returns>
//        /// The <see cref="Task"/>.
//        /// </returns>
//        [HttpPut("CourseTopic")]
//        public async Task<IActionResult> Put([FromBody] UpdateCourseTopicsCommand command)
//        {
//            if (!this.ModelState.IsValid)
//            {
//                this.NotifyModelStateErrors();
//                return this.Response(command);
//            }

//            var resp = await this.Mediator.Send(command);
//            return this.Response(resp);
//        }
//    }
//}