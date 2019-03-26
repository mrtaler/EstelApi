namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands.UpdateCommands
{
    using System.ComponentModel.DataAnnotations;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Commands;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using MediatR;

    public class UpdateAvailableDatesCommand : ICommand, IRequest<CommandResponse<AvailableDates>>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Month { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string StartHour { get; set; }

        [Required]
        public string EndHour { get; set; }

        public int? CourseId { get; set; }
    }
}