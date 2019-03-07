namespace EstelApi.Application.Cqrs.Commands.Commands.CustomerCommands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.Cqrs.Commands.Base;
    using EstelApi.Application.Cqrs.Commands.Commands.CustomerCommands.Commands;
    using EstelApi.Application.Cqrs.Commands.Commands.CustomerCommands.Events;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Core.Seedwork.CoreEntities;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    /// <summary>
    /// The customer command handler.
    /// </summary>
    public class CustomerCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewCustomerCommand, CommandResponse<Customer>>,
                                                         IRequestHandler<UpdateCustomerCommand, CommandResponse<Customer>>// ,
    {
        /// <summary>
        /// The _customer repository.
        /// </summary>
        private readonly ICustomerRepository customerRepository;

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
        public async Task<CommandResponse<Customer>> Handle(
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
            var customer = new Customer(Guid.NewGuid(), message.Name, message.Email, message.BirthDate);

            if (this.customerRepository.GetByEmail(customer.Email) != null)
            {
                await this.bus.Publish(
                    new DomainNotification(message.GetType().Name, "The customer e-mail has already been taken."),
                    cancellationToken);
                return new CommandResponse<Customer>
                           {
                               IsSuccess = false, Message = "The customer e-mail has already been taken.", Object = null
                           };
            }

            this.customerRepository.Add(customer);
            if (this.Commit())
            {
                await this.bus.Publish(
                    new CustomerRegisteredEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate),
                    cancellationToken);
            }

            return new CommandResponse<Customer>
                       {
                           IsSuccess = true,
                           Message = "New Entity was added",
                           Object = new Customer(
                               id: customer.Id,
                               name: customer.Name,
                               email: customer.Email,
                               birthDate: customer.BirthDate)
                       };
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
            UpdateCustomerCommand message,
            CancellationToken cancellationToken)
        {
            /*  if (!message.IsValid())
              {
                  NotifyValidationErrors(message);
                  return Task.FromResult(false);
              }
              */
            var customer = new Customer(message.Id, message.Name, message.Email, message.BirthDate);
            var existingCustomer = this.customerRepository.GetByEmail(customer.Email);

            if (existingCustomer != null && existingCustomer.Id != customer.Id)
            {
                if (!existingCustomer.Equals(customer))
                {
                    await this.bus.Publish(
                        new DomainNotification(message.GetType().Name, "The customer e-mail has already been taken."),
                        cancellationToken);
                    return new CommandResponse<Customer>
                               {
                                   IsSuccess = false,
                                   Message = "The customer e-mail has already been taken.",
                                   Object = null
                               };
                }
            }

            this.customerRepository.Update(customer);

            if (this.Commit())
            {
                await this.bus.Publish(
                    new CustomerUpdatedEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate),
                    cancellationToken);
            }

            return new CommandResponse<Customer>
                       {
                           IsSuccess = true,
                           Message = "New Entity was added",
                           Object = new Customer(
                               id: customer.Id,
                               name: customer.Name,
                               email: customer.Email,
                               birthDate: customer.BirthDate)
                       };
        }

        /*
                   public Task<bool> Handle(RemoveCustomerCommand message, CancellationToken cancellationToken)
                   {
                       if (!message.IsValid())
                       {
                           NotifyValidationErrors(message);
                           return Task.FromResult(false);
                       }
                       _customerRepository.Remove(message.Id);
        
                       if (Commit())
                       {
                           _bus.RaiseEvent(new CustomerRemovedEvent(message.Id));
                       }
        
                       return Task.FromResult(true);
                   }*/

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.customerRepository.Dispose();
        }
    }
}
