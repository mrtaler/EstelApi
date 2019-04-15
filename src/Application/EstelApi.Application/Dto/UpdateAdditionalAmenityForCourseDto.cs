namespace EstelApi.Application.Dto
{
    public class UpdateAdditionalAmenityForCourseDto
    {
        public int Id { get; set; }
        public string AdditionalAmenityName { get; set; }
        public int CourseId { get; set; }
    }
}