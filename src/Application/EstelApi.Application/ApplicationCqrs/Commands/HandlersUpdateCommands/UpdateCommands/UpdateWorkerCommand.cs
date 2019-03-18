namespace EstelApi.Application.ApplicationCqrs.Commands.UpdateCommands
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Commands;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    using MediatR;

    public class UpdateWorkerCommand : Worker, ICommand, IRequest<CommandResponse<Worker>>
    {
    }
}