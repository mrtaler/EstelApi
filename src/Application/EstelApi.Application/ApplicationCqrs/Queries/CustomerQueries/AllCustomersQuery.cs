namespace EstelApi.Application.ApplicationCqrs.Queries.CustomerQueries
{
    using System.Collections.Generic;

    using EstelApi.Application.Dto;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    using MediatR;

    public class AllCustomersQuery : IRequest<IEnumerable<CustomerDto>>
    {
        public AllCustomersQuery()
        {
        }
    }
}