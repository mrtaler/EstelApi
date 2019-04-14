namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands.CreateCommands
{
    using System.ComponentModel.DataAnnotations;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Commands;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using MediatR;

    public class CreateNewCourseTopicsCommand : ICommand,
                                                IRequest<CommandResponse<CourseTopics>>
    {
        /// <summary>
        /// Темы раскрываемые на курсах.
        /// </summary>

        [Required]
        public string CourseTopicName { get; set; }
    }
}