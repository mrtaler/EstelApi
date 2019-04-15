namespace EstelApi.Application
{
    using AutoMapper;

    using EstelApi.Application.Dto;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using Serilog;

    /// <inheritdoc />
    /// <summary>
    /// The domain to dto mapping profile reverse.
    /// </summary>
    public class CommandToEntityProfileReverse : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandToEntityProfileReverse"/> class.
        /// </summary>
        public CommandToEntityProfileReverse()
        {
            Log.Debug($"AutoMapper profile {nameof(CommandToEntityProfileReverse)} was launch");
            this.CreateMap<UpdateWorkerDto, Worker>(memberList: MemberList.Source);
            this.CreateMap<UpdateUserDto, User>(memberList: MemberList.Source);
            this.CreateMap<UpdateCourseTypeDto, CourseType>(memberList: MemberList.Source);
            this.CreateMap<UpdateCourseTopicsDto, CourseTopics>(memberList: MemberList.Source);
            this.CreateMap<UpdateAvailableDatesDto, AvailableDates>(memberList: MemberList.Source);
            this.CreateMap<UpdateAdditionalAmenityDto, AdditionalAmenity>(memberList: MemberList.Source);

            this.CreateMap<CreateNewWorkerDto, Worker>(memberList: MemberList.Source);
            this.CreateMap<CreateNewUserDto, User>(memberList: MemberList.Source);
            this.CreateMap<CreateNewCourseTypeDto, CourseType>(memberList: MemberList.Source);
            this.CreateMap<CreateNewCourseTopicsDto, CourseTopics>(memberList: MemberList.Source);
            this.CreateMap<CreateNewAvailableDatesDto, AvailableDates>(memberList: MemberList.Source);
            this.CreateMap<CreateNewAdditionalAmenityDto, AdditionalAmenity>(memberList: MemberList.Source);

            this.CreateMap<CreateNewCourseDto, Course>(memberList: MemberList.Source);
            this.CreateMap<UpdateAdditionalAmenityForCourseDto, AdditionalAmenity>(memberList: MemberList.Source);
            this.CreateMap<UpdateAvailableDatesForCourseDto, AvailableDates>(memberList: MemberList.Source);
            this.CreateMap<UpdateCourseDto, Course>(memberList: MemberList.Source);
            this.CreateMap<UpdateCourseTopicsForCourseDto, CourseTopics>(memberList: MemberList.Source);
        }
    }
}