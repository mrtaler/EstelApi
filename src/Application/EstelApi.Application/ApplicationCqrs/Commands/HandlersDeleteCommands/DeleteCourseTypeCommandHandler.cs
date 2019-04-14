namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersDeleteCommands
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
    using EstelApi.Core.Seedwork;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    /// <inheritdoc cref="CommandHandler" />
    /// <summary>
    /// The delete course type command handler.
    /// </summary>
    public class DeleteCourseTypeCommandHandler : CommandHandler,
                                                  IRequestHandler<RemoveEntityCommand<CourseType>, CommandResponse<CourseType>>
    {
        private readonly ICourseTypeRepository courseTypeRepository;

        public DeleteCourseTypeCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainEvent> notifications,
            ICourseTypeRepository courseTypeRepository)
            : base(uow, bus, notifications)
        {
            this.courseTypeRepository = courseTypeRepository;
        }

        public async Task<CommandResponse<CourseType>> Handle(
            RemoveEntityCommand<CourseType> request,
            CancellationToken cancellationToken)
        {
            Contract.ThrowIfNull(request, request.GetType().Name, this.Bus);

            var current = this.courseTypeRepository.OneMatching(new FindCourseTypeById().SetId(request.Id));
            this.courseTypeRepository.Remove(current);
            return !await this.CommitAsync().ConfigureAwait(false)
                       ? new CommandResponse<CourseType>
                       {
                           IsSuccess = false,
                           Message = "Delete error",
                           Object = null
                       }
                       : new CommandResponse<CourseType>
                       {
                           IsSuccess = true,
                           Message = "Entity was deleted",
                           Object = current
                       };
        }
    }
}