﻿namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands.CreateCommands
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Commands;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using MediatR;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class CreateNewAdditionalAmenityCommand : ICommand,
                                                     IRequest<CommandResponse<AdditionalAmenity>>
    {
        /// <summary>
        /// Раименование Плюшек от трениннга (кофе, сертификаты, призы и тд.).
        /// </summary>
        [Required(ErrorMessage = "The Amenity Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Additional Amenity")]
        public string AdditionalAmenityName { get; set; }
    }
}