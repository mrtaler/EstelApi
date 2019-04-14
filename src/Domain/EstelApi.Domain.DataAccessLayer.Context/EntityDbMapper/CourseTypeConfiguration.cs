namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CourseTypeConfiguration : IEntityTypeConfiguration<CourseType>
    {
        public void Configure(EntityTypeBuilder<CourseType> builder)
        {
            builder.HasMany(x => x.Courses)
                .WithOne(y => y.CourseType)
                .HasForeignKey(x => x.CourseTypeId);

            builder.HasData(
                new CourseType { Id = 1, CourseTypeName = "Курс PRODUCT-EXPERT", Description = "Для участия в семенаре необходима предварительная запись" },
                new CourseType { Id = 2, CourseTypeName = "Курс COLOR-EXPERT", Description = "Для участия в семенаре необходима предварительная запись" },
                new CourseType { Id = 3, CourseTypeName = "Курс INTENSE", Description = "Для участия в семенаре необходима предварительная запись" });
        }
    }
}