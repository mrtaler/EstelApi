﻿namespace EstelApi.Application.ApplicationCqrs.Commands.UpdateCommands
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Commands;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using MediatR;

    public class UpdateCourseTopicsCommand : CourseTopics, ICommand, IRequest<CommandResponse<CourseTopics>>
    {
    }
}