namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done
{
    using System;

    using EstelApi.Core.Seedwork;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    public class CourseAttendance : EntityInt
    {
        public int CustomerId { get; set; }
        public User User { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public DateTimeOffset AttendenseDate { get; set; }
        public DateTimeOffset CourseDate { get; set; }
        public DateTimeOffset CourseEndDAte { get; set; }
        public CourseAttendenseStatus Status { get; set; }
        public string Description { get; set; }
    }
}