using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebProject.Infrastructure.Migrations
{
    public partial class reset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_AspNetUsers_Username",
                table: "Pictures");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Pictures",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Pictures_Username",
                table: "Pictures",
                newName: "IX_Pictures_UsersId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "630d5dda-7255-4ce9-a658-0eedfb698a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62e0a152-d1e3-4769-acd8-ce9ae06672d8", "AQAAAAEAACcQAAAAEI1/dXPcVDlBUe5vCw7dEO6k4wWgROngC4HxZ5iDG3wowRekUZKPrRT2UEpo9LvSGg==", "cc317f7a-d459-44fe-90df-c0d54ef6bc4e" });

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_AspNetUsers_UsersId",
                table: "Pictures",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_AspNetUsers_UsersId",
                table: "Pictures");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "Pictures",
                newName: "Username");

            migrationBuilder.RenameIndex(
                name: "IX_Pictures_UsersId",
                table: "Pictures",
                newName: "IX_Pictures_Username");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "630d5dda-7255-4ce9-a658-0eedfb698a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7778fd30-580a-4ebc-9f89-e6e2e303b81f", "AQAAAAEAACcQAAAAEML6jYxyYyF3vuP7TvGSkyuBwFq8A0uheJBq0kZbs773ImgpAYJTgk28FaNtESxtPw==", "ef5ee395-1e26-4380-8c70-e11af4878e50" });

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_AspNetUsers_Username",
                table: "Pictures",
                column: "Username",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
