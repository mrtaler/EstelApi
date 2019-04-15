﻿namespace EstelApi.Domain.DataAccessLayer.Context.EntityDbMapper
{
    using System;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CourseAttendanceConfiguration : IEntityTypeConfiguration<CourseAttendance>
    {
        public void Configure(EntityTypeBuilder<CourseAttendance> builder)
        {
            builder
                .HasOne(x => x.User)
                .WithMany(y => y.CourseAttendances)
                .HasForeignKey(x => x.CustomerId);
            builder
                .HasOne(x => x.Course)
                .WithMany(y => y.CourseAttendances)
                .HasForeignKey(x => x.CourseId);
            builder
                .HasData(
                    new CourseAttendance
                        {
                            Id = 1,
                            CustomerId = 1,
                            CourseId = 1,
                            AttendenseDate = DateTimeOffset.UtcNow.AddDays(-15),
                            CourseDate = DateTimeOffset.UtcNow.AddHours(-25),
                            CourseEndDAte = DateTimeOffset.UtcNow,
                            Status = CourseAttendenseStatus.Finish,
                            Description = "testDescription"
                        },
                    new CourseAttendance
                        {
                            Id = 2,
                            CustomerId = 2,
                            CourseId = 2,
                            AttendenseDate = DateTimeOffset.UtcNow.AddDays(-12),
                            CourseDate = DateTimeOffset.UtcNow.AddHours(-22),
                            CourseEndDAte = DateTimeOffset.UtcNow,
                            Status = CourseAttendenseStatus.Finish,
                            Description = "testDescription"
                        },
                    new CourseAttendance
                        {
                            Id = 3,
                            CustomerId = 2,
                            CourseId = 1,
                            AttendenseDate = DateTimeOffset.UtcNow.AddDays(-13),
                            CourseDate = DateTimeOffset.UtcNow,
                            Status = CourseAttendenseStatus.InProgress,
                            Description = "testDescription"
                        },
                    new CourseAttendance
                        {
                            Id = 4,
                            CustomerId = 2,
                            CourseId = 2,
                            AttendenseDate = DateTimeOffset.UtcNow.AddDays(-14),
                            CourseDate = DateTimeOffset.UtcNow,
                            Status = CourseAttendenseStatus.Rejected,
                            Description = "testDescription"
                        },
                    new CourseAttendance
                        {
                            Id = 5,
                            CustomerId = 3,
                            CourseId = 1,
                            AttendenseDate = DateTimeOffset.UtcNow.AddDays(-16),
                            CourseDate = DateTimeOffset.UtcNow,
                            Status = CourseAttendenseStatus.Attendent,
                            Description = "testDescription"
                        });
        }
    }
}