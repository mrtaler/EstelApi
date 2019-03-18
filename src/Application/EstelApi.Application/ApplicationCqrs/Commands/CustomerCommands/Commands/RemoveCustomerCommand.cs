namespace EstelApi.Application.ApplicationCqrs.Commands.CustomerCommands.Commands
{
    using System;

    /// <inheritdoc />
    public class RemoveCustomerCommand : CustomerCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveCustomerCommand"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public RemoveCustomerCommand(int id)
        {
            this.Id = id;
        }
    }
}