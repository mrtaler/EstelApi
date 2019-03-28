namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersDeleteCommands
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.CrossCutting.Bus;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    /// <inheritdoc cref="CommandHandler" />
    public class DeleteUserCommandHandler : CommandHandler,
                                                IRequestHandler<RemoveEntityCommand<User>, CommandResponse<User>>
    {
        /// <summary>
        /// The customer repository.
        /// </summary>
        private readonly IUserRepository customerRepository;

        /// <inheritdoc />
        public DeleteUserCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainEvent> notifications,
            IUserRepository customerRepository)
            : base(uow, bus, notifications)
        {
            this.customerRepository = customerRepository;
        }

        /// <inheritdoc />
        public async Task<CommandResponse<User>> Handle(
            RemoveEntityCommand<User> request,
            CancellationToken cancellationToken)
        {
            Contract.ThrowIfNull(request, request.GetType().Name, this.Bus);

            var current = this.customerRepository.OneMatching(new FindUserById().SetId(request.Id));

            this.customerRepository.Remove(current);

            return !await this.CommitAsync()
                       ? new CommandResponse<User> { IsSuccess = false, Message = "Delete error", Object = null }
                       : new CommandResponse<User>
                       {
                           IsSuccess = true,
                           Message = "Entity was deleted",
                           Object = current
                       };
        }
    }
}