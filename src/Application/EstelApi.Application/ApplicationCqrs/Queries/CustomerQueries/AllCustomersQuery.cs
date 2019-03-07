namespace EstelApi.Application.ApplicationCqrs.Queries.CustomerQueries
{
    using System.Collections.Generic;

    using MediatR;

    public class AllCustomersQuery : IRequest<IEnumerable<Customer>>
    {
        public AllCustomersQuery()
        {
        }
    }
}