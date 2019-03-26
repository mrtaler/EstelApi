﻿namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands.CreateCommands
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Commands;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using MediatR;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class CreateNewUserCommand : ICommand,
                                            IRequest<CommandResponse<User>>
    {
        /// <summary>
        /// The customer first name
        /// </summary>
        [Required(ErrorMessage = "The First Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// The customer lastName
        /// </summary>
        [Required(ErrorMessage = "The Last Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Telephone")]
        public string Telephone { get; set; }

        public int IdentityId { get; set; }

        public string MiddleName { get; set; }

        public DateTimeOffset BirthDate { get; set; }
    }
}