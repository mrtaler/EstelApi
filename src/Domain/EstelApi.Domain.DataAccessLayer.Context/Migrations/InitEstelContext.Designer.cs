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
    [Migration("20190318125736_Init_EstelContext")]
    partial class InitEstelContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.AdditionalAmenity", b =>
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

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.AdditionalAmenityCourse", b =>
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

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.AvailableDates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId");

                    b.Property<string>("Date");

                    b.Property<string>("EndHour");

                    b.Property<string>("Month");

                    b.Property<string>("StartHour");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("AvailableDates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            Date = "12",
                            EndHour = "18",
                            Month = "Сентябрь",
                            StartHour = "11"
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 1,
                            Date = "4",
                            EndHour = "18",
                            Month = "Октябрь",
                            StartHour = "11"
                        },
                        new
                        {
                            Id = 3,
                            CourseId = 2,
                            Date = "1",
                            EndHour = "18",
                            Month = "Ноябрь",
                            StartHour = "11"
                        },
                        new
                        {
                            Id = 4,
                            CourseId = 2,
                            Date = "30",
                            EndHour = "18",
                            Month = "Декабрь",
                            StartHour = "11"
                        });
                });

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Course", b =>
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

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CourseAttendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("AttendenseDate");

                    b.Property<DateTimeOffset>("CourseDate");

                    b.Property<DateTimeOffset>("CourseEndDAte");

                    b.Property<int?>("CourseId");

                    b.Property<int?>("CustomerId");

                    b.Property<string>("Description");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CourseAttendances");
                });

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CourseTopics", b =>
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

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CourseTopicsCourse", b =>
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

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CourseType", b =>
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

                    b.HasKey("Id")
                        .HasName("CustomerId");

                    b.ToTable("Customer");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Customer");
                });

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg.Worker", b =>
                {
                    b.HasBaseType("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg.Customer");

                    b.Property<DateTimeOffset>("RetirementDate");

                    b.Property<string>("StaffType");

                    b.Property<DateTimeOffset>("WorkFrom");

                    b.ToTable("Worker");

                    b.HasDiscriminator().HasValue("Worker");
                });

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.AdditionalAmenityCourse", b =>
                {
                    b.HasOne("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.AdditionalAmenity", "AdditionalAmenity")
                        .WithMany("AdditionalAmenityCourses")
                        .HasForeignKey("AdditionalAmenityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Course", "Course")
                        .WithMany("AdditionalAmenityCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.AvailableDates", b =>
                {
                    b.HasOne("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Course", "Course")
                        .WithMany("AvailableDates")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Course", b =>
                {
                    b.HasOne("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CourseType", "CourseType")
                        .WithMany("Courses")
                        .HasForeignKey("CourseTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CourseAttendance", b =>
                {
                    b.HasOne("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Course", "Course")
                        .WithMany("Customers")
                        .HasForeignKey("CourseId");

                    b.HasOne("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg.Customer", "Customer")
                        .WithMany("Couses")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CourseTopicsCourse", b =>
                {
                    b.HasOne("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Course", "Course")
                        .WithMany("CourseTopics")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CourseTopics", "CourseTopics")
                        .WithMany("Courses")
                        .HasForeignKey("CourseTopicsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
