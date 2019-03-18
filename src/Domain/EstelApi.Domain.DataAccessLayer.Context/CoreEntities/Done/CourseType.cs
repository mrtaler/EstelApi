namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities
{
    using EstelApi.Core.Seedwork;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Collections.Generic;

    /// <inheritdoc />
    public class CourseType : EntityInt
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CourseType"/> class.
        /// </summary>
        public CourseType()
        {
            this.Courses = new HashSet<Course>();
        }

        /// <summary>
        /// Gets or sets the course type name.
        /// </summary>
        public string CourseTypeName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the courses.
        /// </summary>
        public virtual IEnumerable<Course> Courses { get; set; }
    }

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