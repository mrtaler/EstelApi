namespace EstelApi.Application.ApplicationCqrs.Commands.Course.UpdateCourseTopicsForCourse
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Core.Seedwork.Adapter;

    public class UpdateAdditionalAmenityForCourseCommandHandler : CommandHandler,
                                                                  IRequestHandler<UpdateAdditionalAmenityForCourseCommand,
                                                                      CommandResponse<bool>>
    {
        private readonly ICourseRepository courseRepository;

        private readonly IAdditionalAmenityRepository additionalAmenityRepository;

        public UpdateAdditionalAmenityForCourseCommandHandler(
            ICourseRepository courseRepository,
            IAdditionalAmenityRepository additionalAmenityRepository,
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainEvent> notifications)
            : base(uow, bus, notifications)
        {
            this.courseRepository = courseRepository;
            this.additionalAmenityRepository = additionalAmenityRepository;
        }

        /// <inheritdoc />
        public async Task<CommandResponse<bool>> Handle(
            UpdateAdditionalAmenityForCourseCommand request,
            CancellationToken cancellationToken)
        {
            var entity = request.ProjectedAs<AdditionalAmenity>();

            var courseTopics = this.additionalAmenityRepository.OneMatching(new FindAdditionalAmenity(entity));
            if (courseTopics == null)
            {
                var course = this.courseRepository.OneMatching(new FindCourseById().SetId(request.CourseId));
                course.AdditionalAmenityCourses.Add(new AdditionalAmenityCourse()
                {
                    CourseId = request.CourseId,
                    AdditionalAmenity = entity
                });
            }
            else
            {
                var course = this.courseRepository.OneMatching(new FindCourseById().SetId(request.CourseId));
                course.AdditionalAmenityCourses.Add(new AdditionalAmenityCourse()
                {
                    CourseId = request.CourseId,
                    AdditionalAmenity = courseTopics
                });
            }

            return await this.CommitAsync()
                       ? new CommandResponse<bool> { IsSuccess = true, Message = "AdditionalAmenity Added", Object = true }
                       : new CommandResponse<bool> { IsSuccess = false, Message = "AdditionalAmenity Not Added", Object = false };
        }
    }
}