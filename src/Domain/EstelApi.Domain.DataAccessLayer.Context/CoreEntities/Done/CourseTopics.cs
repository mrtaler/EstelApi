namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities
{
    using EstelApi.Core.Seedwork;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Collections.Generic;

    public class CourseTopics : EntityInt
    {
        public string CourseTopicName { get; set; }


        public virtual ICollection<CourseTopicsCourse> Courses { get; set; }
    }

    public class CourseTopicsConfiguration : IEntityTypeConfiguration<CourseTopics>
    {
        public void Configure(EntityTypeBuilder<CourseTopics> builder)
        {
            builder.HasData(
                new CourseTopics { Id = 1, CourseTopicName = "Философия процедур" },
                new CourseTopics { Id = 2, CourseTopicName = "Экспресс востановление" },
                new CourseTopics { Id = 3, CourseTopicName = "Тонкости работы с краской DE LUXE" },
                new CourseTopics { Id = 4, CourseTopicName = "Технология применения продукта" },
                new CourseTopics { Id = 5, CourseTopicName = "Test 11" },
                new CourseTopics { Id = 6, CourseTopicName = "Test 12" });
        }
    }
}