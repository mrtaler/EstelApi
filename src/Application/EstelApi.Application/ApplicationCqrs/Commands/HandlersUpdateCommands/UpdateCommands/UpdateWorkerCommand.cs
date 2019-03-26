namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands.UpdateCommands
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Commands;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using MediatR;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UpdateWorkerCommand : ICommand, IRequest<CommandResponse<Worker>>
    {
        [Required]
        public int Id { get; set; }

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