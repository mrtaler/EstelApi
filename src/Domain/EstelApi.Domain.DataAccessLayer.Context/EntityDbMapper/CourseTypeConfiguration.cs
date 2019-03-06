using EstelApi.Core.Seedwork.CoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstelApi.Domain.DataAccessLayer.Context.EntityDbMapper
{
    public class CourseTypeConfiguration : IEntityTypeConfiguration<CourseType>
    {
        public void Configure(EntityTypeBuilder<CourseType> builder)
        {
            builder.HasKey(k => k.Id);
            builder
                .Property(p => p.Id)
                .HasColumnName("CourseTypeId");
            builder
                .Property(b => b.CourseTypeName)
                .HasMaxLength(50);
            builder
                .Property(b => b.Logo);
            builder
                .Property(b => b.Description)
                .HasMaxLength(500);
            builder
                .HasMany<Course>(hm => hm.Courses)
                .WithOne(wo => wo.CourseType)
                .HasForeignKey(fk => fk.CourseTypeId);
        }
    }
}