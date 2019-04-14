namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasData(
                new Course
                    {
                        Id = 1,
                        CourseName = "Экспресс востановление волос",
                        DayDuration = "1",
                        CourseCost = 500M,
                        CourseTypeId = 1
                    },
                new Course
                    {
                        Id = 2,
                        CourseName = "Лаборатория цвета",
                        DayDuration = "1",
                        CourseCost = 500M,
                        CourseTypeId = 2
                    });
        }
    }
}