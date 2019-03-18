namespace EstelApi.Application.ApplicationCqrs.Queries.CustomerQueries
{
    using System.Collections.Generic;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    // using EstelApi.Application.Dto;

    using MediatR;

    /// <summary>
    /// The all customers query.
    /// </summary>
    /// <typeparam name="TEntity">db Entity
    /// </typeparam>
    public class AllEntitiesQuery<TEntity> : IRequest<IEnumerable<TEntity>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AllEntitiesQuery{TEntity}"/> class.
        /// </summary>
        public AllEntitiesQuery()
        {
        }
    }
}