namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersDeleteCommands
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

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
            INotificationHandler<DomainNotification> notifications,
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
            if (request == null || request.Id == 0)
            {
                await this.bus.Publish(
                    new DomainNotification(
                        request.GetType().Name,
                        "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)"),
                    cancellationToken);
                return new CommandResponse<User>
                {
                    IsSuccess = false,
                    Message =
                                   "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)",
                    Object = null
                };
            }

            var current = this.customerRepository.OneMatching(new FindUserById().SetId(request.Id));

            this.customerRepository.Remove(current);

            return !this.Commit()
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