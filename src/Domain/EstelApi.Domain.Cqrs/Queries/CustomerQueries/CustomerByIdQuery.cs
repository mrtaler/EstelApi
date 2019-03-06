using System;
using EstelApi.Domain.Cqrs.Commands.CustomerCommands;
using EstelApi.Domain.Cqrs.Dto;
using MediatR;

namespace EstelApi.Domain.Cqrs.Queries.CustomerQueries
{
    public  class CustomerByIdQuery : IRequest<CustomerDto>
    {
        public Guid Id { get; set; }
        public CustomerByIdQuery(Guid id)
        {
            this.Id = id;
        }
    }
}
