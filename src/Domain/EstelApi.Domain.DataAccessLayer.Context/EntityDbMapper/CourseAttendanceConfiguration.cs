namespace EstelApi.Domain.DataAccessLayer.Context.EntityDbMapper
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
                            AttendenseDate = new DateTimeOffset(new DateTime(2019, 3, 8, 7, 41, 20, 362, DateTimeKind.Unspecified)).AddDays(-15),
                            CourseDate = new DateTimeOffset(new DateTime(2019, 3, 8, 7, 41, 20, 362, DateTimeKind.Unspecified)).AddHours(-25),
                            CourseEndDAte = new DateTimeOffset(new DateTime(2019, 3, 8, 7, 41, 20, 362, DateTimeKind.Unspecified)),
                            Status = CourseAttendenseStatus.Finish,
                            Description = "testDescription"
                        },
                    new CourseAttendance
                        {
                            Id = 2,
                            CustomerId = 2,
                            CourseId = 2,
                            AttendenseDate = new DateTimeOffset(new DateTime(2019, 3, 8, 7, 41, 20, 362, DateTimeKind.Unspecified)).AddDays(-12),
                            CourseDate = new DateTimeOffset(new DateTime(2019, 3, 8, 7, 41, 20, 362, DateTimeKind.Unspecified)).AddHours(-22),
                            CourseEndDAte = new DateTimeOffset(new DateTime(2019, 3, 8, 7, 41, 20, 362, DateTimeKind.Unspecified)),
                            Status = CourseAttendenseStatus.Finish,
                            Description = "testDescription"
                        },
                    new CourseAttendance
                        {
                            Id = 3,
                            CustomerId = 2,
                            CourseId = 1,
                            AttendenseDate = new DateTimeOffset(new DateTime(2019, 3, 8, 7, 41, 20, 362, DateTimeKind.Unspecified)).AddDays(-13),
                            CourseDate = new DateTimeOffset(new DateTime(2019, 3, 8, 7, 41, 20, 362, DateTimeKind.Unspecified)),
                            Status = CourseAttendenseStatus.InProgress,
                            Description = "testDescription"
                        },
                    new CourseAttendance
                        {
                            Id = 4,
                            CustomerId = 2,
                            CourseId = 2,
                            AttendenseDate = new DateTimeOffset(new DateTime(2019, 3, 8, 7, 41, 20, 362, DateTimeKind.Unspecified)).AddDays(-14),
                            CourseDate = new DateTimeOffset(new DateTime(2019, 3, 8, 7, 41, 20, 362, DateTimeKind.Unspecified)),
                            Status = CourseAttendenseStatus.Rejected,
                            Description = "testDescription"
                        },
                    new CourseAttendance
                        {
                            Id = 5,
                            CustomerId = 3,
                            CourseId = 1,
                            AttendenseDate = new DateTimeOffset(new DateTime(2019, 3, 8, 7, 41, 20, 362, DateTimeKind.Unspecified)).AddDays(-16),
                            CourseDate = new DateTimeOffset(new DateTime(2019, 3, 8, 7, 41, 20, 362, DateTimeKind.Unspecified)),
                            Status = CourseAttendenseStatus.Attendent,
                            Description = "testDescription"
                        });
        }
    }
}