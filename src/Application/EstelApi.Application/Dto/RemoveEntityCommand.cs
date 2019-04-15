namespace EstelApi.Application.Dto
{
    /// <inheritdoc cref="ICommand" />
    /// <summary>
    /// The remove entity command.
    /// </summary>
    /// <typeparam name="TEntity">entity for delete
    /// </typeparam>
    public class RemoveEntityCommand<TEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveEntityCommand{TEntity}"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public RemoveEntityCommand(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }
    }
}
