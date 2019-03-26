namespace EstelApi.Application.ApplicationCqrs.Commands.Course.CreateNewCourse
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Commands;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using MediatR;

    public class CreateNewCourseCommand : Course,
                                          ICommand,
                                          IRequest<CommandResponse<Course>>
    {

    }
}