using AutoMapper;
using EstelApi.Application.ViewModels.Customer;

namespace EstelApi.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            this.CreateMap<Customer, CustomerViewModelApp>();
        }
    }
}