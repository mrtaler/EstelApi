namespace Estel.Services.Api.ViewModels
{
    using AutoMapper;

    using Estel.Services.Api.ViewModels.Create;
    using Estel.Services.Api.ViewModels.Update;

    using EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands.CreateCommands;
    using EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands.UpdateCommands;
    using EstelApi.Application.ApplicationCqrs.Commands.NewFolder;

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
            this.CreateMap<CreateAdditionalAmenityViewModel, CreateNewAdditionalAmenityCommand>(MemberList.Source);
            this.CreateMap<CreateAvailableDatesViewModel, CreateNewAvailableDatesCommand>(MemberList.Source);
            this.CreateMap<CreateCourseTopicsViewModel, CreateNewCourseTopicsCommand>(MemberList.Source);
            this.CreateMap<CreateCourseTypeViewModel, CreateNewCourseTypeCommand>(MemberList.Source);
            this.CreateMap<CreateCourseViewModel, CreateNewCourseCommand>(MemberList.Source);
            this.CreateMap<CreateUserViewModel, CreateNewUserCommand>(MemberList.Source);
            this.CreateMap<CreateWorkerViewModel, CreateNewWorkerCommand>(MemberList.Source);


            this.CreateMap<UpdateAdditionalAmenityViewModel, UpdateAdditionalAmenityCommand>(MemberList.Source);
            this.CreateMap<UpdateAvailableDatesViewModel, UpdateAvailableDatesCommand>(MemberList.Source);
            this.CreateMap<UpdateCourseTopicsViewModel, UpdateCourseTopicsCommand>(MemberList.Source);
            this.CreateMap<UpdateCourseTypeViewModel, UpdateCourseTypeCommand>(MemberList.Source);
            this.CreateMap<UpdateCourseViewModel, UpdateCourseCommand>(MemberList.Source);
            this.CreateMap<UpdateUserViewModel, UpdateUserCommand>(MemberList.Source);
            this.CreateMap<UpdateWorkerViewModel, UpdateWorkerCommand>(MemberList.Source);
            this.CreateMap<UpdateAvailableDatesViewModel, UpdateAvailableDatesForCourse>(MemberList.Source);
            /*  .ForMember(p => p.Id, x => x.Ignore())
                .ForMember(p => p.CreditLimit, x => x.MapFrom(y => 0M))
                .ForMember(p => p.CountryCountryName, x => x.Ignore())
                .ForMember(p => p.PictureRawPhoto, x => x.Ignore());*/

            // this.CreateMap<CustomerDto, CreateCustomerViewModel>();

            // this.CreateMap<CustomerDto, DeleteCustomerViewModel>().PreserveReferences().ReverseMap();
            // this.CreateMap<CustomerDto, UpdateCustomerViewModel>().PreserveReferences().ReverseMap();

            // .ConstructUsing(c => new RegisterNewCustomerCommand(c.Name, c.Email, c.BirthDate));
            /* this.CreateMap<UpdateCustomerViewModel, UpdateCustomerCommand>()
                 .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));*/
        }
    }
}