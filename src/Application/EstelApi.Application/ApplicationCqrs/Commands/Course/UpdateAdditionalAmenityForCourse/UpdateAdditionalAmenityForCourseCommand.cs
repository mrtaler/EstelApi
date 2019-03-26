namespace EstelApi.Application.ApplicationCqrs.Commands.Course.UpdateCourseTopicsForCourse
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Commands;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using MediatR;

    public class UpdateAdditionalAmenityForCourseCommand : AdditionalAmenity, ICommand, IRequest<CommandResponse<bool>>
    {
        public int CourseId { get; set; }
    }
}