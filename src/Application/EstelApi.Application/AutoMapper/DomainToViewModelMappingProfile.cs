using AutoMapper;
using EstelApi.Application.ViewModels.Customer;
using EstelApi.Domain.Cqrs.Dto;

namespace EstelApi.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<CustomerDto, CustomerViewModelApp>();
        }
    }
}