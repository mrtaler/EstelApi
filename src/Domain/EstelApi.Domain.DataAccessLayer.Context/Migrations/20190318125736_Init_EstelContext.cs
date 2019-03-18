using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstelApi.Domain.DataAccessLayer.Context.Migrations
{
    public partial class Init_EstelContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditionalAmenities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdditionalAmenityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalAmenities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseTopics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseTopicName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTopics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseTypeName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdentityId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTimeOffset>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false),
                    LogoPath = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    WorkFrom = table.Column<DateTimeOffset>(nullable: true),
                    RetirementDate = table.Column<DateTimeOffset>(nullable: true),
                    StaffType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CustomerId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseName = table.Column<string>(nullable: true),
                    DayDuration = table.Column<string>(nullable: true),
                    CourseCost = table.Column<decimal>(nullable: false),
                    CourseTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_CourseTypes_CourseTypeId",
                        column: x => x.CourseTypeId,
                        principalTable: "CourseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalAmenityCourse",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false),
                    AdditionalAmenityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalAmenityCourse", x => new { x.CourseId, x.AdditionalAmenityId });
                    table.ForeignKey(
                        name: "FK_AdditionalAmenityCourse_AdditionalAmenities_AdditionalAmenityId",
                        column: x => x.AdditionalAmenityId,
                        principalTable: "AdditionalAmenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditionalAmenityCourse_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvailableDates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Month = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    StartHour = table.Column<string>(nullable: true),
                    EndHour = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableDates_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseAttendances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: true),
                    CourseId = table.Column<int>(nullable: true),
                    AttendenseDate = table.Column<DateTimeOffset>(nullable: false),
                    CourseDate = table.Column<DateTimeOffset>(nullable: false),
                    CourseEndDAte = table.Column<DateTimeOffset>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseAttendances_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseAttendances_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseTopicsCourse",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false),
                    CourseTopicsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTopicsCourse", x => new { x.CourseId, x.CourseTopicsId });
                    table.ForeignKey(
                        name: "FK_CourseTopicsCourse_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTopicsCourse_CourseTopics_CourseTopicsId",
                        column: x => x.CourseTopicsId,
                        principalTable: "CourseTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdditionalAmenities",
                columns: new[] { "Id", "AdditionalAmenityName" },
                values: new object[,]
                {
                    { 1, "Практическая обработка" },
                    { 2, "Кофе брейк" },
                    { 3, "Сертификат" }
                });

            migrationBuilder.InsertData(
                table: "CourseTopics",
                columns: new[] { "Id", "CourseTopicName" },
                values: new object[,]
                {
                    { 1, "Философия процедур" },
                    { 2, "Экспресс востановление" },
                    { 3, "Тонкости работы с краской DE LUXE" },
                    { 4, "Технология применения продукта" },
                    { 5, "Test 11" },
                    { 6, "Test 12" }
                });

            migrationBuilder.InsertData(
                table: "CourseTypes",
                columns: new[] { "Id", "CourseTypeName", "Description" },
                values: new object[,]
                {
                    { 1, "Курс PRODUCT-EXPERT", "Для участия в семенаре необходима предварительная запись" },
                    { 2, "Курс COLOR-EXPERT", "Для участия в семенаре необходима предварительная запись" },
                    { 3, "Курс INTENSE", "Для участия в семенаре необходима предварительная запись" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseCost", "CourseName", "CourseTypeId", "DayDuration" },
                values: new object[] { 1, 500m, "Экспресс востановление волос", 1, "1" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseCost", "CourseName", "CourseTypeId", "DayDuration" },
                values: new object[] { 2, 500m, "Лаборатория цвета", 2, "1" });

            migrationBuilder.InsertData(
                table: "AdditionalAmenityCourse",
                columns: new[] { "CourseId", "AdditionalAmenityId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 2 },
                    { 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "AvailableDates",
                columns: new[] { "Id", "CourseId", "Date", "EndHour", "Month", "StartHour" },
                values: new object[,]
                {
                    { 1, 1, "12", "18", "Сентябрь", "11" },
                    { 2, 1, "4", "18", "Октябрь", "11" },
                    { 4, 2, "30", "18", "Декабрь", "11" },
                    { 3, 2, "1", "18", "Ноябрь", "11" }
                });

            migrationBuilder.InsertData(
                table: "CourseTopicsCourse",
                columns: new[] { "CourseId", "CourseTopicsId" },
                values: new object[,]
                {
                    { 2, 3 },
                    { 2, 2 },
                    { 2, 1 },
                    { 1, 5 },
                    { 2, 4 },
                    { 1, 4 },
                    { 1, 3 },
                    { 1, 2 },
                    { 1, 1 },
                    { 1, 6 },
                    { 2, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalAmenityCourse_AdditionalAmenityId",
                table: "AdditionalAmenityCourse",
                column: "AdditionalAmenityId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableDates_CourseId",
                table: "AvailableDates",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAttendances_CourseId",
                table: "CourseAttendances",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAttendances_CustomerId",
                table: "CourseAttendances",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseTypeId",
                table: "Courses",
                column: "CourseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTopicsCourse_CourseTopicsId",
                table: "CourseTopicsCourse",
                column: "CourseTopicsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalAmenityCourse");

            migrationBuilder.DropTable(
                name: "AvailableDates");

            migrationBuilder.DropTable(
                name: "CourseAttendances");

            migrationBuilder.DropTable(
                name: "CourseTopicsCourse");

            migrationBuilder.DropTable(
                name: "AdditionalAmenities");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "CourseTopics");

            migrationBuilder.DropTable(
                name: "CourseTypes");
        }
    }
}
