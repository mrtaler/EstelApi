namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done
{
    public class AvailableDatesCourse
    {
        public int AvailableDatesId { get; set; }
        public AvailableDates AvailableDates { get; set; }
        public int CourseId { get; set; }
        public Course Course { set; get; }


    }
}