using AutoMapper;
using EstelApi.Application.ViewModels.Customer;
using EstelApi.Core.Seedwork.CoreEntities;

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