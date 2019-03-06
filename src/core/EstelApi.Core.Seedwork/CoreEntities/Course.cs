using System;

namespace EstelApi.Core.Seedwork.CoreEntities
{
    public class Course : Entity
    {
        public Course()
        {
        }

       // public int Id { get; set; }
        public string CourseName { get; set; }

        public virtual CourseType CourseType { get; set; }
        public Guid CourseTypeId { get; set; }
    }
}
