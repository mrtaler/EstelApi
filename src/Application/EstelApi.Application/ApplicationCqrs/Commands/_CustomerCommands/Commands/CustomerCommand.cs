namespace EstelApi.Application.ApplicationCqrs.Commands._CustomerCommands.Commands
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Commands;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    using MediatR;
    //  using EstelApi.Application.Dto;

    /// <summary>
    /// The customer command.
    /// </summary>
    public abstract class CustomerCommand : Customer, ICommand, IValidated, IRequest<CommandResponse<Customer>>
    {
        /// <summary>
        /// Gets or sets a value indicating whether already validated.
        /// </summary>
        public bool AlreadyValidated { get; set; }
    }
}
