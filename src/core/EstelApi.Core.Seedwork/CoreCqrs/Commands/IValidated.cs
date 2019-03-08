namespace EstelApi.Core.Seedwork.CoreCqrs.Commands
{
    /// <summary>
    /// The Validated interface.
    /// Using in CQRS command if Fluent Validation needed
    /// </summary>
    public interface IValidated
    {
        /// <summary>
        /// Gets or sets a value indicating whether already validated.
        /// </summary>
        bool AlreadyValidated { get; set; }
    }
}