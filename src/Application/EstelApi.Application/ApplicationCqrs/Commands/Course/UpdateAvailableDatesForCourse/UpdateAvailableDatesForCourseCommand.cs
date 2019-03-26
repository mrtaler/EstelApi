namespace EstelApi.Application.ApplicationCqrs.Commands.Course.UpdateAvailableDatesForCourse
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Commands;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using MediatR;

    public class UpdateAvailableDatesForCourseCommand : AvailableDates, ICommand, IRequest<CommandResponse<bool>>
    {
        public int CourseId { get; set; }
    }
}