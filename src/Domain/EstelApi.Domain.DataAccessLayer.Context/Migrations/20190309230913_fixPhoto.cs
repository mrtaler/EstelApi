using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstelApi.Domain.DataAccessLayer.Context.Migrations
{
    public partial class fixPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Picture_PictureId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_PictureId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "Customers");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Picture_Id",
                table: "Customers",
                column: "Id",
                principalTable: "Picture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Picture_Id",
                table: "Customers");

            migrationBuilder.AddColumn<Guid>(
                name: "PictureId",
                table: "Customers",
                nullable: true);

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
    }
}
