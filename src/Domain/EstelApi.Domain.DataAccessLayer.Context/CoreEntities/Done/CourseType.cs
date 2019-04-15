namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done
{
    using System.Collections.Generic;

    using EstelApi.Core.Seedwork;

    /// <inheritdoc />
    public class CourseType : EntityInt
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CourseType"/> class.
        /// </summary>
        public CourseType()
        {
            this.Courses = new HashSet<Course>();
        }

        /// <summary>
        /// Gets or sets the course type name.
        /// </summary>
        public string CourseTypeName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the courses.
        /// </summary>
        public  IEnumerable<Course> Courses { get; set; }
    }
}