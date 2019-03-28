namespace EstelApi.Application.ApplicationCqrs.Commands.NewFolder
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Commands.Course.UpdateCourseTopicsForCourse;
    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    public class UpdateCourseTopicsForCourseCommandHandler : CommandHandler,
                                                             IRequestHandler<UpdateCourseTopicsForCourseCommand,
                                                                 CommandResponse<bool>>
    {
        private readonly ICourseRepository courseRepository;

        private readonly ICourseTopicsRepository courseTopicsRepository;

        public UpdateCourseTopicsForCourseCommandHandler(
            ICourseRepository courseRepository,
            ICourseTopicsRepository courseTopicsRepository,
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainEvent> notifications)
            : base(uow, bus, notifications)
        {
            this.courseRepository = courseRepository;
            this.courseTopicsRepository = courseTopicsRepository;
        }

        public async Task<CommandResponse<bool>> Handle(
            UpdateCourseTopicsForCourseCommand request,
            CancellationToken cancellationToken)
        {
            var entity = request.ProjectedAs<CourseTopics>();
            var courseTopics = this.courseTopicsRepository.OneMatching(new FindCourseTopics(entity));
            if (courseTopics == null)
            {
                var course = this.courseRepository.OneMatching(new FindCourseById().SetId(request.CourseId));
                course.CourseTopics.Add(new CourseTopicsCourse
                                            {
                                                CourseId = request.CourseId,
                                                CourseTopics = entity
                });
            }
            else
            {
                var course = this.courseRepository.OneMatching(new FindCourseById().SetId(request.CourseId));
                course.CourseTopics.Add(new CourseTopicsCourse
                                            {
                                                CourseId = request.CourseId,
                                                CourseTopics = courseTopics
                                            });
            }

            return await this.CommitAsync()
                       ? new CommandResponse<bool> { IsSuccess = true, Message = "Date Adedes", Object = true }
                       : new CommandResponse<bool> { IsSuccess = false, Message = "Date Adedes", Object = false };
        }
    }
}