namespace EstelApi.Application.ApplicationCqrs.Commands.CustomerCommands.Validations
{
    using EstelApi.Application.ApplicationCqrs.Commands.CustomerCommands.Commands;

    public class RemoveCustomerCommandValidation : CustomerValidation<RemoveCustomerCommand>
    {
        public RemoveCustomerCommandValidation()
        {
            this.ValidateId();
        }
    }
}