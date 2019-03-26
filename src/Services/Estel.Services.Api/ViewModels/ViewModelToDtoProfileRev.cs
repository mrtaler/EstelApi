namespace Estel.Services.Api.ViewModels
{
    using AutoMapper;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    // using EstelApi.Application.Dto;
    using Serilog;
    using System.Linq;

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

            // this.CreateMap<CreateAdditionalAmenityViewModel, CreateNewAdditionalAmenityCommand>(MemberList.Source);
            // this.CreateMap<CreateAvailableDatesViewModel, CreateNewAvailableDatesCommand>(MemberList.Source);
            // this.CreateMap<CreateCourseTopicsViewModel, CreateNewCourseTopicsCommand>(MemberList.Source);
            // this.CreateMap<CreateCourseTypeViewModel, CreateNewCourseTypeCommand>(MemberList.Source);
            // this.CreateMap<CreateCourseViewModel, CreateNewCourseCommand>(MemberList.Source);
            // this.CreateMap<CreateUserViewModel, CreateNewUserCommand>(MemberList.Source);
            //// this.CreateMap<CreateWorkerViewModel, CreateNewWorkerCommand>(MemberList.Source);

            // this.CreateMap<UpdateAdditionalAmenityViewModel, UpdateAdditionalAmenityCommand>(MemberList.Source);
            // this.CreateMap<UpdateAvailableDatesViewModel, UpdateAvailableDatesCommand>(MemberList.Source);
            // this.CreateMap<UpdateCourseTopicsViewModel, UpdateCourseTopicsCommand>(MemberList.Source);
            // this.CreateMap<UpdateCourseTypeViewModel, UpdateCourseTypeCommand>(MemberList.Source);
            // this.CreateMap<UpdateCourseViewModel, UpdateCourseCommand>(MemberList.Source);
            // this.CreateMap<UpdateUserViewModel, UpdateUserCommand>(MemberList.Source);
            //// this.CreateMap<UpdateWorkerViewModel, UpdateWorkerCommand>(MemberList.Source);

            //  this.CreateMap<UpdateAvailableDatesViewModel, UpdateAvailableDatesForCourseCommand>(MemberList.Source);
            //  this.CreateMap<UpdateCourseTopicsViewModel, UpdateCourseTopicsForCourseCommand>(MemberList.Source);

            //   this.CreateMap<UpdateAdditionalAmenityViewModel, UpdateAdditionalAmenityForCourseCommand>(MemberList.Source);
            this.CreateMap<AvailableDatesCourse, AvailableDatesViewModel>(MemberList.Source);



            this.CreateMap<Course, CourseViewModel>()
                .ForMember(
                    x => x.AdditionalAmenity,
                    d => d.MapFrom(
                        y => y.AdditionalAmenityCourses.Any()
                            ? y.AdditionalAmenityCourses.Select(m => m.AdditionalAmenity.AdditionalAmenityName)
                            : null))
                .ForMember(
                    x => x.CourseTopics,
                    y => y.MapFrom(
                        z => z.CourseTopics.Any()
                                 ? z.CourseTopics.Select(a => a.CourseTopics.CourseTopicName)
                                 : null))
                .ForMember(
                    x => x.AvailableDates,
                    y => y.MapFrom(
                        z => z.AvailableDates.Select(p => p.AvailableDates)));

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