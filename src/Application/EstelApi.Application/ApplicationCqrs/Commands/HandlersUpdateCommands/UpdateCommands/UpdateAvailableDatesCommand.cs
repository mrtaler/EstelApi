﻿namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands.UpdateCommands
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Commands;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using MediatR;

    public class UpdateAvailableDatesCommand : AvailableDates, ICommand, IRequest<CommandResponse<AvailableDates>>
    {
    }
}