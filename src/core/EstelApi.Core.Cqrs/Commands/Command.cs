using System;
using EstelApi.Core.Cqrs.Events;
using FluentValidation.Results;

namespace EstelApi.Core.Cqrs.Commands
{

    public interface ICommand
    {
    }

    public interface IValidated
    {
        bool AlreadyValidated { get; set; }
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
