﻿namespace EstelApi.Application.ApplicationCqrs.Commands.CreateCommands
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Commands;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using MediatR;

    public class CreateNewCourseTopicsCommand : CourseTopics,
                                                ICommand,
                                                IRequest<CommandResponse<CourseTopics>>
    {

    }
}