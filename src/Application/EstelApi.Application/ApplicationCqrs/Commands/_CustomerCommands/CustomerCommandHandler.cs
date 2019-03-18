namespace EstelApi.Application.ApplicationCqrs.Commands._CustomerCommands
{
    // using EstelApi.Application.Dto;
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Commands.CreateCommands;
    using EstelApi.Application.ApplicationCqrs.Commands.UpdateCommands;
    using EstelApi.Application.ApplicationCqrs.Commands._CustomerCommands.Events;
    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    /// <summary>
    /// The customer command handler.
    /// </summary>
    public class CustomerCommandHandler : CommandHandler,
        IRequestHandler<CreateNewCustomerCommand, CommandResponse<Customer>>,
        IRequestHandler<UpdateCustomerCommand, CommandResponse<Customer>>
    {
        /// <summary>
        /// The _customer repository.
        /// </summary>
        private readonly ICustomerRepository customerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCommandHandler"/> class.
        /// </summary>
        /// <param name="customerRepository">
        /// The customer repository.
        /// </param>
        /// <param name="countryRepository">
        /// The Country Repository
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
        public CustomerCommandHandler(
            ICustomerRepository customerRepository,
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            this.customerRepository = customerRepository;
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
        public async Task<CommandResponse<Customer>> Handle(
            CreateNewCustomerCommand message,
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
                    new DomainNotification(message?.GetType().Name, "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)"),
                    cancellationToken);
                return new CommandResponse<Customer>
                {
                    IsSuccess = false,
                    Message = "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)",
                    Object = null
                };

                // throw new ArgumentException("_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)");
            }

            var customer = CustomerFactory.CreateCustomer(
                message.FirstName,
                message.LastName,
                message.Telephone);

            this.customerRepository.Add(customer);

            if (this.Commit())
            {
                await this.bus.Publish(
                    new CustomerRegisteredEvent(
                        customer.Id,
                        customer.FirstName,
                        customer.LastName,
                        customer.Telephone),
                    cancellationToken);
            }

            return new CommandResponse<Customer>
            {
                IsSuccess = true,
                Message = "New Entity was added",
                Object = customer.ProjectedAs<Customer>()
            };
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.customerRepository.Dispose();
        }

        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<CommandResponse<Customer>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                await this.bus.Publish(
                    new DomainNotification(request.GetType().Name, "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)"),
                    cancellationToken);
                return new CommandResponse<Customer>
                {
                    IsSuccess = false,
                    Message = "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)",
                    Object = null
                };
            }

            // get persisted item
            var persisted = this.customerRepository.Get(request.Id);

            // if customer exist
            if (persisted != null)
            {
                // materialize from customer dto
                var current = this.MaterializeCustomerFromDto(request);

                // Merge changes
                this.customerRepository.Merge(persisted, current);

                if (this.Commit())
                {
                    await this.bus.Publish(
                        new CustomerUpdatedEvent(
                            current.Id,
                            current.FirstName,
                            current.LastName,
                            current.Telephone),
                        cancellationToken);
                    return new CommandResponse<Customer>
                    {
                        IsSuccess = true,
                        Message = "Entity was changed",
                        Object = current.ProjectedAs<Customer>()
                    };
                }
            }

            return new CommandResponse<Customer>
            {
                IsSuccess = true,
                Message = "New Entity was added",
                Object = null
            };
        }

        /// <summary>
        /// The materialize customer from dto.
        /// </summary>
        /// <param name="customerDTO">
        /// The customer dto.
        /// </param>
        /// <returns>
        /// The <see cref="Customer"/>.
        /// </returns>
        private Customer MaterializeCustomerFromDto(Customer customerDTO)
        {
            // create the current instance with changes from customerDTO
            var current = CustomerFactory.CreateCustomer(
                customerDTO.FirstName,
                customerDTO.LastName,
                customerDTO.Telephone);

            current.ChangePicture(customerDTO.LogoPath);

            // set identity
            current.Id = customerDTO.Id;
            return current;
        }
    }
}
