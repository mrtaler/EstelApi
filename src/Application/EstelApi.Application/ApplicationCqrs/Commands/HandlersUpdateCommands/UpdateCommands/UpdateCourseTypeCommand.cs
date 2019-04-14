namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands.UpdateCommands
{
    using System.ComponentModel.DataAnnotations;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using MediatR;

    /// <inheritdoc cref="ICommand" />
    public class UpdateCourseTypeCommand //: ICommand, IRequest<CommandResponse<CourseType>>
    {
        [Required]
        public int Id { get; set; }

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