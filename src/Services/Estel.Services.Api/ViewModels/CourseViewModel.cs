namespace Estel.Services.Api.ViewModels
{
    using System;
    using System.Collections.Generic;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;
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

    public class CourseTypeViewModel
    {
        /// <summary>
        /// Gets or sets the course type name.
        /// </summary>
        public string CourseTypeName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }
    }

    public class AvailableDatesViewModel
    {
        public string Month { get; set; }
        public string Date { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
    }

    public class CourseAttendanceViewModel
    {
        public UserViewModel User { get; set; }

        public DateTimeOffset AttendenseDate { get; set; }
        public DateTimeOffset CourseDate { get; set; }
        public DateTimeOffset CourseEndDAte { get; set; }
        public CourseAttendenseStatus Status { get; set; }
        public string Description { get; set; }
    }

    public class UserViewModel
    {
        /// <inheritdoc />
        public UserViewModel()
        {
        }

        /// <summary>
        /// Gets or sets the identity id.
        /// </summary>
        public int IdentityId { get; set; }

        /// <summary>
        /// Gets or sets the Given name of this customer
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the surname of this customer
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the middle name.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets the full name of this customer
        /// </summary>
        public string FullName => $"{this.LastName} {this.FirstName} {this.MiddleName}";

        /// <summary>
        /// Gets or sets the telephone 
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        public DateTimeOffset BirthDate { get; set; }

        public bool IsEnabled { get; set; }

        public string LogoPath { get; set; }
    }
}
