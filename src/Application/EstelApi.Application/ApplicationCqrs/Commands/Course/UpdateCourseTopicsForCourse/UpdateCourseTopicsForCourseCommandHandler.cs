﻿namespace EstelApi.Application.ApplicationCqrs.Commands.NewFolder
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Commands.Course.UpdateCourseTopicsForCourse;
    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
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
            INotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            this.courseRepository = courseRepository;
            this.courseTopicsRepository = courseTopicsRepository;
        }

        public async Task<CommandResponse<bool>> Handle(
            UpdateCourseTopicsForCourseCommand request,
            CancellationToken cancellationToken)
        {
            var courseTopics = this.courseTopicsRepository.OneMatching(new FindCourseTopics(request));
            if (courseTopics == null)
            {
                var course = this.courseRepository.OneMatching(new FindCourseById().SetId(request.CourseId));
                course.CourseTopics.Add(new CourseTopicsCourse
                                            {
                                                CourseId = request.CourseId,
                                                CourseTopics = request
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

            return this.Commit()
                       ? new CommandResponse<bool> { IsSuccess = true, Message = "Date Adedes", Object = true }
                       : new CommandResponse<bool> { IsSuccess = false, Message = "Date Adedes", Object = false };
        }
    }
}