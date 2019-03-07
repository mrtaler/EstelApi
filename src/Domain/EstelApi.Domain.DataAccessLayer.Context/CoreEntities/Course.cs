namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities
{
    using EstelApi.Core.Seedwork;

    using Newtonsoft.Json;

    /// <summary>
    /// The course.
    /// </summary>
    public class Course : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Course"/> class.
        /// </summary>
        protected Course()
        {
        }

        /// <summary>
        /// Gets or sets the course id.
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// Gets or sets the course name.
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// Gets or sets the course type.
        /// </summary>
        [JsonIgnore]
        public virtual CourseType CourseType { get; set; }

        /// <summary>
        /// Gets or sets the course type id.
        /// </summary>
        [JsonIgnore]
        public int CourseTypeId { get; set; }
    }
}
