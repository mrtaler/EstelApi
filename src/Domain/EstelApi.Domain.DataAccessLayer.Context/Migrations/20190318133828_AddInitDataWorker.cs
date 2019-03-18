using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstelApi.Domain.DataAccessLayer.Context.Migrations
{
    public partial class AddInitDataWorker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StaffType",
                table: "Customer",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AttendenseDate", "CourseDate", "CourseEndDAte" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 3, 3, 13, 38, 28, 55, DateTimeKind.Unspecified).AddTicks(9864), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 17, 12, 38, 28, 56, DateTimeKind.Unspecified).AddTicks(509), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 18, 13, 38, 28, 56, DateTimeKind.Unspecified).AddTicks(1232), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AttendenseDate", "CourseDate", "CourseEndDAte" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 3, 6, 13, 38, 28, 56, DateTimeKind.Unspecified).AddTicks(2799), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 17, 15, 38, 28, 56, DateTimeKind.Unspecified).AddTicks(2808), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 18, 13, 38, 28, 56, DateTimeKind.Unspecified).AddTicks(2814), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AttendenseDate", "CourseDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 3, 5, 13, 38, 28, 56, DateTimeKind.Unspecified).AddTicks(2830), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 18, 13, 38, 28, 56, DateTimeKind.Unspecified).AddTicks(2831), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AttendenseDate", "CourseDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 3, 4, 13, 38, 28, 56, DateTimeKind.Unspecified).AddTicks(2832), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 18, 13, 38, 28, 56, DateTimeKind.Unspecified).AddTicks(2833), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AttendenseDate", "CourseDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 3, 2, 13, 38, 28, 56, DateTimeKind.Unspecified).AddTicks(2834), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 18, 13, 38, 28, 56, DateTimeKind.Unspecified).AddTicks(2835), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(2018, 10, 19, 13, 38, 28, 28, DateTimeKind.Unspecified).AddTicks(5104), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(2018, 6, 16, 13, 38, 28, 28, DateTimeKind.Unspecified).AddTicks(6921), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(2017, 4, 27, 13, 38, 28, 28, DateTimeKind.Unspecified).AddTicks(6943), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(2016, 11, 18, 13, 38, 28, 28, DateTimeKind.Unspecified).AddTicks(6945), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(2016, 7, 4, 13, 38, 28, 28, DateTimeKind.Unspecified).AddTicks(6947), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BirthDate", "StaffType", "WorkFrom" },
                values: new object[] { new DateTimeOffset(new DateTime(2018, 10, 19, 13, 38, 28, 31, DateTimeKind.Unspecified).AddTicks(6462), new TimeSpan(0, 0, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2019, 3, 3, 13, 38, 28, 31, DateTimeKind.Unspecified).AddTicks(6471), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BirthDate", "StaffType", "WorkFrom" },
                values: new object[] { new DateTimeOffset(new DateTime(2018, 6, 16, 13, 38, 28, 31, DateTimeKind.Unspecified).AddTicks(7808), new TimeSpan(0, 0, 0, 0, 0)), 3, new DateTimeOffset(new DateTime(2019, 3, 6, 13, 38, 28, 31, DateTimeKind.Unspecified).AddTicks(7812), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BirthDate", "StaffType", "WorkFrom" },
                values: new object[] { new DateTimeOffset(new DateTime(2017, 4, 27, 13, 38, 28, 31, DateTimeKind.Unspecified).AddTicks(7824), new TimeSpan(0, 0, 0, 0, 0)), 1, new DateTimeOffset(new DateTime(2019, 3, 5, 13, 38, 28, 31, DateTimeKind.Unspecified).AddTicks(7825), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BirthDate", "StaffType", "WorkFrom" },
                values: new object[] { new DateTimeOffset(new DateTime(2016, 11, 18, 13, 38, 28, 31, DateTimeKind.Unspecified).AddTicks(7827), new TimeSpan(0, 0, 0, 0, 0)), 2, new DateTimeOffset(new DateTime(2019, 2, 21, 13, 38, 28, 31, DateTimeKind.Unspecified).AddTicks(7828), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BirthDate", "StaffType", "WorkFrom" },
                values: new object[] { new DateTimeOffset(new DateTime(2016, 7, 4, 13, 38, 28, 31, DateTimeKind.Unspecified).AddTicks(7829), new TimeSpan(0, 0, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2019, 1, 2, 13, 38, 28, 31, DateTimeKind.Unspecified).AddTicks(7830), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StaffType",
                table: "Customer",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AttendenseDate", "CourseDate", "CourseEndDAte" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 3, 3, 13, 33, 4, 612, DateTimeKind.Unspecified).AddTicks(9815), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 17, 12, 33, 4, 613, DateTimeKind.Unspecified).AddTicks(322), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 18, 13, 33, 4, 613, DateTimeKind.Unspecified).AddTicks(767), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AttendenseDate", "CourseDate", "CourseEndDAte" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 3, 6, 13, 33, 4, 613, DateTimeKind.Unspecified).AddTicks(1977), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 17, 15, 33, 4, 613, DateTimeKind.Unspecified).AddTicks(1983), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 18, 13, 33, 4, 613, DateTimeKind.Unspecified).AddTicks(1987), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AttendenseDate", "CourseDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 3, 5, 13, 33, 4, 613, DateTimeKind.Unspecified).AddTicks(1997), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 18, 13, 33, 4, 613, DateTimeKind.Unspecified).AddTicks(1998), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AttendenseDate", "CourseDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 3, 4, 13, 33, 4, 613, DateTimeKind.Unspecified).AddTicks(1999), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 18, 13, 33, 4, 613, DateTimeKind.Unspecified).AddTicks(2000), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AttendenseDate", "CourseDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 3, 2, 13, 33, 4, 613, DateTimeKind.Unspecified).AddTicks(2001), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 18, 13, 33, 4, 613, DateTimeKind.Unspecified).AddTicks(2001), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(2018, 10, 19, 13, 33, 4, 582, DateTimeKind.Unspecified).AddTicks(6194), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(2018, 6, 16, 13, 33, 4, 582, DateTimeKind.Unspecified).AddTicks(7912), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(2017, 4, 27, 13, 33, 4, 582, DateTimeKind.Unspecified).AddTicks(7930), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(2016, 11, 18, 13, 33, 4, 582, DateTimeKind.Unspecified).AddTicks(7932), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(2016, 7, 4, 13, 33, 4, 582, DateTimeKind.Unspecified).AddTicks(7934), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BirthDate", "StaffType", "WorkFrom" },
                values: new object[] { new DateTimeOffset(new DateTime(2018, 10, 19, 13, 33, 4, 586, DateTimeKind.Unspecified).AddTicks(3140), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2019, 3, 3, 13, 33, 4, 586, DateTimeKind.Unspecified).AddTicks(3164), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BirthDate", "StaffType", "WorkFrom" },
                values: new object[] { new DateTimeOffset(new DateTime(2018, 6, 16, 13, 33, 4, 586, DateTimeKind.Unspecified).AddTicks(4008), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2019, 3, 6, 13, 33, 4, 586, DateTimeKind.Unspecified).AddTicks(4012), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BirthDate", "StaffType", "WorkFrom" },
                values: new object[] { new DateTimeOffset(new DateTime(2017, 4, 27, 13, 33, 4, 586, DateTimeKind.Unspecified).AddTicks(4019), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2019, 3, 5, 13, 33, 4, 586, DateTimeKind.Unspecified).AddTicks(4020), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BirthDate", "StaffType", "WorkFrom" },
                values: new object[] { new DateTimeOffset(new DateTime(2016, 11, 18, 13, 33, 4, 586, DateTimeKind.Unspecified).AddTicks(4022), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2019, 2, 21, 13, 33, 4, 586, DateTimeKind.Unspecified).AddTicks(4023), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BirthDate", "StaffType", "WorkFrom" },
                values: new object[] { new DateTimeOffset(new DateTime(2016, 7, 4, 13, 33, 4, 586, DateTimeKind.Unspecified).AddTicks(4025), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2019, 1, 2, 13, 33, 4, 586, DateTimeKind.Unspecified).AddTicks(4025), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
