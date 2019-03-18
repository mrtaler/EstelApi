namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Commands.UpdateCommands;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The customer command handler.
    /// </summary>
    public class UpdateCustomerCommandHandler : CommandHandler,
                                                IRequestHandler<UpdateCustomerCommand, CommandResponse<Customer>>
    {
        /// <summary>
        /// The _customer repository.
        /// </summary>
        private readonly ICustomerRepository repository;
        
        public UpdateCustomerCommandHandler(
            ICustomerRepository customerRepository,
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            this.repository = customerRepository;
        }

        public async Task<CommandResponse<Customer>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                await this.bus.Publish(
                    new DomainNotification(
                        request.GetType().Name,
                        "message is null"),
                    cancellationToken);
                return new CommandResponse<Customer> { IsSuccess = false, Message = "message is null", Object = null };

                // throw new ArgumentException("_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)");
            }

            this.repository.Modify(request);
            return this.Commit()
                       ? new CommandResponse<Customer> { IsSuccess = true, Message = "New Entity was added", Object = request }
                       : new CommandResponse<Customer> { IsSuccess = false, Message = "New Entity Not added", Object = request };
        }
    }
}
