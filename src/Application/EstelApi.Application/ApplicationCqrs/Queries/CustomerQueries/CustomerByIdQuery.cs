namespace EstelApi.Application.ApplicationCqrs.Queries.CustomerQueries
{
    using System;

    using MediatR;

    public  class CustomerByIdQuery : IRequest<Customer>
    {
        public Guid Id { get; set; }
        public CustomerByIdQuery(Guid id)
        {
            this.Id = id;
        }
    }
}
