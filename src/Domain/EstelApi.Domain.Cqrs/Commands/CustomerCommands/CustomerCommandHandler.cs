﻿using System;
using System.Threading;
using System.Threading.Tasks;
using EstelApi.Core.Cqrs.Bus;
using EstelApi.Core.Cqrs.Notifications;
using EstelApi.Core.Entities;
using EstelApi.Domain.Cqrs.Base;
using EstelApi.Domain.Cqrs.Commands.CustomerCommands.Commands;
using EstelApi.Domain.Cqrs.Commands.CustomerCommands.Events;
using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
using EstelApi.Domain.DataAccessLayer.Interfaces;
using MediatR;

namespace EstelApi.Domain.Cqrs.Commands.CustomerCommands
{
    public class CustomerCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewCustomerCommand, bool>,
        IRequestHandler<UpdateCustomerCommand, bool>,
        IRequestHandler<RemoveCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediatorHandler _bus;

        public CustomerCommandHandler(ICustomerRepository customerRepository,
            IQueryableUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _customerRepository = customerRepository;
            _bus = bus;
        }

        public Task<bool> Handle(RegisterNewCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var customer = new Customer(Guid.NewGuid(), message.Name, message.Email, message.BirthDate);

            if (_customerRepository.GetByEmail(customer.Email) != null)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "The customer e-mail has already been taken."));
                return Task.FromResult(false);
            }

            _customerRepository.Add(customer);
            if (Commit())
            {
                _bus.RaiseEvent(new CustomerRegisteredEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var customer = new Customer(message.Id, message.Name, message.Email, message.BirthDate);
            var existingCustomer = _customerRepository.GetByEmail(customer.Email);

            if (existingCustomer != null && existingCustomer.Id != customer.Id)
            {
                if (!existingCustomer.Equals(customer))
                {
                    _bus.RaiseEvent(new DomainNotification(message.MessageType, "The customer e-mail has already been taken."));
                    return Task.FromResult(false);
                }
            }

            _customerRepository.Update(customer);

            if (Commit())
            {
                _bus.RaiseEvent(new CustomerUpdatedEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));
            }

            return Task.FromResult(true);
        }

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
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
        }
    }
}
