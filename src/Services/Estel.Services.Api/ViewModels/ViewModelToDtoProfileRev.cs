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
            this.CreateMap<AvailableDatesCourse, AvailableDatesViewModel>(MemberList.Source);
            this.CreateMap<AdditionalAmenity, AdditionalAmenityViewModel>(MemberList.Destination);
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

           // this.CreateMap<CustomerDto, DeleteCustomerViewModel>().PreserveReferences().ReverseMap();
            // this.CreateMap<CustomerDto, UpdateCustomerViewModel>().PreserveReferences().ReverseMap();

            // .ConstructUsing(c => new RegisterNewCustomerCommand(c.Name, c.Email, c.BirthDate));
            /* this.CreateMap<UpdateCustomerViewModel, UpdateCustomerCommand>()
                 .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));*/
        }
    }
}