namespace EstelApi.Application.ApplicationCqrs.Commands.NewFolder
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
    using EstelApi.Core.Seedwork.CoreCqrs.Commands;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateAvailableDatesForCourse : AvailableDates, ICommand, IRequest<CommandResponse<bool>>
    {
        public int CourseId { get; set; }
    }

    public class UpdateCourseCommandHandler : CommandHandler,
                                              IRequestHandler<UpdateAvailableDatesForCourse, CommandResponse<bool>>
    {
        private ICourseRepository repository;


        private IAvailableDatesRepository availableDatesRepository;

        public UpdateCourseCommandHandler(
            ICourseRepository courseRepository,
            IAvailableDatesRepository availableDatesRepository,
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            this.repository = courseRepository;
            this.availableDatesRepository = availableDatesRepository;
        }

        public async Task<CommandResponse<bool>> Handle(UpdateAvailableDatesForCourse request, CancellationToken cancellationToken)
        {
            var availableDates = this.availableDatesRepository.OneMatching(new FindAvailableDates(request));
            if (availableDates == null)
            {
                var course = this.repository.OneMatching(new FindCourseById().SetId(request.CourseId));
                course.AvailableDates.Add(new AvailableDatesCourse
                {
                    CourseId = request.CourseId,
                    AvailableDates = request
                });
            }
            else
            {
                var course = this.repository.OneMatching(new FindCourseById().SetId(request.CourseId));
                course.AvailableDates.Add(new AvailableDatesCourse
                {
                    CourseId = request.CourseId,
                    AvailableDates = availableDates
                });
            }
            return this.Commit()
                       ? new CommandResponse<bool> { IsSuccess = true, Message = "Date Adedes", Object = true }
                       : new CommandResponse<bool> { IsSuccess = false, Message = "Date Adedes", Object = false };
        }
    }
}