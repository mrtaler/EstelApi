using System.Collections.Generic;

namespace EstelApi.Core.Seedwork.CoreEntities
{
    public class CourseType : Entity
    {
        public CourseType()
        {
            Courses = new HashSet<Course>();
        }

     //   public int Id { get; set; }
        public string CourseTypeName { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }

        public virtual IEnumerable<Course> Courses { get; set; }
    }
}