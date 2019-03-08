namespace EstelApi.Application.ApplicationCqrs.Queries.CustomerQueries
{
    using System;

    using EstelApi.Application.Dto;

    using MediatR;

    /// <summary>
    /// The customer by id query.
    /// </summary>
    public class CustomerByIdQuery : IRequest<CustomerDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerByIdQuery"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public CustomerByIdQuery(Guid id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public Guid Id { get; set; }
    }
}
