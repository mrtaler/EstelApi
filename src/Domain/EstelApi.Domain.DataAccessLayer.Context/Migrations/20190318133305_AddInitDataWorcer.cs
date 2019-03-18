using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstelApi.Domain.DataAccessLayer.Context.Migrations
{
    public partial class AddInitDataWorcer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseAttendances_Courses_CourseId",
                table: "CourseAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseAttendances_Customer_CustomerId",
                table: "CourseAttendances");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CourseAttendances",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "CourseAttendances",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "BirthDate", "Discriminator", "FirstName", "IdentityId", "IsEnabled", "LastName", "LogoPath", "MiddleName", "Telephone" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2018, 10, 19, 13, 33, 4, 582, DateTimeKind.Unspecified).AddTicks(6194), new TimeSpan(0, 0, 0, 0, 0)), "Customer", "FirstName1", 0, true, "LastName1", "c:\\", "MiddleName1", "123456789" },
                    { 2, new DateTimeOffset(new DateTime(2018, 6, 16, 13, 33, 4, 582, DateTimeKind.Unspecified).AddTicks(7912), new TimeSpan(0, 0, 0, 0, 0)), "Customer", "FirstName2", 0, true, "LastName2", "c:\\", "MiddleName2", "234567891" },
                    { 3, new DateTimeOffset(new DateTime(2017, 4, 27, 13, 33, 4, 582, DateTimeKind.Unspecified).AddTicks(7930), new TimeSpan(0, 0, 0, 0, 0)), "Customer", "FirstName3", 0, true, "LastName3", "c:\\", "MiddleName3", "345678912" },
                    { 4, new DateTimeOffset(new DateTime(2016, 11, 18, 13, 33, 4, 582, DateTimeKind.Unspecified).AddTicks(7932), new TimeSpan(0, 0, 0, 0, 0)), "Customer", "FirstName4", 0, true, "LastName4", "c:\\", "MiddleName4", "456789123" },
                    { 5, new DateTimeOffset(new DateTime(2016, 7, 4, 13, 33, 4, 582, DateTimeKind.Unspecified).AddTicks(7934), new TimeSpan(0, 0, 0, 0, 0)), "Customer", "FirstName5", 0, true, "LastName5", "c:\\", "MiddleName5", "567891234" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "BirthDate", "Discriminator", "FirstName", "IdentityId", "IsEnabled", "LastName", "LogoPath", "MiddleName", "Telephone", "RetirementDate", "StaffType", "WorkFrom" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2018, 10, 19, 13, 33, 4, 586, DateTimeKind.Unspecified).AddTicks(3140), new TimeSpan(0, 0, 0, 0, 0)), "Worker", "WorkerFirstName1", 0, true, "WorkerLastName1", "c:\\Worker", "WorkerMiddleName1", "Worker123456789", null, null, new DateTimeOffset(new DateTime(2019, 3, 3, 13, 33, 4, 586, DateTimeKind.Unspecified).AddTicks(3164), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 7, new DateTimeOffset(new DateTime(2018, 6, 16, 13, 33, 4, 586, DateTimeKind.Unspecified).AddTicks(4008), new TimeSpan(0, 0, 0, 0, 0)), "Worker", "WorkerFirstName2", 0, true, "WorkerLastName2", "c:\\Worker", "WorkerMiddleName2", "Worker234567891", null, null, new DateTimeOffset(new DateTime(2019, 3, 6, 13, 33, 4, 586, DateTimeKind.Unspecified).AddTicks(4012), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 8, new DateTimeOffset(new DateTime(2017, 4, 27, 13, 33, 4, 586, DateTimeKind.Unspecified).AddTicks(4019), new TimeSpan(0, 0, 0, 0, 0)), "Worker", "WorkerFirstName3", 0, true, "WorkerLastName3", "c:\\Worker", "WorkerMiddleName3", "Worker345678912", null, null, new DateTimeOffset(new DateTime(2019, 3, 5, 13, 33, 4, 586, DateTimeKind.Unspecified).AddTicks(4020), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 9, new DateTimeOffset(new DateTime(2016, 11, 18, 13, 33, 4, 586, DateTimeKind.Unspecified).AddTicks(4022), new TimeSpan(0, 0, 0, 0, 0)), "Worker", "WorkerFirstName4", 0, true, "WorkerLastName4", "c:\\Worker", "WorkerMiddleName4", "Worker456789123", null, null, new DateTimeOffset(new DateTime(2019, 2, 21, 13, 33, 4, 586, DateTimeKind.Unspecified).AddTicks(4023), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 10, new DateTimeOffset(new DateTime(2016, 7, 4, 13, 33, 4, 586, DateTimeKind.Unspecified).AddTicks(4025), new TimeSpan(0, 0, 0, 0, 0)), "Worker", "WorkerFirstName5", 0, true, "WorkerLastName5", "c:\\Worker", "WorkerMiddleName5", "Worker567891234", null, null, new DateTimeOffset(new DateTime(2019, 1, 2, 13, 33, 4, 586, DateTimeKind.Unspecified).AddTicks(4025), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "CourseAttendances",
                columns: new[] { "Id", "AttendenseDate", "CourseDate", "CourseEndDAte", "CourseId", "CustomerId", "Description", "Status" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2019, 3, 3, 13, 33, 4, 612, DateTimeKind.Unspecified).AddTicks(9815), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 17, 12, 33, 4, 613, DateTimeKind.Unspecified).AddTicks(322), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 18, 13, 33, 4, 613, DateTimeKind.Unspecified).AddTicks(767), new TimeSpan(0, 0, 0, 0, 0)), 1, 1, "testDescription", 4 },
                    { 2, new DateTimeOffset(new DateTime(2019, 3, 6, 13, 33, 4, 613, DateTimeKind.Unspecified).AddTicks(1977), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 17, 15, 33, 4, 613, DateTimeKind.Unspecified).AddTicks(1983), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 18, 13, 33, 4, 613, DateTimeKind.Unspecified).AddTicks(1987), new TimeSpan(0, 0, 0, 0, 0)), 2, 2, "testDescription", 4 },
                    { 3, new DateTimeOffset(new DateTime(2019, 3, 5, 13, 33, 4, 613, DateTimeKind.Unspecified).AddTicks(1997), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 18, 13, 33, 4, 613, DateTimeKind.Unspecified).AddTicks(1998), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 2, "testDescription", 3 },
                    { 4, new DateTimeOffset(new DateTime(2019, 3, 4, 13, 33, 4, 613, DateTimeKind.Unspecified).AddTicks(1999), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 18, 13, 33, 4, 613, DateTimeKind.Unspecified).AddTicks(2000), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, 2, "testDescription", 1 },
                    { 5, new DateTimeOffset(new DateTime(2019, 3, 2, 13, 33, 4, 613, DateTimeKind.Unspecified).AddTicks(2001), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 18, 13, 33, 4, 613, DateTimeKind.Unspecified).AddTicks(2001), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 3, "testDescription", 0 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAttendances_Courses_CourseId",
                table: "CourseAttendances",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAttendances_Customer_CustomerId",
                table: "CourseAttendances",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseAttendances_Courses_CourseId",
                table: "CourseAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseAttendances_Customer_CustomerId",
                table: "CourseAttendances");

            migrationBuilder.DeleteData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CourseAttendances",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CourseAttendances",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "CourseAttendances",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAttendances_Courses_CourseId",
                table: "CourseAttendances",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAttendances_Customer_CustomerId",
                table: "CourseAttendances",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
