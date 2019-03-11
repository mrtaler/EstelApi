using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstelApi.Domain.DataAccessLayer.Context.Migrations
{
    public partial class revertPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PictureId",
                table: "Customers",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PictureId",
                table: "Customers",
                column: "PictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Picture_PictureId",
                table: "Customers",
                column: "PictureId",
                principalTable: "Picture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Picture_PictureId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropIndex(
                name: "IX_Customers_PictureId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "Customers");
        }
    }
}
