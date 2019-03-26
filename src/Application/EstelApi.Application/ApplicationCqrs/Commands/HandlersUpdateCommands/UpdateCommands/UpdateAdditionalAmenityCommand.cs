﻿namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands.UpdateCommands
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Commands;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using MediatR;

    public class UpdateAdditionalAmenityCommand : ICommand,
                                                  IRequest<CommandResponse<AdditionalAmenity>>
    {
        [Required(ErrorMessage = "The Amenity Id is Required")]
        [DisplayName("Id Additional Amenity")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Amenity Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Additional Amenity")]
        public string AdditionalAmenityName { get; set; }
    }
}