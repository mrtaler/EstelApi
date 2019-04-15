namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done
{
    public class AdditionalAmenityCourse
    {

        public  int CourseId { get; set; }
        public  int AdditionalAmenityId { get; set; }
        public Course Course { get; set; }
        public AdditionalAmenity AdditionalAmenity { get; set; }
    }
}