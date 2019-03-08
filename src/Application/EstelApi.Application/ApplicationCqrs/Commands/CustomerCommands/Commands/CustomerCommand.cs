namespace EstelApi.Application.ApplicationCqrs.Commands.CustomerCommands.Commands
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.Dto;
    using EstelApi.Core.Seedwork.CoreCqrs.Commands;

    using MediatR;

    /// <summary>
    /// The customer command.
    /// </summary>
    public abstract class CustomerCommand : CustomerDto, ICommand, IValidated, IRequest<CommandResponse<CustomerDto>>
    {
        /// <summary>
        /// Gets or sets a value indicating whether already validated.
        /// </summary>
        public bool AlreadyValidated { get; set; }
    }
}
