namespace EstelApi.Domain.DataAccessLayer.Context.Migrations
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <summary>
    /// The fix d course dates.
    /// </summary>
    public partial class FixDCourseDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AvailableDatesCourse",
                table: "AvailableDatesCourse");

            migrationBuilder.DropIndex(
                name: "IX_AvailableDatesCourse_CourseId",
                table: "AvailableDatesCourse");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AvailableDatesCourse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AvailableDatesCourse",
                table: "AvailableDatesCourse",
                columns: new[] { "CourseId", "AvailableDatesId" });

            migrationBuilder.InsertData(
                table: "AvailableDatesCourse",
                columns: new[] { "CourseId", "AvailableDatesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 3 },
                    { 2, 2 },
                    { 2, 1 },
                    { 1, 4 },
                    { 1, 3 },
                    { 1, 2 }
                });

            migrationBuilder.UpdateData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AttendenseDate", "CourseDate", "CourseEndDAte" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 3, 8, 18, 4, 4, 915, DateTimeKind.Unspecified).AddTicks(7457), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 22, 17, 4, 4, 915, DateTimeKind.Unspecified).AddTicks(8013), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 23, 18, 4, 4, 915, DateTimeKind.Unspecified).AddTicks(8678), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AttendenseDate", "CourseDate", "CourseEndDAte" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 3, 11, 18, 4, 4, 916, DateTimeKind.Unspecified).AddTicks(128), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 22, 20, 4, 4, 916, DateTimeKind.Unspecified).AddTicks(135), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 23, 18, 4, 4, 916, DateTimeKind.Unspecified).AddTicks(138), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AttendenseDate", "CourseDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 3, 10, 18, 4, 4, 916, DateTimeKind.Unspecified).AddTicks(149), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 23, 18, 4, 4, 916, DateTimeKind.Unspecified).AddTicks(150), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AttendenseDate", "CourseDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 3, 9, 18, 4, 4, 916, DateTimeKind.Unspecified).AddTicks(151), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 23, 18, 4, 4, 916, DateTimeKind.Unspecified).AddTicks(152), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AttendenseDate", "CourseDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 3, 7, 18, 4, 4, 916, DateTimeKind.Unspecified).AddTicks(153), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 23, 18, 4, 4, 916, DateTimeKind.Unspecified).AddTicks(154), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(2018, 10, 24, 18, 4, 4, 879, DateTimeKind.Unspecified).AddTicks(3343), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(2018, 6, 21, 18, 4, 4, 879, DateTimeKind.Unspecified).AddTicks(5824), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(2017, 5, 2, 18, 4, 4, 879, DateTimeKind.Unspecified).AddTicks(5845), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(2016, 11, 23, 18, 4, 4, 879, DateTimeKind.Unspecified).AddTicks(5847), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(2016, 7, 9, 18, 4, 4, 879, DateTimeKind.Unspecified).AddTicks(5849), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BirthDate", "WorkFrom" },
                values: new object[] { new DateTimeOffset(new DateTime(2018, 10, 24, 18, 4, 4, 884, DateTimeKind.Unspecified).AddTicks(902), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 8, 18, 4, 4, 884, DateTimeKind.Unspecified).AddTicks(914), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BirthDate", "WorkFrom" },
                values: new object[] { new DateTimeOffset(new DateTime(2018, 6, 21, 18, 4, 4, 884, DateTimeKind.Unspecified).AddTicks(2658), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 11, 18, 4, 4, 884, DateTimeKind.Unspecified).AddTicks(2663), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BirthDate", "WorkFrom" },
                values: new object[] { new DateTimeOffset(new DateTime(2017, 5, 2, 18, 4, 4, 884, DateTimeKind.Unspecified).AddTicks(2674), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 10, 18, 4, 4, 884, DateTimeKind.Unspecified).AddTicks(2675), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BirthDate", "WorkFrom" },
                values: new object[] { new DateTimeOffset(new DateTime(2016, 11, 23, 18, 4, 4, 884, DateTimeKind.Unspecified).AddTicks(2676), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 2, 26, 18, 4, 4, 884, DateTimeKind.Unspecified).AddTicks(2677), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BirthDate", "WorkFrom" },
                values: new object[] { new DateTimeOffset(new DateTime(2016, 7, 9, 18, 4, 4, 884, DateTimeKind.Unspecified).AddTicks(2679), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 7, 18, 4, 4, 884, DateTimeKind.Unspecified).AddTicks(2680), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AvailableDatesCourse",
                table: "AvailableDatesCourse");

            migrationBuilder.DeleteData(
                table: "AvailableDatesCourse",
                keyColumns: new[] { "CourseId", "AvailableDatesId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AvailableDatesCourse",
                keyColumns: new[] { "CourseId", "AvailableDatesId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "AvailableDatesCourse",
                keyColumns: new[] { "CourseId", "AvailableDatesId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "AvailableDatesCourse",
                keyColumns: new[] { "CourseId", "AvailableDatesId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "AvailableDatesCourse",
                keyColumns: new[] { "CourseId", "AvailableDatesId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "AvailableDatesCourse",
                keyColumns: new[] { "CourseId", "AvailableDatesId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AvailableDatesCourse",
                keyColumns: new[] { "CourseId", "AvailableDatesId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AvailableDatesCourse",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AvailableDatesCourse",
                table: "AvailableDatesCourse",
                column: "Id");

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
                name: "IX_AvailableDatesCourse_CourseId",
                table: "AvailableDatesCourse",
                column: "CourseId");
        }
    }
}
