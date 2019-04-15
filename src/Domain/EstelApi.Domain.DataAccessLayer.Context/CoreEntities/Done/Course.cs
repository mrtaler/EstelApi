namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done
{
    using EstelApi.Core.Seedwork;

    using System.Collections.Generic;

    /// <inheritdoc />
    /// <summary>
    /// The course.
    /// </summary>
    public class Course : EntityInt
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Course"/> class.
        /// </summary>
        public Course()
        {
            CourseAttendances = new HashSet<CourseAttendance>();
            CourseTopics = new HashSet<CourseTopicsCourse>();
            AdditionalAmenityCourses = new HashSet<AdditionalAmenityCourse>();
            AvailableDates = new HashSet<AvailableDatesCourse>();
        }

        /// <summary>
        /// Gets or sets the course name.
        /// </summary>
        public string CourseName { get; set; }

        public string DayDuration { get; set; }

        public decimal CourseCost { get; set; }

        public int CourseTypeId { get; set; }

        public CourseType CourseType { get; set; }

        /// <summary>
        /// Gets or sets the customers.
        /// This is all customers which attended to the course 
        /// </summary>
        public ICollection<CourseAttendance> CourseAttendances { get; set; }

        /// <summary>
        /// +1 Gets or sets the course topics.
        /// All Topics which your learn on courses
        /// </summary>
        public ICollection<CourseTopicsCourse> CourseTopics { get; set; }

        /// <summary>
        /// +1 Gets or sets the additional amenities.
        /// All Amenities (coffee break, certificates ets)
        /// </summary>
        public ICollection<AdditionalAmenityCourse> AdditionalAmenityCourses { get; set; }

        /// <summary>
        /// +1 Gets or sets the available dates.
        /// All Available dates for this course 
        /// </summary>
        public ICollection<AvailableDatesCourse> AvailableDates { get; set; }
    }
}
