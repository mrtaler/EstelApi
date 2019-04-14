namespace EstelApi.Application.ApplicationCqrs.Commands.Course.UpdateAvailableDatesForCourse
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Commands;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using MediatR;

    public class UpdateAvailableDatesForCourseCommand : ICommand, IRequest<CommandResponse<bool>>
    {
        public int CourseId { get; set; }
        public int Id { get; set; }
        public string Month { get; set; }
        public string Date { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
    }
}