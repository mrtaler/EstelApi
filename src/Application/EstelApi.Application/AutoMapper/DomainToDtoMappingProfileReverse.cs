namespace EstelApi.Application.AutoMapper
{
    //using EstelApi.Application.Dto;

    using EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands.UpdateCommands;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using global::AutoMapper;

    using Serilog;

    /// <inheritdoc />
    /// <summary>
    /// The domain to dto mapping profile reverse.
    /// </summary>
    public class DomainToDtoMappingProfileReverse : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainToDtoMappingProfileReverse"/> class.
        /// </summary>
        public DomainToDtoMappingProfileReverse()
        {
            Log.Debug($"AutoMapper profile {nameof(DomainToDtoMappingProfileReverse)} was launch");
            this.CreateMap<UpdateWorkerCommand, Worker>(memberList: MemberList.Source);
            this.CreateMap<UpdateUserCommand, User>(memberList: MemberList.Source);
            this.CreateMap<UpdateCourseTypeCommand, CourseType>(memberList: MemberList.Source);
            this.CreateMap<UpdateCourseTopicsCommand, CourseTopics>(memberList: MemberList.Source);
            this.CreateMap<UpdateAvailableDatesCommand, AvailableDates>(memberList: MemberList.Source);
            this.CreateMap<UpdateAdditionalAmenityCommand, AdditionalAmenity>(memberList: MemberList.Source);




            //   this.CreateMap<Customer, CustomerDto>().PreserveReferences();
        }
    }
}