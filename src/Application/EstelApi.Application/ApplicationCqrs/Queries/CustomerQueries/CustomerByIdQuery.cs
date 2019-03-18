﻿namespace EstelApi.Application.ApplicationCqrs.Queries.CustomerQueries
{
    using System;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    //   using EstelApi.Application.Dto;

    using MediatR;

    /// <summary>
    /// The customer by id query.
    /// </summary>
    public class CustomerByIdQuery : IRequest<Customer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerByIdQuery"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public CustomerByIdQuery(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }
    }
}
