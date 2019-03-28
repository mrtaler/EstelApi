﻿namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands.UpdateCommands;
    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.CrossCutting.Bus;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    /// <inheritdoc cref="CommandHandler" />
    /// <summary>
    /// The delete course type command handler.
    /// </summary>
    public class UpdateCourseTypeCommandHandler : CommandHandler,
                                                  IRequestHandler<UpdateCourseTypeCommand, CommandResponse<CourseType>>
    {
        private readonly ICourseTypeRepository repository;

        public UpdateCourseTypeCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainEvent> notifications,
            ICourseTypeRepository courseTypeRepository)
            : base(uow, bus, notifications)
        {
            this.repository = courseTypeRepository;
        }

        public async Task<CommandResponse<CourseType>> Handle(UpdateCourseTypeCommand request, CancellationToken cancellationToken)
        {
            Contract.ThrowIfNull(request, request.GetType().Name, this.Bus);
            var updateCourseType = request.ProjectedAs<CourseType>();
            this.repository.Modify(updateCourseType);

            return await this.CommitAsync()
                       ? new CommandResponse<CourseType> { IsSuccess = true, Message = "New Entity was added", Object = updateCourseType }
                       : new CommandResponse<CourseType> { IsSuccess = false, Message = "New Entity Not added", Object = updateCourseType };
        }
    }
}