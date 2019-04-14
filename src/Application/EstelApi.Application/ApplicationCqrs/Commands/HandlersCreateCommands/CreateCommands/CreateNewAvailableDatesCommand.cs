namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands.CreateCommands
{
    using System.ComponentModel.DataAnnotations;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using MediatR;

    public class CreateNewAvailableDatesCommand //: ICommand,
                                                //  IRequest<CommandResponse<AvailableDates>>
    {
        [Required]
        public string Month { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string StartHour { get; set; }

        [Required]
        public string EndHour { get; set; }

        public int CourseId { get; set; }
    }
}