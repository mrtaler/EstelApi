namespace Estel.Services.Api.Controllers
{
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Queries;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    public class CourseAttendanceController : ApiController
    {
        public CourseAttendanceController(INotificationHandler<DomainNotification> notifications, IMediator mediator)
            : base(notifications, mediator)
        {
        }

        [HttpGet("GetAllCourseAttendance")]
        public async Task<IActionResult> Get()
        {
            var result = await this.mediator.Send(new AllEntitiesQuery<CourseAttendance>());
            return this.Response(result);
        }

        [HttpGet("GetCourseAttendanceById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.mediator.Send(new EntityByIdQuery<CourseAttendance>(id));
            return this.Response(result);
        }

        [HttpDelete("DeleteCourseAttendanceById")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.mediator.Send(new RemoveEntityCommand<CourseAttendance>(id));
            return this.Response(result);
        }
        }
}