using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebProject.Infrastructure.Migrations
{
    public partial class addpictureproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "630d5dda-7255-4ce9-a658-0eedfb698a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e47eccf-297f-4141-ac4d-6c4de2bfdb04", "AQAAAAEAACcQAAAAEEnqlndkYmT7zSkJCQK/LoDN3TjO6Po5KCQJPiN8ciFF+w6PZoVSFzY3yxpW1qbxXw==", "330e4d03-4a56-4a6f-b139-4264b1b11bda" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Pictures");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "630d5dda-7255-4ce9-a658-0eedfb698a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62e0a152-d1e3-4769-acd8-ce9ae06672d8", "AQAAAAEAACcQAAAAEI1/dXPcVDlBUe5vCw7dEO6k4wWgROngC4HxZ5iDG3wowRekUZKPrRT2UEpo9LvSGg==", "cc317f7a-d459-44fe-90df-c0d54ef6bc4e" });
        }
    }
}
