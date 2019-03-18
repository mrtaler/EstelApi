﻿namespace Estel.Services.Api.ViewModels.Update
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    public class UpdateWorkerViewModel
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