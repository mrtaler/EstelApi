namespace EstelApi.Core.Seedwork.CoreCqrs.Commands
{
    public interface IValidated
    {
        bool AlreadyValidated { get; set; }
    }
}