namespace EstelApi.Application.ApplicationCqrs.Commands.CreateCommands
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Commands;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    using MediatR;

    public class CreateNewWorkerCommand : Worker,
                                          ICommand,
                                          IRequest<CommandResponse<Worker>>
    {

    }
}