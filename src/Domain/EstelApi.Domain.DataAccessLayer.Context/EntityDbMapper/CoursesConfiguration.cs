using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstelApi.Domain.DataAccessLayer.Context.EntityDbMapper
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;

   /* public class CoursesConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(k => k.Id);
            builder
                .Property(p => p.Id)
                .HasColumnName("CourseId");
            builder
                .Property(b => b.CourseName)
                .HasMaxLength(50);
        }
    }*/
}
