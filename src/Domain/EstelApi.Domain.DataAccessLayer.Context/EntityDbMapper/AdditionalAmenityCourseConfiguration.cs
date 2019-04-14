namespace EstelApi.Domain.DataAccessLayer.Context.EntityDbMapper
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

   /* public class AdditionalAmenityCourseConfiguration : IEntityTypeConfiguration<AdditionalAmenityCourse>
    {
        public void Configure(EntityTypeBuilder<AdditionalAmenityCourse> builder)
        {
            builder
                  .HasOne(bc => bc.Course)
                .WithMany(b => b.AdditionalAmenityCourses);
            //  .HasForeignKey(bc => bc.BookId);
            builder
                 .HasOne(bc => bc.AdditionalAmenity)
                .WithMany(c => c.AdditionalAmenityCourses);
            //  .HasForeignKey(bc => bc.CategoryId);
        }
    }

   */
}
