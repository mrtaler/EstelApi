namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg
{
    using System;

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
                        BirthDate = DateTimeOffset.UtcNow.AddDays(-150),
                        WorkFrom = DateTimeOffset.UtcNow.AddDays(-15),
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
                        BirthDate = DateTimeOffset.UtcNow.AddDays(-275),
                        WorkFrom = DateTimeOffset.UtcNow.AddDays(-12),
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
                        BirthDate = DateTimeOffset.UtcNow.AddDays(-690),
                        WorkFrom = DateTimeOffset.UtcNow.AddDays(-13),
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
                        BirthDate = DateTimeOffset.UtcNow.AddDays(-850),
                        WorkFrom = DateTimeOffset.UtcNow.AddDays(-25),
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
                        BirthDate = DateTimeOffset.UtcNow.AddDays(-987),
                        WorkFrom = DateTimeOffset.UtcNow.AddDays(-75),
                        IsEnabled = true,
                        LogoPath = @"c:\Worker"
                    });

            // builder.Property(e => e.Id).ValueGeneratedNever();
            // builder.HasOne(d => d.Customer)
            //     .WithOne(p => p.Worker)
            //     .HasForeignKey<Customer>(d => d.Id);
        }
    }
}