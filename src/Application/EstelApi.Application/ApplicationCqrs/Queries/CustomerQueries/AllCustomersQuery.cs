﻿namespace EstelApi.Application.ApplicationCqrs.Queries.CustomerQueries
{
    using System.Collections.Generic;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    // using EstelApi.Application.Dto;

    using MediatR;

    /// <summary>
    /// The all customers query.
    /// </summary>
    public class AllCustomersQuery : IRequest<IEnumerable<Customer>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AllCustomersQuery"/> class.
        /// </summary>
        public AllCustomersQuery()
        {
        }
    }
}