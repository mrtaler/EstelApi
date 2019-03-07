using System;
using EstelApi.Application.Cqrs.Commands.Base;
using EstelApi.Core.Seedwork.CoreCqrs.Commands;
using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
using MediatR;

namespace EstelApi.Application.Cqrs.Commands.Commands.CustomerCommands.Commands
{
    public abstract class CustomerCommand : Customer,ICommand, IValidated, IRequest<CommandResponse<Customer>>
    {
        public bool AlreadyValidated { get; set; }
    }
}
