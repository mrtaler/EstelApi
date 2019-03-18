namespace Estel.Services.Api.ViewModels
{
    using AutoMapper;

    using Estel.Services.Api.ViewModels.Customer;

   // using EstelApi.Application.Dto;

    using Serilog;

    /// <summary>
    /// The dto to cqrs command profile rev.
    /// </summary>
    public class ViewModelToDtoProfileRev : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelToDtoProfileRev"/> class.
        /// </summary>
        public ViewModelToDtoProfileRev()
        {
            Log.Debug($"AutoMapper profile {nameof(ViewModelToDtoProfileRev)} was launch");
         //   this.CreateMap<CreateCustomerViewModel, CustomerDto>(MemberList.Source);
          //  this.CreateMap<UpdateCustomerViewModel, CustomerDto>(MemberList.Source);

            /*  .ForMember(p => p.Id, x => x.Ignore())
                .ForMember(p => p.CreditLimit, x => x.MapFrom(y => 0M))
                .ForMember(p => p.CountryCountryName, x => x.Ignore())
                .ForMember(p => p.PictureRawPhoto, x => x.Ignore());*/

            // this.CreateMap<CustomerDto, CreateCustomerViewModel>();

            //      this.CreateMap<CustomerDto, DeleteCustomerViewModel>().PreserveReferences().ReverseMap();
            //    this.CreateMap<CustomerDto, UpdateCustomerViewModel>().PreserveReferences().ReverseMap();

            // .ConstructUsing(c => new RegisterNewCustomerCommand(c.Name, c.Email, c.BirthDate));
            /* this.CreateMap<UpdateCustomerViewModel, UpdateCustomerCommand>()
                 .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));*/
        }
    }
}