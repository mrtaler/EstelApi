using AutoMapper;
using EstelApi.Application.ViewModels;
using EstelApi.Core.Entities;

namespace EstelApi.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}