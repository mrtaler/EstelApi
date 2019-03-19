namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands.CreateCommands;

    /// <summary>
    /// The customer command handler.
    /// </summary>
    public class CreateUserCommandHandler : CommandHandler,
                                                IRequestHandler<CreateNewUserCommand, CommandResponse<User>>


    {
        /// <summary>
        /// The _customer repository.
        /// </summary>
        private readonly IUserRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCustomerCommandHandler"/> class. 
        /// </summary>
        /// <param name="customerRepository">
        /// The customer repository.
        /// </param>
        /// <param name="uow">
        /// The uow.
        /// </param>
        /// <param name="bus">
        /// The bus.
        /// </param>
        /// <param name="notifications">
        /// The notifications.
        /// </param>
        public CreateUserCommandHandler(
            IUserRepository customerRepository,
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            this.repository = customerRepository;
        }

        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<CommandResponse<User>> Handle(
            CreateNewUserCommand message,
            CancellationToken cancellationToken)
        {
            // todo transfer to mediatr validationPipeline
            /*if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }
            */

            if (message == null)
            {
                await this.bus.Publish(
                    new DomainNotification(
                        message.GetType().Name,
                        "message is null"),
                    cancellationToken);
                return new CommandResponse<User> { IsSuccess = false, Message = "message is null", Object = null };

                // throw new ArgumentException("_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)");
            }

            this.repository.Add(message);

            return this.Commit()
                       ? new CommandResponse<User> { IsSuccess = true, Message = "New Entity was added", Object = message }
                       : new CommandResponse<User> { IsSuccess = false, Message = "New Entity Not added", Object = message };

        }

    }
}
