using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstelApi.Domain.DataAccessLayer.Context.Migrations
{
    public partial class UpdateAvlDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailableDates_Courses_CourseId",
                table: "AvailableDates");

            migrationBuilder.DropIndex(
                name: "IX_AvailableDates_CourseId",
                table: "AvailableDates");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "AvailableDates");

            migrationBuilder.CreateTable(
                name: "AvailableDatesCourse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvailableDatesId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableDatesCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableDatesCourse_AvailableDates_AvailableDatesId",
                        column: x => x.AvailableDatesId,
                        principalTable: "AvailableDates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailableDatesCourse_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AttendenseDate", "CourseDate", "CourseEndDAte" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 3, 5, 7, 41, 20, 362, DateTimeKind.Unspecified).AddTicks(2403), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 19, 6, 41, 20, 362, DateTimeKind.Unspecified).AddTicks(2948), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 20, 7, 41, 20, 362, DateTimeKind.Unspecified).AddTicks(3430), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AttendenseDate", "CourseDate", "CourseEndDAte" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 3, 8, 7, 41, 20, 362, DateTimeKind.Unspecified).AddTicks(4735), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 19, 9, 41, 20, 362, DateTimeKind.Unspecified).AddTicks(4742), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 20, 7, 41, 20, 362, DateTimeKind.Unspecified).AddTicks(4745), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AttendenseDate", "CourseDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 3, 7, 7, 41, 20, 362, DateTimeKind.Unspecified).AddTicks(4755), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 20, 7, 41, 20, 362, DateTimeKind.Unspecified).AddTicks(4756), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AttendenseDate", "CourseDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 3, 6, 7, 41, 20, 362, DateTimeKind.Unspecified).AddTicks(4757), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 20, 7, 41, 20, 362, DateTimeKind.Unspecified).AddTicks(4758), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AttendenseDate", "CourseDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 3, 4, 7, 41, 20, 362, DateTimeKind.Unspecified).AddTicks(4758), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 20, 7, 41, 20, 362, DateTimeKind.Unspecified).AddTicks(4759), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(2018, 10, 21, 7, 41, 20, 329, DateTimeKind.Unspecified).AddTicks(5398), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(2018, 6, 18, 7, 41, 20, 329, DateTimeKind.Unspecified).AddTicks(7372), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(2017, 4, 29, 7, 41, 20, 329, DateTimeKind.Unspecified).AddTicks(7392), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(2016, 11, 20, 7, 41, 20, 329, DateTimeKind.Unspecified).AddTicks(7396), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(2016, 7, 6, 7, 41, 20, 329, DateTimeKind.Unspecified).AddTicks(7399), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BirthDate", "WorkFrom" },
                values: new object[] { new DateTimeOffset(new DateTime(2018, 10, 21, 7, 41, 20, 332, DateTimeKind.Unspecified).AddTicks(4444), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 5, 7, 41, 20, 332, DateTimeKind.Unspecified).AddTicks(4454), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BirthDate", "WorkFrom" },
                values: new object[] { new DateTimeOffset(new DateTime(2018, 6, 18, 7, 41, 20, 332, DateTimeKind.Unspecified).AddTicks(5540), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 8, 7, 41, 20, 332, DateTimeKind.Unspecified).AddTicks(5543), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BirthDate", "WorkFrom" },
                values: new object[] { new DateTimeOffset(new DateTime(2017, 4, 29, 7, 41, 20, 332, DateTimeKind.Unspecified).AddTicks(5550), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 7, 7, 41, 20, 332, DateTimeKind.Unspecified).AddTicks(5551), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BirthDate", "WorkFrom" },
                values: new object[] { new DateTimeOffset(new DateTime(2016, 11, 20, 7, 41, 20, 332, DateTimeKind.Unspecified).AddTicks(5552), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 23, 7, 41, 20, 332, DateTimeKind.Unspecified).AddTicks(5553), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BirthDate", "WorkFrom" },
                values: new object[] { new DateTimeOffset(new DateTime(2016, 7, 6, 7, 41, 20, 332, DateTimeKind.Unspecified).AddTicks(5554), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 4, 7, 41, 20, 332, DateTimeKind.Unspecified).AddTicks(5555), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableDatesCourse_AvailableDatesId",
                table: "AvailableDatesCourse",
                column: "AvailableDatesId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableDatesCourse_CourseId",
                table: "AvailableDatesCourse",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableDatesCourse");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "AvailableDates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AvailableDates",
                keyColumn: "Id",
                keyValue: 1,
                column: "CourseId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AvailableDates",
                keyColumn: "Id",
                keyValue: 2,
                column: "CourseId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AvailableDates",
                keyColumn: "Id",
                keyValue: 3,
                column: "CourseId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AvailableDates",
                keyColumn: "Id",
                keyValue: 4,
                column: "CourseId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AttendenseDate", "CourseDate", "CourseEndDAte" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 3, 4, 20, 23, 4, 938, DateTimeKind.Unspecified).AddTicks(4684), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 18, 19, 23, 4, 938, DateTimeKind.Unspecified).AddTicks(6372), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 19, 20, 23, 4, 938, DateTimeKind.Unspecified).AddTicks(7181), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AttendenseDate", "CourseDate", "CourseEndDAte" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 3, 7, 20, 23, 4, 938, DateTimeKind.Unspecified).AddTicks(9217), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 18, 22, 23, 4, 938, DateTimeKind.Unspecified).AddTicks(9227), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 19, 20, 23, 4, 938, DateTimeKind.Unspecified).AddTicks(9233), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AttendenseDate", "CourseDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 3, 6, 20, 23, 4, 938, DateTimeKind.Unspecified).AddTicks(9248), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 19, 20, 23, 4, 938, DateTimeKind.Unspecified).AddTicks(9250), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AttendenseDate", "CourseDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 3, 5, 20, 23, 4, 938, DateTimeKind.Unspecified).AddTicks(9251), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 19, 20, 23, 4, 938, DateTimeKind.Unspecified).AddTicks(9252), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AttendenseDate", "CourseDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 3, 3, 20, 23, 4, 938, DateTimeKind.Unspecified).AddTicks(9254), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 19, 20, 23, 4, 938, DateTimeKind.Unspecified).AddTicks(9255), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(2018, 10, 20, 20, 23, 4, 884, DateTimeKind.Unspecified).AddTicks(5607), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(2018, 6, 17, 20, 23, 4, 884, DateTimeKind.Unspecified).AddTicks(7527), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(2017, 4, 28, 20, 23, 4, 884, DateTimeKind.Unspecified).AddTicks(7547), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(2016, 11, 19, 20, 23, 4, 884, DateTimeKind.Unspecified).AddTicks(7550), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(2016, 7, 5, 20, 23, 4, 884, DateTimeKind.Unspecified).AddTicks(7552), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BirthDate", "WorkFrom" },
                values: new object[] { new DateTimeOffset(new DateTime(2018, 10, 20, 20, 23, 4, 887, DateTimeKind.Unspecified).AddTicks(6649), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 4, 20, 23, 4, 887, DateTimeKind.Unspecified).AddTicks(6660), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BirthDate", "WorkFrom" },
                values: new object[] { new DateTimeOffset(new DateTime(2018, 6, 17, 20, 23, 4, 887, DateTimeKind.Unspecified).AddTicks(8014), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 7, 20, 23, 4, 887, DateTimeKind.Unspecified).AddTicks(8018), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BirthDate", "WorkFrom" },
                values: new object[] { new DateTimeOffset(new DateTime(2017, 4, 28, 20, 23, 4, 887, DateTimeKind.Unspecified).AddTicks(8029), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 6, 20, 23, 4, 887, DateTimeKind.Unspecified).AddTicks(8030), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BirthDate", "WorkFrom" },
                values: new object[] { new DateTimeOffset(new DateTime(2016, 11, 19, 20, 23, 4, 887, DateTimeKind.Unspecified).AddTicks(8033), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 22, 20, 23, 4, 887, DateTimeKind.Unspecified).AddTicks(8034), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BirthDate", "WorkFrom" },
                values: new object[] { new DateTimeOffset(new DateTime(2016, 7, 5, 20, 23, 4, 887, DateTimeKind.Unspecified).AddTicks(8036), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 3, 20, 23, 4, 887, DateTimeKind.Unspecified).AddTicks(8037), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableDates_CourseId",
                table: "AvailableDates",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableDates_Courses_CourseId",
                table: "AvailableDates",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
