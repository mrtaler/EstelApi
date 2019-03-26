namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands.UpdateCommands
{
    using System.ComponentModel.DataAnnotations;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Commands;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using MediatR;

    public class UpdateCourseTopicsCommand : ICommand, IRequest<CommandResponse<CourseTopics>>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CourseTopicName { get; set; }
    }
}