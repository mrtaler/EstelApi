using System;
using System.Collections.Generic;
using EstelApi.Domain.Cqrs.Commands.CustomerCommands;
using EstelApi.Domain.Cqrs.Dto;
using MediatR;

namespace EstelApi.Domain.Cqrs.Queries.CustomerQueries
{
    public class AllCustomersQuery : IRequest<IEnumerable<CustomerDto>>
    {
        public AllCustomersQuery()
        {
        }
    }
}