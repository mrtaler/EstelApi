namespace EstelApi.Core.Seedwork.Interfaces
{
    /// <summary>
    /// The Entity interface.
    /// </summary>
    /// <typeparam name="T">Type for Id key
    /// </typeparam>
    public interface IEntity<T>
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        T Id { get; set; }
    }
}