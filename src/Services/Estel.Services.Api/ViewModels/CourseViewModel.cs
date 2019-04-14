namespace Estel.Services.Api.ViewModels
{
    using System.Collections.Generic;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    public class CourseViewModel
    {
        public CourseViewModel()
        {
            this.CourseAttendances = new List<CourseAttendanceViewModel>();
            this.CourseTopics = new List<string>();
            this.AdditionalAmenity = new List<string>();
            this.AvailableDates = new List<AvailableDatesViewModel>();
        }

        public CourseViewModel(Course course)
        {
            CourseName = course.CourseName;
            DayDuration = course.DayDuration;
            CourseCost = course.CourseCost;
            CourseType = new CourseTypeViewModel
                             {
                                 CourseTypeName = course.CourseType.CourseTypeName,
                                 Description = course.CourseType.Description
                             };
           }


        public string CourseName { get; set; }

        public string DayDuration { get; set; }

        public decimal CourseCost { get; set; }

        public CourseTypeViewModel CourseType { get; set; }

        /// <summary>
        /// Gets or sets the customers.
        /// This is all customers which attended to the course 
        /// </summary>
        public IEnumerable<CourseAttendanceViewModel> CourseAttendances { get; set; }

        /// <summary>
        /// +1 Gets or sets the course topics.
        /// All Topics which your learn on courses
        /// </summary>
        public IEnumerable<string> CourseTopics { get; set; }

        /// <summary>
        /// +1 Gets or sets the additional amenities.
        /// All Amenities (coffee break, certificates ets)
        /// </summary>
        public IEnumerable<string> AdditionalAmenity { get; set; }

        /// <summary>
        /// +1 Gets or sets the available dates.
        /// All Available dates for this course 
        /// </summary>
        public IEnumerable<AvailableDatesViewModel> AvailableDates { get; set; }
    }
}
