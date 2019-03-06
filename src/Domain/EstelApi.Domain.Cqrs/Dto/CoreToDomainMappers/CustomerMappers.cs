using System;
using System.Collections.Generic;
using System.Text;
using EstelApi.Core.Seedwork.CoreEntities;
using EstelApi.Domain.Cqrs.Commands.CustomerCommands;

namespace EstelApi.Domain.Cqrs.Dto.CoreToDomainMappers
{
    public class CustomerMappers : AutoMapper.Profile
    {
        public CustomerMappers()
        {
            this.CreateMap<Customer, CustomerDto>()
                .PreserveReferences()
                .ReverseMap();
        }
    }
}
