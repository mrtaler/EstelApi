using System;

using MediatR;

namespace EstelApi.Application.Cqrs.Queries.Queries.CustomerQueries
{
    public  class CustomerByIdQuery : IRequest<Customer>
    {
        public Guid Id { get; set; }
        public CustomerByIdQuery(Guid id)
        {
            this.Id = id;
        }
    }
}
