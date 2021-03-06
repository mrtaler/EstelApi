﻿namespace EstelApi.Domain.DataAccessLayer.Context.EntityDbMapper
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AvailableDatesCourseConfiguration : IEntityTypeConfiguration<AvailableDatesCourse>
    {
        public void Configure(EntityTypeBuilder<AvailableDatesCourse> builder)
        {
            builder
                .HasKey(bc => new { bc.CourseId, bc.AvailableDatesId });

            builder
                .HasOne(bc => bc.Course)
                .WithMany(b => b.AvailableDates)
                .HasForeignKey(bc => bc.CourseId);
            builder
                .HasOne(bc => bc.AvailableDates)
                .WithMany(c => c.Courses)
                .HasForeignKey(bc => bc.AvailableDatesId);

            builder.HasData(
                new AvailableDatesCourse { CourseId = 1, AvailableDatesId = 1 },
                new AvailableDatesCourse { CourseId = 1, AvailableDatesId = 2 },
                new AvailableDatesCourse { CourseId = 1, AvailableDatesId = 3 },
                new AvailableDatesCourse { CourseId = 1, AvailableDatesId = 4 },
                new AvailableDatesCourse { CourseId = 2, AvailableDatesId = 1 },
                new AvailableDatesCourse { CourseId = 2, AvailableDatesId = 2 },
                new AvailableDatesCourse { CourseId = 2, AvailableDatesId = 3 });
        }
    }
}