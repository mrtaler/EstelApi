namespace EstelApi.Application.ApplicationCqrs.Queries.CustomerQueries
{
    using System;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    //   using EstelApi.Application.Dto;

    using MediatR;

    /// <summary>
    /// The customer by id query.
    /// </summary>
    public class AdditionalAmenityByIdQuery : IRequest<AdditionalAmenity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionalAmenityByIdQuery"/> class. 
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public AdditionalAmenityByIdQuery(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }
    }
}
