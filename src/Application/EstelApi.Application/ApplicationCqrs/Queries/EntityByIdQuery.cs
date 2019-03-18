namespace EstelApi.Application.ApplicationCqrs.Queries.CustomerQueries
{
    using System;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    //   using EstelApi.Application.Dto;

    using MediatR;

    /// <summary>
    /// The entity by id query.
    /// </summary>
    /// <typeparam name="TEntity">db Entity
    /// </typeparam>
    public class EntityByIdQuery<TEntity> : IRequest<TEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityByIdQuery{TEntity}"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public EntityByIdQuery(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }
    }
}
