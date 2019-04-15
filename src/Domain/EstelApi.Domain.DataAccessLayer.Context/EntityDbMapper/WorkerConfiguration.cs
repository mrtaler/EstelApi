namespace EstelApi.Domain.DataAccessLayer.Context.EntityDbMapper
{
    using System;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {

        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.ToTable("Worker");

            builder.HasData(
                new Worker
                {
                    Id = 6,
                    FirstName = "WorkerFirstName1",
                    LastName = "WorkerLastName1",
                    MiddleName = "WorkerMiddleName1",
                    Telephone = "Worker123456789",
                    BirthDate = new DateTimeOffset(new DateTime(2019, 3, 8, 7, 41, 20, 362, DateTimeKind.Unspecified)).AddDays(-150),
                    WorkFrom = new DateTimeOffset(new DateTime(2019, 3, 8, 7, 41, 20, 362, DateTimeKind.Unspecified)).AddDays(-15),
                    IsEnabled = true,
                    StaffType = StaffType.Worker,
                    LogoPath = @"c:\Worker"
                },
                new Worker
                {
                    Id = 7,
                    FirstName = "WorkerFirstName2",
                    LastName = "WorkerLastName2",
                    MiddleName = "WorkerMiddleName2",
                    Telephone = "Worker234567891",
                    BirthDate = new DateTimeOffset(new DateTime(2019, 3, 8, 7, 41, 20, 362, DateTimeKind.Unspecified)).AddDays(-275),
                    WorkFrom = new DateTimeOffset(new DateTime(2019, 3, 8, 7, 41, 20, 362, DateTimeKind.Unspecified)).AddDays(-12),
                    StaffType = StaffType.Painter,
                    IsEnabled = true,
                    LogoPath = @"c:\Worker"
                },
                new Worker
                {
                    Id = 8,
                    FirstName = "WorkerFirstName3",
                    LastName = "WorkerLastName3",
                    MiddleName = "WorkerMiddleName3",
                    Telephone = "Worker345678912",
                    StaffType = StaffType.HairSt,
                    BirthDate = new DateTimeOffset(new DateTime(2019, 3, 8, 7, 41, 20, 362, DateTimeKind.Unspecified)).AddDays(-690),
                    WorkFrom = new DateTimeOffset(new DateTime(2019, 3, 8, 7, 41, 20, 362, DateTimeKind.Unspecified)).AddDays(-13),
                    IsEnabled = true,
                    LogoPath = @"c:\Worker"
                },
                new Worker
                {
                    Id = 9,
                    FirstName = "WorkerFirstName4",
                    LastName = "WorkerLastName4",
                    MiddleName = "WorkerMiddleName4",
                    Telephone = "Worker456789123",
                    StaffType = StaffType.Painter,
                    BirthDate = new DateTimeOffset(new DateTime(2019, 3, 8, 7, 41, 20, 362, DateTimeKind.Unspecified)).AddDays(-850),
                    WorkFrom = new DateTimeOffset(new DateTime(2019, 3, 8, 7, 41, 20, 362, DateTimeKind.Unspecified)).AddDays(-25),
                    IsEnabled = true,
                    LogoPath = @"c:\Worker"
                },
                new Worker
                {
                    Id = 10,
                    FirstName = "WorkerFirstName5",
                    LastName = "WorkerLastName5",
                    MiddleName = "WorkerMiddleName5",
                    Telephone = "Worker567891234",
                    StaffType = StaffType.Worker,
                    BirthDate = new DateTimeOffset(new DateTime(2019, 3, 8, 7, 41, 20, 362, DateTimeKind.Unspecified)).AddDays(-987),
                    WorkFrom = new DateTimeOffset(new DateTime(2019, 3, 8, 7, 41, 20, 362, DateTimeKind.Unspecified)).AddDays(-75),
                    IsEnabled = true,
                    LogoPath = @"c:\Worker"
                });
        }
    }
}