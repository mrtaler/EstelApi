namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities
{
    using System.Collections.Generic;

    using EstelApi.Core.Seedwork;

    /// <inheritdoc />
    public class CourseType : AuditableEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CourseType"/> class.
        /// </summary>
        protected CourseType()
        {
            this.Courses = new HashSet<Course>();
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int CourseTypeId { get; set; }

        /// <summary>
        /// Gets or sets the course type name.
        /// </summary>
        public string CourseTypeName { get; set; }

        /// <summary>
        /// Gets or sets the logo.
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the courses.
        /// </summary>
        public virtual IEnumerable<Course> Courses { get; set; }
    }
}