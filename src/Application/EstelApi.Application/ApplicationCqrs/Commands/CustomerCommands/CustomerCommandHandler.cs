namespace EstelApi.Application.ApplicationCqrs.Commands.CustomerCommands
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Commands.CustomerCommands.Commands;
    using EstelApi.Application.ApplicationCqrs.Commands.CustomerCommands.Events;
    using EstelApi.Application.Dto;
    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CountryAgg;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The customer command handler.
    /// </summary>
    public class CustomerCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewCustomerCommand, CommandResponse<CustomerDto>>,
        IRequestHandler<UpdateCustomerCommand, CommandResponse<CustomerDto>>,
        IRequestHandler<RemoveCustomerCommand, CommandResponse<CustomerDto>>
    {
        /// <summary>
        /// The _customer repository.
        /// </summary>
        private readonly ICustomerRepository customerRepository;

        /// <summary>
        /// The _country repository.
        /// </summary>
        private readonly ICountryRepository countryRepository;

        /// <summary>
        /// The _bus.
        /// </summary>
        private readonly IMediator bus;

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
             ICountryRepository countryRepository,
             IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            this.customerRepository = customerRepository;
            this.countryRepository = countryRepository;
            this.bus = bus;
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
        public async Task<CommandResponse<CustomerDto>> Handle(
            RegisterNewCustomerCommand message,
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
                return new CommandResponse<CustomerDto>
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

            return new CommandResponse<CustomerDto>
            {
                IsSuccess = true,
                Message = "New Entity was added",
                Object = customer.ProjectedAs<CustomerDto>()
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
        public async Task<CommandResponse<CustomerDto>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                await this.bus.Publish(
                    new DomainNotification(request.GetType().Name, "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)"),
                    cancellationToken);
                return new CommandResponse<CustomerDto>
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
                    return new CommandResponse<CustomerDto>
                    {
                        IsSuccess = true,
                        Message = "Entity was changed",
                        Object = current.ProjectedAs<CustomerDto>()
                    };
                }
            }

            return new CommandResponse<CustomerDto>
            {
                IsSuccess = true,
                Message = "New Entity was added",
                Object = null
            };
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
        public async Task<CommandResponse<CustomerDto>> Handle(RemoveCustomerCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.Id == Guid.Empty)
            {
                await this.bus.Publish(
                    new DomainNotification(request.GetType().Name, "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)"),
                    cancellationToken);
                return new CommandResponse<CustomerDto>
                {
                    IsSuccess = false,
                    Message = "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)",
                    Object = null
                };
            }

            var current = this.customerRepository.Get(request.Id);

            this.customerRepository.Remove(current);

            if (this.Commit())
            {
                await this.bus.Publish(
                    new CustomerRemovedEvent(
                        current.Id),
                    cancellationToken);
                return new CommandResponse<CustomerDto>
                {
                    IsSuccess = true,
                    Message = "Entity was changed",
                    Object = current.ProjectedAs<CustomerDto>()
                };
            }

            return new CommandResponse<CustomerDto>
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
        private Customer MaterializeCustomerFromDto(CustomerDto customerDTO)
        {
            // create the current instance with changes from customerDTO
            var current = CustomerFactory.CreateCustomer(
                customerDTO.FirstName,
                customerDTO.LastName,
                customerDTO.Telephone);

            current.ChangePicture(customerDTO.LogoPhotoPath);

            // set identity
            current.ChangeCurrentIdentity(customerDTO.Id);
            return current;
        }
    }
}
