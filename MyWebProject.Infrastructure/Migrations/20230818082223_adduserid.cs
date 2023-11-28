using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebProject.Infrastructure.Migrations
{
    public partial class adduserid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserPicture",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "630d5dda-7255-4ce9-a658-0eedfb698a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23ab9726-a7a6-4280-ba01-6b9b3dcc438f", "AQAAAAEAACcQAAAAEAfFOEnS66Mhai+Gk3sOE07RrcECXjtgPMI2jetYcJm5IKA75BMMf8OydxjqbvS/fA==", "1dd1b9be-7afb-4b18-a7bc-fb8f9e573177" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserPicture");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "630d5dda-7255-4ce9-a658-0eedfb698a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28842d48-edf6-416b-80e5-46d31d803d2b", "AQAAAAEAACcQAAAAEC2sDPeQh0c1NxQTf7YMuCD93n5T9qFpUWRyUQl1P41XUbTYkiopEopCKKAV8WlLaw==", "55220317-d7fd-4b3c-9d5f-38be725b6643" });
        }
    }
}
