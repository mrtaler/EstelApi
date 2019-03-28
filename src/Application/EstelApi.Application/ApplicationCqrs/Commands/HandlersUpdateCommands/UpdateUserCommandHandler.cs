namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands.UpdateCommands;
    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.CrossCutting.Bus;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    /// <inheritdoc cref="CommandHandler" />
    /// <summary>
    /// The customer command handler.
    /// </summary>
    public class UpdateUserCommandHandler : CommandHandler,
                                                IRequestHandler<UpdateUserCommand, CommandResponse<User>>
    {
        /// <summary>
        /// The _customer repository.
        /// </summary>
        private readonly IUserRepository repository;
        
        public UpdateUserCommandHandler(
            IUserRepository customerRepository,
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainEvent> notifications)
            : base(uow, bus, notifications)
        {
            this.repository = customerRepository;
        }

        public async Task<CommandResponse<User>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            Contract.ThrowIfNull(request, request.GetType().Name, this.Bus);

            var updateUser = request.ProjectedAs<User>();
            this.repository.Modify(updateUser);
            return await this.CommitAsync()
                       ? new CommandResponse<User> { IsSuccess = true, Message = "New Entity was added", Object = updateUser }
                       : new CommandResponse<User> { IsSuccess = false, Message = "New Entity Not added", Object = updateUser };
        }
    }
}
