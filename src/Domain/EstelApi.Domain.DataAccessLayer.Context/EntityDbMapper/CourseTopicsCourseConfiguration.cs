namespace EstelApi.Domain.DataAccessLayer.Context.EntityDbMapper
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CourseTopicsCourseConfiguration : IEntityTypeConfiguration<CourseTopicsCourse>
    {
        public void Configure(EntityTypeBuilder<CourseTopicsCourse> builder)
        {

            builder
                .HasKey(bc => new { bc.CourseId, bc.CourseTopicsId });
            builder
                .HasOne(bc => bc.Course)
                .WithMany(b => b.CourseTopics)
                .HasForeignKey(bc => bc.CourseId);
            builder
                .HasOne(bc => bc.CourseTopics)
                .WithMany(c => c.Courses)
                .HasForeignKey(bc => bc.CourseTopicsId);

            builder.HasData(
                new CourseTopicsCourse { CourseId = 1, CourseTopicsId = 1 },
                new CourseTopicsCourse { CourseId = 1, CourseTopicsId = 2 },
                new CourseTopicsCourse { CourseId = 1, CourseTopicsId = 3 },
                new CourseTopicsCourse { CourseId = 1, CourseTopicsId = 4 },
                new CourseTopicsCourse { CourseId = 2, CourseTopicsId = 1 },
                new CourseTopicsCourse { CourseId = 2, CourseTopicsId = 2 },
                new CourseTopicsCourse { CourseId = 2, CourseTopicsId = 3 },
                new CourseTopicsCourse { CourseId = 2, CourseTopicsId = 4 },
                new CourseTopicsCourse { CourseId = 1, CourseTopicsId = 5 },
                new CourseTopicsCourse { CourseId = 2, CourseTopicsId = 5 },
                new CourseTopicsCourse { CourseId = 1, CourseTopicsId = 6 });
        }
    }
}