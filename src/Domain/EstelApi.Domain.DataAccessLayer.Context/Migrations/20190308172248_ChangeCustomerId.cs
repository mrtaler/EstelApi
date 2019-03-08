using Microsoft.EntityFrameworkCore.Migrations;

namespace EstelApi.Domain.DataAccessLayer.Context.Migrations
{
    public partial class ChangeCustomerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "Id",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "CountryISOCode",
                table: "Countries",
                newName: "CountryIsoCode");

            migrationBuilder.AddPrimaryKey(
                name: "CustomerId",
                table: "Customers",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "CustomerId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "CountryIsoCode",
                table: "Countries",
                newName: "CountryISOCode");

            migrationBuilder.AddPrimaryKey(
                name: "Id",
                table: "Customers",
                column: "Id");
        }
    }
}
