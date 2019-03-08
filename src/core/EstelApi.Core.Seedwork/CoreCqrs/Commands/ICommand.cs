namespace EstelApi.Core.Seedwork.CoreCqrs.Commands
{
    /// <summary>
    /// The CQRS Command interface.
    /// </summary>
    public interface ICommand
    {
    }

    /* public abstract class Command : Message
     {
         public DateTime Timestamp { get; private set; }
         public ValidationResult ValidationResult { get; set; }

         protected Command()
         {
             Timestamp = DateTime.Now;
         }

         public abstract bool IsValid();
     }*/
}
