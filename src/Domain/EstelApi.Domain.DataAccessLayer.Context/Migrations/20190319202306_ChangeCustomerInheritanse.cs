using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstelApi.Domain.DataAccessLayer.Context.Migrations
{
    public partial class ChangeCustomerInheritanse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseAttendances_Courses_CourseId",
                table: "CourseAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseAttendances_Customer_CustomerId",
                table: "CourseAttendances");

            migrationBuilder.DropPrimaryKey(
                name: "CustomerId",
                table: "Customer");

            migrationBuilder.AlterColumn<int>(
                name: "StaffType",
                table: "Customer",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "WorkerId",
                table: "CourseAttendances",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "BirthDate", "Discriminator", "FirstName", "IdentityId", "IsEnabled", "LastName", "LogoPath", "MiddleName", "Telephone" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2018, 10, 20, 20, 23, 4, 884, DateTimeKind.Unspecified).AddTicks(5607), new TimeSpan(0, 0, 0, 0, 0)), "User", "FirstName1", 0, true, "LastName1", "c:\\", "MiddleName1", "123456789" },
                    { 2, new DateTimeOffset(new DateTime(2018, 6, 17, 20, 23, 4, 884, DateTimeKind.Unspecified).AddTicks(7527), new TimeSpan(0, 0, 0, 0, 0)), "User", "FirstName2", 0, true, "LastName2", "c:\\", "MiddleName2", "234567891" },
                    { 3, new DateTimeOffset(new DateTime(2017, 4, 28, 20, 23, 4, 884, DateTimeKind.Unspecified).AddTicks(7547), new TimeSpan(0, 0, 0, 0, 0)), "User", "FirstName3", 0, true, "LastName3", "c:\\", "MiddleName3", "345678912" },
                    { 4, new DateTimeOffset(new DateTime(2016, 11, 19, 20, 23, 4, 884, DateTimeKind.Unspecified).AddTicks(7550), new TimeSpan(0, 0, 0, 0, 0)), "User", "FirstName4", 0, true, "LastName4", "c:\\", "MiddleName4", "456789123" },
                    { 5, new DateTimeOffset(new DateTime(2016, 7, 5, 20, 23, 4, 884, DateTimeKind.Unspecified).AddTicks(7552), new TimeSpan(0, 0, 0, 0, 0)), "User", "FirstName5", 0, true, "LastName5", "c:\\", "MiddleName5", "567891234" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "BirthDate", "Discriminator", "FirstName", "IdentityId", "IsEnabled", "LastName", "LogoPath", "MiddleName", "Telephone", "RetirementDate", "StaffType", "WorkFrom" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2018, 10, 20, 20, 23, 4, 887, DateTimeKind.Unspecified).AddTicks(6649), new TimeSpan(0, 0, 0, 0, 0)), "Worker", "WorkerFirstName1", 0, true, "WorkerLastName1", "c:\\Worker", "WorkerMiddleName1", "Worker123456789", null, 0, new DateTimeOffset(new DateTime(2019, 3, 4, 20, 23, 4, 887, DateTimeKind.Unspecified).AddTicks(6660), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 7, new DateTimeOffset(new DateTime(2018, 6, 17, 20, 23, 4, 887, DateTimeKind.Unspecified).AddTicks(8014), new TimeSpan(0, 0, 0, 0, 0)), "Worker", "WorkerFirstName2", 0, true, "WorkerLastName2", "c:\\Worker", "WorkerMiddleName2", "Worker234567891", null, 3, new DateTimeOffset(new DateTime(2019, 3, 7, 20, 23, 4, 887, DateTimeKind.Unspecified).AddTicks(8018), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 8, new DateTimeOffset(new DateTime(2017, 4, 28, 20, 23, 4, 887, DateTimeKind.Unspecified).AddTicks(8029), new TimeSpan(0, 0, 0, 0, 0)), "Worker", "WorkerFirstName3", 0, true, "WorkerLastName3", "c:\\Worker", "WorkerMiddleName3", "Worker345678912", null, 1, new DateTimeOffset(new DateTime(2019, 3, 6, 20, 23, 4, 887, DateTimeKind.Unspecified).AddTicks(8030), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 9, new DateTimeOffset(new DateTime(2016, 11, 19, 20, 23, 4, 887, DateTimeKind.Unspecified).AddTicks(8033), new TimeSpan(0, 0, 0, 0, 0)), "Worker", "WorkerFirstName4", 0, true, "WorkerLastName4", "c:\\Worker", "WorkerMiddleName4", "Worker456789123", null, 2, new DateTimeOffset(new DateTime(2019, 2, 22, 20, 23, 4, 887, DateTimeKind.Unspecified).AddTicks(8034), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 10, new DateTimeOffset(new DateTime(2016, 7, 5, 20, 23, 4, 887, DateTimeKind.Unspecified).AddTicks(8036), new TimeSpan(0, 0, 0, 0, 0)), "Worker", "WorkerFirstName5", 0, true, "WorkerLastName5", "c:\\Worker", "WorkerMiddleName5", "Worker567891234", null, 0, new DateTimeOffset(new DateTime(2019, 1, 3, 20, 23, 4, 887, DateTimeKind.Unspecified).AddTicks(8037), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "CourseAttendances",
                columns: new[] { "Id", "AttendenseDate", "CourseDate", "CourseEndDAte", "CourseId", "CustomerId", "Description", "Status", "WorkerId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2019, 3, 4, 20, 23, 4, 938, DateTimeKind.Unspecified).AddTicks(4684), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 18, 19, 23, 4, 938, DateTimeKind.Unspecified).AddTicks(6372), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 19, 20, 23, 4, 938, DateTimeKind.Unspecified).AddTicks(7181), new TimeSpan(0, 0, 0, 0, 0)), 1, 1, "testDescription", 4, null },
                    { 2, new DateTimeOffset(new DateTime(2019, 3, 7, 20, 23, 4, 938, DateTimeKind.Unspecified).AddTicks(9217), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 18, 22, 23, 4, 938, DateTimeKind.Unspecified).AddTicks(9227), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 19, 20, 23, 4, 938, DateTimeKind.Unspecified).AddTicks(9233), new TimeSpan(0, 0, 0, 0, 0)), 2, 2, "testDescription", 4, null },
                    { 3, new DateTimeOffset(new DateTime(2019, 3, 6, 20, 23, 4, 938, DateTimeKind.Unspecified).AddTicks(9248), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 19, 20, 23, 4, 938, DateTimeKind.Unspecified).AddTicks(9250), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 2, "testDescription", 3, null },
                    { 4, new DateTimeOffset(new DateTime(2019, 3, 5, 20, 23, 4, 938, DateTimeKind.Unspecified).AddTicks(9251), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 19, 20, 23, 4, 938, DateTimeKind.Unspecified).AddTicks(9252), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, 2, "testDescription", 1, null },
                    { 5, new DateTimeOffset(new DateTime(2019, 3, 3, 20, 23, 4, 938, DateTimeKind.Unspecified).AddTicks(9254), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 3, 19, 20, 23, 4, 938, DateTimeKind.Unspecified).AddTicks(9255), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 3, "testDescription", 0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseAttendances_WorkerId",
                table: "CourseAttendances",
                column: "WorkerId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAttendances_Customer_WorkerId",
                table: "CourseAttendances",
                column: "WorkerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseAttendances_Courses_CourseId",
                table: "CourseAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseAttendances_Customer_CustomerId",
                table: "CourseAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseAttendances_Customer_WorkerId",
                table: "CourseAttendances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_CourseAttendances_WorkerId",
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

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "CourseAttendances");

            migrationBuilder.AlterColumn<string>(
                name: "StaffType",
                table: "Customer",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

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

            migrationBuilder.AddPrimaryKey(
                name: "CustomerId",
                table: "Customer",
                column: "Id");

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
