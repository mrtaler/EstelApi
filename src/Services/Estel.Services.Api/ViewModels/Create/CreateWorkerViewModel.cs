namespace Estel.Services.Api.ViewModels.Create
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    public class CreateWorkerViewModel
    {
        [Required]
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
        public StaffType StaffType { get; set; }
    }
}