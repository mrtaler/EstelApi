namespace EstelApi.Application.ApplicationCqrs.Queries.CustomerQueries
{
    using System;

    using EstelApi.Application.Dto;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    using MediatR;

    public  class CustomerByIdQuery : IRequest<CustomerDto>
    {
        public Guid Id { get; set; }
        public CustomerByIdQuery(Guid id)
        {
            this.Id = id;
        }
    }
}
