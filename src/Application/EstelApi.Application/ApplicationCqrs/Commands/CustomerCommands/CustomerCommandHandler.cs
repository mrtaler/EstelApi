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
        IRequestHandler<UpdateCustomerCommand, CommandResponse<CustomerDto>>
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

            if (message == null || message.CountryId == Guid.Empty)
            {
                await this.bus.Publish(
                    new DomainNotification(message.GetType().Name, "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)"),
                    cancellationToken);
                return new CommandResponse<CustomerDto>
                {
                    IsSuccess = false,
                    Message = "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)",
                    Object = null
                };

                // throw new ArgumentException("_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)");
            }

            var country = this.countryRepository.GetById(message.CountryId);

            if (country != null)
            {
                var address = new Address(
                    message.AddressCity,
                    message.AddressZipCode,
                    message.AddressAddressLine1,
                    message.AddressAddressLine2);

                var customer = CustomerFactory.CreateCustomer(
                    message.FirstName,
                    message.LastName,
                    message.Telephone,
                    message.Company,
                    country,
                    address);

                this.customerRepository.Add(customer);

                if (this.Commit())
                {
                    await this.bus.Publish(
                        new CustomerRegisteredEvent(
                            customer.Id,
                            customer.FirstName,
                            customer.LastName,
                            customer.Telephone,
                            customer.Company,
                            customer.CountryId,
                            customer.Address.City,
                            customer.Address.ZipCode,
                            customer.Address.AddressLine1,
                            customer.Address.AddressLine2),
                        cancellationToken);
                }

                return new CommandResponse<CustomerDto>
                {
                    IsSuccess = true,
                    Message = "New Entity was added",
                    Object = customer.ProjectedAs<CustomerDto>()
                };
            }

            return new CommandResponse<CustomerDto>
            {
                IsSuccess = false,
                Message = "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)",
                Object = null
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
            if (request == null || request.CountryId == Guid.Empty)
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
            var persisted = this.customerRepository.GetById(request.Id);

            // if customer exist
            if (persisted != null)
            {
                // materialize from customer dto
                var current = MaterializeCustomerFromDto(request);

                //Merge changes

               this.customerRepository.Update(current);

   //   this.customerRepository.Merge(persisted, current);
                if (this.Commit())
                {
                    await this.bus.Publish(
                        new CustomerUpdatedEvent(
                            current.Id,
                            current.FirstName,
                            current.LastName,
                            current.Telephone,
                            current.Company,
                            current.CreditLimit,
                            current.CountryId,
                            current.Address.City,
                            current.Address.ZipCode,
                            current.Address.AddressLine1,
                            current.Address.AddressLine2),
                        cancellationToken);
                    return new CommandResponse<CustomerDto>
                    {
                        IsSuccess = true,
                        Message = "New Entity was added",
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

        Customer MaterializeCustomerFromDto(CustomerDto customerDTO)
        {
            //create the current instance with changes from customerDTO
            var address = new Address(
                customerDTO.AddressCity,
                customerDTO.AddressZipCode,
                customerDTO.AddressAddressLine1,
                customerDTO.AddressAddressLine2);

         /*   Country country = new Country("Spain", "es-ES");
            country.ChangeCurrentIdentity(customerDTO.CountryId);*/
            
            var current = CustomerFactory.CreateCustomer(customerDTO.FirstName,
                customerDTO.LastName,
                customerDTO.Telephone,
                customerDTO.Company,
                null,
                address);
            current.SetTheCountryReference(customerDTO.CountryId);
            current.SetTheCountryReference(customerDTO.Id);

            //set credit
            current.ChangeTheCurrentCredit(customerDTO.CreditLimit);

            //set picture

                var picture = new Picture { RawPhoto = customerDTO.PictureRawPhoto };
                picture.ChangeCurrentIdentity(current.Id);

                current.ChangePicture(picture);
       
            //set identity
            current.ChangeCurrentIdentity(customerDTO.Id);


            return current;
        }
    }
}
