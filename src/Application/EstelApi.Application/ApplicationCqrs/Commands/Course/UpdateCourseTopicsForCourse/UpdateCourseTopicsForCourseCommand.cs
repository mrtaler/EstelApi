namespace EstelApi.Application.ApplicationCqrs.Commands.Course.UpdateCourseTopicsForCourse
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Commands;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using MediatR;

    public class UpdateCourseTopicsForCourseCommand : ICommand, IRequest<CommandResponse<bool>>
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string CourseTopicName { get; set; }
    }
}