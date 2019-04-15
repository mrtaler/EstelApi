namespace EstelApi.Domain.DataAccessLayer.Context.EntityDbMapper
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AdditionalAmenityCourseConfiguration : IEntityTypeConfiguration<AdditionalAmenityCourse>
    {
        public void Configure(EntityTypeBuilder<AdditionalAmenityCourse> builder)
        {
            builder
                .HasKey(bc => new { bc.CourseId, bc.AdditionalAmenityId });
            builder
                .HasOne(bc => bc.Course)
                .WithMany(b => b.AdditionalAmenityCourses)
                .HasForeignKey(bc => bc.CourseId);
            builder
                .HasOne(bc => bc.AdditionalAmenity)
                .WithMany(c => c.AdditionalAmenityCourses)
                .HasForeignKey(bc => bc.AdditionalAmenityId);

            builder.HasData(
                new AdditionalAmenityCourse { CourseId = 1, AdditionalAmenityId = 1 },
                new AdditionalAmenityCourse { CourseId = 1, AdditionalAmenityId = 2 },
                new AdditionalAmenityCourse { CourseId = 1, AdditionalAmenityId = 3 },
                new AdditionalAmenityCourse { CourseId = 2, AdditionalAmenityId = 1 },
                new AdditionalAmenityCourse { CourseId = 2, AdditionalAmenityId = 2 });
        }
    }
}