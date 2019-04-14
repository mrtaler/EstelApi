namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands.UpdateCommands
{
    using System.ComponentModel.DataAnnotations;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using MediatR;

    /// <inheritdoc cref="ICommand" />
    public class UpdateCourseTopicsCommand //: ICommand, IRequest<CommandResponse<CourseTopics>>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CourseTopicName { get; set; }
    }
}