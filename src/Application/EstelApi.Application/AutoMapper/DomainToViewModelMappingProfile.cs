using AutoMapper;

namespace EstelApi.Application.AutoMapper
{
    using EstelApi.Application.Dto;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            this.CreateMap<Customer, CustomerDto>()
                .PreserveReferences()
                .ReverseMap();
        }
    }
}