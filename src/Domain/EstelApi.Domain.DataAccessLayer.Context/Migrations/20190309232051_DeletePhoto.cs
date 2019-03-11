using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstelApi.Domain.DataAccessLayer.Context.Migrations
{
    public partial class DeletePhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Picture_Id",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Picture");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RawPhoto = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Picture_Id",
                table: "Customers",
                column: "Id",
                principalTable: "Picture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
