namespace Estel.Services.Api.ViewModels
{
    using System;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;

    public class CourseAttendanceViewModel
    {
        public UserViewModel User { get; set; }

        public DateTimeOffset AttendenseDate { get; set; }
        public DateTimeOffset CourseDate { get; set; }
        public DateTimeOffset CourseEndDAte { get; set; }
        public CourseAttendenseStatus Status { get; set; }
        public string Description { get; set; }
    }
}