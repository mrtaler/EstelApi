namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands.CreateCommands
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    using MediatR;

    public class CreateNewWorkerCommand //: ICommand,
                                        //  IRequest<CommandResponse<Worker>>
    {
        public int IdentityId { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string MiddleName { get; set; }
        [Required]
        public string Telephone { get; set; }

        public DateTimeOffset BirthDate { get; set; }

        [Required]
        public DateTimeOffset WorkFrom { get; set; }

        public DateTimeOffset? RetirementDate { get; set; }
        [Required]
        public StaffType StaffType { get; set; }
    }
}