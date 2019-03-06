using System.Collections.Generic;
using EstelApi.Core.Seedwork.CoreEntities;
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