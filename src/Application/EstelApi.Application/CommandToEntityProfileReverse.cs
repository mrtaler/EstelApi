namespace EstelApi.Application.AutoMapper
{
    using EstelApi.Application.ApplicationCqrs.Commands.Course.CreateNewCourse;

    using global::AutoMapper;

    using EstelApi.Application.ApplicationCqrs.Commands.Course.UpdateAvailableDatesForCourse;
    using EstelApi.Application.ApplicationCqrs.Commands.Course.UpdateCourse;
    using EstelApi.Application.ApplicationCqrs.Commands.Course.UpdateCourseTopicsForCourse;
    using EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands.CreateCommands;
    using EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands.UpdateCommands;
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
            this.CreateMap<UpdateWorkerCommand, Worker>(memberList: MemberList.Source);
            this.CreateMap<UpdateUserCommand, User>(memberList: MemberList.Source);
            this.CreateMap<UpdateCourseTypeCommand, CourseType>(memberList: MemberList.Source);
            this.CreateMap<UpdateCourseTopicsCommand, CourseTopics>(memberList: MemberList.Source);
            this.CreateMap<UpdateAvailableDatesDto, AvailableDates>(memberList: MemberList.Source);
            this.CreateMap<UpdateAdditionalAmenityDto, AdditionalAmenity>(memberList: MemberList.Source);

            this.CreateMap<CreateNewWorkerCommand, Worker>(memberList: MemberList.Source);
            this.CreateMap<CreateNewUserCommand, User>(memberList: MemberList.Source);
            this.CreateMap<CreateNewCourseTypeCommand, CourseType>(memberList: MemberList.Source);
            this.CreateMap<CreateNewCourseTopicsCommand, CourseTopics>(memberList: MemberList.Source);
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