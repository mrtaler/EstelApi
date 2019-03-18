namespace EstelApi.Application.ApplicationCqrs.Commands.DeleteCommands
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    public class DeleteCustomerCommandHandler : CommandHandler,
                                                IRequestHandler<RemoveEntityCommand<Customer>, CommandResponse<Customer>>
    {
        private ICustomerRepository customerRepository;

        public DeleteCustomerCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainNotification> notifications,
            ICustomerRepository customerRepository)
            : base(uow, bus, notifications)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<CommandResponse<Customer>> Handle(
            RemoveEntityCommand<Customer> request,
            CancellationToken cancellationToken)
        {
            if (request == null || request.Id == 0)
            {
                await this.bus.Publish(
                    new DomainNotification(
                        request.GetType().Name,
                        "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)"),
                    cancellationToken);
                return new CommandResponse<Customer>
                           {
                               IsSuccess = false,
                               Message =
                                   "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)",
                               Object = null
                           };
            }

            var current = this.customerRepository.Get(request.Id);

            this.customerRepository.Remove(current);

            return !this.Commit()
                       ? new CommandResponse<Customer> { IsSuccess = false, Message = "Delete error", Object = null }
                       : new CommandResponse<Customer>
                             {
                                 IsSuccess = true,
                                 Message = "Entity was deleted",
                                 Object = current
                             };
        }
    }
}