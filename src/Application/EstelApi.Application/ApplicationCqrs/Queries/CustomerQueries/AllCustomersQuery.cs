using System.Collections.Generic;

using MediatR;

namespace EstelApi.Application.Cqrs.Queries.Queries.CustomerQueries
{
    public class AllCustomersQuery : IRequest<IEnumerable<Customer>>
    {
        public AllCustomersQuery()
        {
        }
    }
}