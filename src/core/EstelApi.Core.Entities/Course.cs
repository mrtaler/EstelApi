using EstelApi.Core.Seedwork;

namespace EstelApi.Core.Entities
{
    public class Course : Entity
    {
        public Course()
        {
        }

        public int Id { get; set; }
        public string CourseName { get; set; }

        public virtual CourseType CourseType { get; set; }
        public int CourseTypeId { get; set; }
    }
}
