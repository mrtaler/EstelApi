namespace EstelApi.Application.ApplicationCqrs.Commands.UpdateCommands
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Commands;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    using MediatR;

    public class UpdateCustomerCommand : Customer, ICommand, IRequest<CommandResponse<Customer>>
    {
    }
}