namespace EstelApi.Application.Dto
{
    /// <inheritdoc cref="ICommand" />
    /// <summary>
    /// The remove entity command.
    /// </summary>
    /// <typeparam name="TEntity">entity for delete
    /// </typeparam>
    public class RemoveEntity<TEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveEntity{TEntity}"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public RemoveEntity(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }
    }
}
