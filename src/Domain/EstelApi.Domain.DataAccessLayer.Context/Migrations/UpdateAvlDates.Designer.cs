﻿// <auto-generated />
using System;
using EstelApi.Domain.DataAccessLayer.Context.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EstelApi.Domain.DataAccessLayer.Context.Migrations
{
    [DbContext(typeof(EstelContext))]
    [Migration("20190320074121_updateAvlDates")]
    partial class UpdateAvlDates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("BirthDate");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<int>("IdentityId");

                    b.Property<bool>("IsEnabled");

                    b.Property<string>("LastName");

                    b.Property<string>("LogoPath");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Telephone");

                    b.HasKey("Id");

                    b.ToTable("Customer");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Customer");
                });

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done.AdditionalAmenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdditionalAmenityName");

                    b.HasKey("Id");

                    b.ToTable("AdditionalAmenities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdditionalAmenityName = "Практическая обработка"
                        },
                        new
                        {
                            Id = 2,
                            AdditionalAmenityName = "Кофе брейк"
                        },
                        new
                        {
                            Id = 3,
                            AdditionalAmenityName = "Сертификат"
                        });
                });

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done.AdditionalAmenityCourse", b =>
                {
                    b.Property<int>("CourseId");

                    b.Property<int>("AdditionalAmenityId");

                    b.HasKey("CourseId", "AdditionalAmenityId");

                    b.HasIndex("AdditionalAmenityId");

                    b.ToTable("AdditionalAmenityCourse");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            AdditionalAmenityId = 1
                        },
                        new
                        {
                            CourseId = 1,
                            AdditionalAmenityId = 2
                        },
                        new
                        {
                            CourseId = 1,
                            AdditionalAmenityId = 3
                        },
                        new
                        {
                            CourseId = 2,
                            AdditionalAmenityId = 1
                        },
                        new
                        {
                            CourseId = 2,
                            AdditionalAmenityId = 2
                        });
                });

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done.AvailableDates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date");

                    b.Property<string>("EndHour");

                    b.Property<string>("Month");

                    b.Property<string>("StartHour");

                    b.HasKey("Id");

                    b.ToTable("AvailableDates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = "12",
                            EndHour = "18",
                            Month = "Сентябрь",
                            StartHour = "11"
                        },
                        new
                        {
                            Id = 2,
                            Date = "4",
                            EndHour = "18",
                            Month = "Октябрь",
                            StartHour = "11"
                        },
                        new
                        {
                            Id = 3,
                            Date = "1",
                            EndHour = "18",
                            Month = "Ноябрь",
                            StartHour = "11"
                        },
                        new
                        {
                            Id = 4,
                            Date = "30",
                            EndHour = "18",
                            Month = "Декабрь",
                            StartHour = "11"
                        });
                });

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done.AvailableDatesCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvailableDatesId");

                    b.Property<int>("CourseId");

                    b.HasKey("Id");

                    b.HasIndex("AvailableDatesId");

                    b.HasIndex("CourseId");

                    b.ToTable("AvailableDatesCourse");
                });

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CourseCost");

                    b.Property<string>("CourseName");

                    b.Property<int>("CourseTypeId");

                    b.Property<string>("DayDuration");

                    b.HasKey("Id");

                    b.HasIndex("CourseTypeId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseCost = 500m,
                            CourseName = "Экспресс востановление волос",
                            CourseTypeId = 1,
                            DayDuration = "1"
                        },
                        new
                        {
                            Id = 2,
                            CourseCost = 500m,
                            CourseName = "Лаборатория цвета",
                            CourseTypeId = 2,
                            DayDuration = "1"
                        });
                });

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done.CourseAttendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("AttendenseDate");

                    b.Property<DateTimeOffset>("CourseDate");

                    b.Property<DateTimeOffset>("CourseEndDAte");

                    b.Property<int>("CourseId");

                    b.Property<int>("CustomerId");

                    b.Property<string>("Description");

                    b.Property<int>("Status");

                    b.Property<int?>("WorkerId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("WorkerId");

                    b.ToTable("CourseAttendances");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AttendenseDate = new DateTimeOffset(new DateTime(2019, 3, 5, 7, 41, 20, 362, DateTimeKind.Unspecified).AddTicks(2403), new TimeSpan(0, 0, 0, 0, 0)),
                            CourseDate = new DateTimeOffset(new DateTime(2019, 3, 19, 6, 41, 20, 362, DateTimeKind.Unspecified).AddTicks(2948), new TimeSpan(0, 0, 0, 0, 0)),
                            CourseEndDAte = new DateTimeOffset(new DateTime(2019, 3, 20, 7, 41, 20, 362, DateTimeKind.Unspecified).AddTicks(3430), new TimeSpan(0, 0, 0, 0, 0)),
                            CourseId = 1,
                            CustomerId = 1,
                            Description = "testDescription",
                            Status = 4
                        },
                        new
                        {
                            Id = 2,
                            AttendenseDate = new DateTimeOffset(new DateTime(2019, 3, 8, 7, 41, 20, 362, DateTimeKind.Unspecified).AddTicks(4735), new TimeSpan(0, 0, 0, 0, 0)),
                            CourseDate = new DateTimeOffset(new DateTime(2019, 3, 19, 9, 41, 20, 362, DateTimeKind.Unspecified).AddTicks(4742), new TimeSpan(0, 0, 0, 0, 0)),
                            CourseEndDAte = new DateTimeOffset(new DateTime(2019, 3, 20, 7, 41, 20, 362, DateTimeKind.Unspecified).AddTicks(4745), new TimeSpan(0, 0, 0, 0, 0)),
                            CourseId = 2,
                            CustomerId = 2,
                            Description = "testDescription",
                            Status = 4
                        },
                        new
                        {
                            Id = 3,
                            AttendenseDate = new DateTimeOffset(new DateTime(2019, 3, 7, 7, 41, 20, 362, DateTimeKind.Unspecified).AddTicks(4755), new TimeSpan(0, 0, 0, 0, 0)),
                            CourseDate = new DateTimeOffset(new DateTime(2019, 3, 20, 7, 41, 20, 362, DateTimeKind.Unspecified).AddTicks(4756), new TimeSpan(0, 0, 0, 0, 0)),
                            CourseEndDAte = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CourseId = 1,
                            CustomerId = 2,
                            Description = "testDescription",
                            Status = 3
                        },
                        new
                        {
                            Id = 4,
                            AttendenseDate = new DateTimeOffset(new DateTime(2019, 3, 6, 7, 41, 20, 362, DateTimeKind.Unspecified).AddTicks(4757), new TimeSpan(0, 0, 0, 0, 0)),
                            CourseDate = new DateTimeOffset(new DateTime(2019, 3, 20, 7, 41, 20, 362, DateTimeKind.Unspecified).AddTicks(4758), new TimeSpan(0, 0, 0, 0, 0)),
                            CourseEndDAte = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CourseId = 2,
                            CustomerId = 2,
                            Description = "testDescription",
                            Status = 1
                        },
                        new
                        {
                            Id = 5,
                            AttendenseDate = new DateTimeOffset(new DateTime(2019, 3, 4, 7, 41, 20, 362, DateTimeKind.Unspecified).AddTicks(4758), new TimeSpan(0, 0, 0, 0, 0)),
                            CourseDate = new DateTimeOffset(new DateTime(2019, 3, 20, 7, 41, 20, 362, DateTimeKind.Unspecified).AddTicks(4759), new TimeSpan(0, 0, 0, 0, 0)),
                            CourseEndDAte = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CourseId = 1,
                            CustomerId = 3,
                            Description = "testDescription",
                            Status = 0
                        });
                });

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done.CourseTopics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseTopicName");

                    b.HasKey("Id");

                    b.ToTable("CourseTopics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseTopicName = "Философия процедур"
                        },
                        new
                        {
                            Id = 2,
                            CourseTopicName = "Экспресс востановление"
                        },
                        new
                        {
                            Id = 3,
                            CourseTopicName = "Тонкости работы с краской DE LUXE"
                        },
                        new
                        {
                            Id = 4,
                            CourseTopicName = "Технология применения продукта"
                        },
                        new
                        {
                            Id = 5,
                            CourseTopicName = "Test 11"
                        },
                        new
                        {
                            Id = 6,
                            CourseTopicName = "Test 12"
                        });
                });

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done.CourseTopicsCourse", b =>
                {
                    b.Property<int>("CourseId");

                    b.Property<int>("CourseTopicsId");

                    b.HasKey("CourseId", "CourseTopicsId");

                    b.HasIndex("CourseTopicsId");

                    b.ToTable("CourseTopicsCourse");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            CourseTopicsId = 1
                        },
                        new
                        {
                            CourseId = 1,
                            CourseTopicsId = 2
                        },
                        new
                        {
                            CourseId = 1,
                            CourseTopicsId = 3
                        },
                        new
                        {
                            CourseId = 1,
                            CourseTopicsId = 4
                        },
                        new
                        {
                            CourseId = 2,
                            CourseTopicsId = 1
                        },
                        new
                        {
                            CourseId = 2,
                            CourseTopicsId = 2
                        },
                        new
                        {
                            CourseId = 2,
                            CourseTopicsId = 3
                        },
                        new
                        {
                            CourseId = 2,
                            CourseTopicsId = 4
                        },
                        new
                        {
                            CourseId = 1,
                            CourseTopicsId = 5
                        },
                        new
                        {
                            CourseId = 2,
                            CourseTopicsId = 5
                        },
                        new
                        {
                            CourseId = 1,
                            CourseTopicsId = 6
                        });
                });

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done.CourseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseTypeName");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("CourseTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseTypeName = "Курс PRODUCT-EXPERT",
                            Description = "Для участия в семенаре необходима предварительная запись"
                        },
                        new
                        {
                            Id = 2,
                            CourseTypeName = "Курс COLOR-EXPERT",
                            Description = "Для участия в семенаре необходима предварительная запись"
                        },
                        new
                        {
                            Id = 3,
                            CourseTypeName = "Курс INTENSE",
                            Description = "Для участия в семенаре необходима предварительная запись"
                        });
                });

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg.User", b =>
                {
                    b.HasBaseType("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg.Customer");

                    b.ToTable("User");

                    b.HasDiscriminator().HasValue("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTimeOffset(new DateTime(2018, 10, 21, 7, 41, 20, 329, DateTimeKind.Unspecified).AddTicks(5398), new TimeSpan(0, 0, 0, 0, 0)),
                            FirstName = "FirstName1",
                            IdentityId = 0,
                            IsEnabled = true,
                            LastName = "LastName1",
                            LogoPath = "c:\\",
                            MiddleName = "MiddleName1",
                            Telephone = "123456789"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTimeOffset(new DateTime(2018, 6, 18, 7, 41, 20, 329, DateTimeKind.Unspecified).AddTicks(7372), new TimeSpan(0, 0, 0, 0, 0)),
                            FirstName = "FirstName2",
                            IdentityId = 0,
                            IsEnabled = true,
                            LastName = "LastName2",
                            LogoPath = "c:\\",
                            MiddleName = "MiddleName2",
                            Telephone = "234567891"
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTimeOffset(new DateTime(2017, 4, 29, 7, 41, 20, 329, DateTimeKind.Unspecified).AddTicks(7392), new TimeSpan(0, 0, 0, 0, 0)),
                            FirstName = "FirstName3",
                            IdentityId = 0,
                            IsEnabled = true,
                            LastName = "LastName3",
                            LogoPath = "c:\\",
                            MiddleName = "MiddleName3",
                            Telephone = "345678912"
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = new DateTimeOffset(new DateTime(2016, 11, 20, 7, 41, 20, 329, DateTimeKind.Unspecified).AddTicks(7396), new TimeSpan(0, 0, 0, 0, 0)),
                            FirstName = "FirstName4",
                            IdentityId = 0,
                            IsEnabled = true,
                            LastName = "LastName4",
                            LogoPath = "c:\\",
                            MiddleName = "MiddleName4",
                            Telephone = "456789123"
                        },
                        new
                        {
                            Id = 5,
                            BirthDate = new DateTimeOffset(new DateTime(2016, 7, 6, 7, 41, 20, 329, DateTimeKind.Unspecified).AddTicks(7399), new TimeSpan(0, 0, 0, 0, 0)),
                            FirstName = "FirstName5",
                            IdentityId = 0,
                            IsEnabled = true,
                            LastName = "LastName5",
                            LogoPath = "c:\\",
                            MiddleName = "MiddleName5",
                            Telephone = "567891234"
                        });
                });

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg.Worker", b =>
                {
                    b.HasBaseType("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg.Customer");

                    b.Property<DateTimeOffset?>("RetirementDate");

                    b.Property<int>("StaffType");

                    b.Property<DateTimeOffset>("WorkFrom");

                    b.ToTable("Worker");

                    b.HasDiscriminator().HasValue("Worker");

                    b.HasData(
                        new
                        {
                            Id = 6,
                            BirthDate = new DateTimeOffset(new DateTime(2018, 10, 21, 7, 41, 20, 332, DateTimeKind.Unspecified).AddTicks(4444), new TimeSpan(0, 0, 0, 0, 0)),
                            FirstName = "WorkerFirstName1",
                            IdentityId = 0,
                            IsEnabled = true,
                            LastName = "WorkerLastName1",
                            LogoPath = "c:\\Worker",
                            MiddleName = "WorkerMiddleName1",
                            Telephone = "Worker123456789",
                            StaffType = 0,
                            WorkFrom = new DateTimeOffset(new DateTime(2019, 3, 5, 7, 41, 20, 332, DateTimeKind.Unspecified).AddTicks(4454), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = 7,
                            BirthDate = new DateTimeOffset(new DateTime(2018, 6, 18, 7, 41, 20, 332, DateTimeKind.Unspecified).AddTicks(5540), new TimeSpan(0, 0, 0, 0, 0)),
                            FirstName = "WorkerFirstName2",
                            IdentityId = 0,
                            IsEnabled = true,
                            LastName = "WorkerLastName2",
                            LogoPath = "c:\\Worker",
                            MiddleName = "WorkerMiddleName2",
                            Telephone = "Worker234567891",
                            StaffType = 3,
                            WorkFrom = new DateTimeOffset(new DateTime(2019, 3, 8, 7, 41, 20, 332, DateTimeKind.Unspecified).AddTicks(5543), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = 8,
                            BirthDate = new DateTimeOffset(new DateTime(2017, 4, 29, 7, 41, 20, 332, DateTimeKind.Unspecified).AddTicks(5550), new TimeSpan(0, 0, 0, 0, 0)),
                            FirstName = "WorkerFirstName3",
                            IdentityId = 0,
                            IsEnabled = true,
                            LastName = "WorkerLastName3",
                            LogoPath = "c:\\Worker",
                            MiddleName = "WorkerMiddleName3",
                            Telephone = "Worker345678912",
                            StaffType = 1,
                            WorkFrom = new DateTimeOffset(new DateTime(2019, 3, 7, 7, 41, 20, 332, DateTimeKind.Unspecified).AddTicks(5551), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = 9,
                            BirthDate = new DateTimeOffset(new DateTime(2016, 11, 20, 7, 41, 20, 332, DateTimeKind.Unspecified).AddTicks(5552), new TimeSpan(0, 0, 0, 0, 0)),
                            FirstName = "WorkerFirstName4",
                            IdentityId = 0,
                            IsEnabled = true,
                            LastName = "WorkerLastName4",
                            LogoPath = "c:\\Worker",
                            MiddleName = "WorkerMiddleName4",
                            Telephone = "Worker456789123",
                            StaffType = 2,
                            WorkFrom = new DateTimeOffset(new DateTime(2019, 2, 23, 7, 41, 20, 332, DateTimeKind.Unspecified).AddTicks(5553), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = 10,
                            BirthDate = new DateTimeOffset(new DateTime(2016, 7, 6, 7, 41, 20, 332, DateTimeKind.Unspecified).AddTicks(5554), new TimeSpan(0, 0, 0, 0, 0)),
                            FirstName = "WorkerFirstName5",
                            IdentityId = 0,
                            IsEnabled = true,
                            LastName = "WorkerLastName5",
                            LogoPath = "c:\\Worker",
                            MiddleName = "WorkerMiddleName5",
                            Telephone = "Worker567891234",
                            StaffType = 0,
                            WorkFrom = new DateTimeOffset(new DateTime(2019, 1, 4, 7, 41, 20, 332, DateTimeKind.Unspecified).AddTicks(5555), new TimeSpan(0, 0, 0, 0, 0))
                        });
                });

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done.AdditionalAmenityCourse", b =>
                {
                    b.HasOne("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done.AdditionalAmenity", "AdditionalAmenity")
                        .WithMany("AdditionalAmenityCourses")
                        .HasForeignKey("AdditionalAmenityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done.Course", "Course")
                        .WithMany("AdditionalAmenityCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done.AvailableDatesCourse", b =>
                {
                    b.HasOne("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done.AvailableDates", "AvailableDates")
                        .WithMany("Courses")
                        .HasForeignKey("AvailableDatesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done.Course", "Course")
                        .WithMany("AvailableDates")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done.Course", b =>
                {
                    b.HasOne("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done.CourseType", "CourseType")
                        .WithMany("Courses")
                        .HasForeignKey("CourseTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done.CourseAttendance", b =>
                {
                    b.HasOne("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done.Course", "Course")
                        .WithMany("CourseAttendances")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg.User", "User")
                        .WithMany("CourseAttendances")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg.Worker")
                        .WithMany("CourseAttendances")
                        .HasForeignKey("WorkerId");
                });

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done.CourseTopicsCourse", b =>
                {
                    b.HasOne("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done.Course", "Course")
                        .WithMany("CourseTopics")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done.CourseTopics", "CourseTopics")
                        .WithMany("Courses")
                        .HasForeignKey("CourseTopicsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
