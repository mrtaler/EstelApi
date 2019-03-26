namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands.CreateCommands
{
    using System.ComponentModel.DataAnnotations;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Commands;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using MediatR;

    public class CreateNewCourseTypeCommand : ICommand,
                                              IRequest<CommandResponse<CourseType>>
    {
        /// <summary>
        /// Gets or sets the course type name.
        /// </summary>
        [Required]
        public string CourseTypeName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [Required]
        public string Description { get; set; }
    }
}