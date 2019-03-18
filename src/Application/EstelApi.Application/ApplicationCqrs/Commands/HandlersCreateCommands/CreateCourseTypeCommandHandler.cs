﻿namespace EstelApi.Application.ApplicationCqrs.Commands.DeleteCommands
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Commands.CreateCommands;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    /// <summary>
    /// The delete course type command handler.
    /// </summary>
    public class CreateCourseTypeCommandHandler : CommandHandler,
                                                  IRequestHandler<CreateNewCourseTypeCommand, CommandResponse<CourseType>>
    {
        private ICourseTypeRepository repository;

        public CreateCourseTypeCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainNotification> notifications,
            ICourseTypeRepository courseTypeRepository)
            : base(uow, bus, notifications)
        {
            this.repository = courseTypeRepository;
        }

        public async Task<CommandResponse<CourseType>> Handle(CreateNewCourseTypeCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                await this.bus.Publish(
                    new DomainNotification(
                        request.GetType().Name,
                        "message is null"),
                    cancellationToken);
                return new CommandResponse<CourseType> { IsSuccess = false, Message = "message is null", Object = null };

                // throw new ArgumentException("_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)");
            }

            this.repository.Add(request);

            return this.Commit()
                       ? new CommandResponse<CourseType> { IsSuccess = true, Message = "New Entity was added", Object = request }
                       : new CommandResponse<CourseType> { IsSuccess = false, Message = "New Entity Not added", Object = request };
        }
    }
}