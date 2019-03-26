namespace EstelApi.Application.ApplicationCqrs.Commands.Course.CreateNewCourse
{
    using System.ComponentModel.DataAnnotations;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Commands;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using MediatR;

    public class CreateNewCourseCommand : ICommand,
                                          IRequest<CommandResponse<Course>>
    {
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string DayDuration { get; set; }
        [Required]
        public decimal CourseCost { get; set; }
        [Required]
        public int CourseTypeId { get; set; }
    }
}