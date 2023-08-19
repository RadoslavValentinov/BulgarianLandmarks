using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebProject.Infrastructure.Migrations
{
    public partial class userfuncpicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserPicture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlImgAddres = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPicture", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "630d5dda-7255-4ce9-a658-0eedfb698a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28842d48-edf6-416b-80e5-46d31d803d2b", "AQAAAAEAACcQAAAAEC2sDPeQh0c1NxQTf7YMuCD93n5T9qFpUWRyUQl1P41XUbTYkiopEopCKKAV8WlLaw==", "55220317-d7fd-4b3c-9d5f-38be725b6643" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPicture");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "630d5dda-7255-4ce9-a658-0eedfb698a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81b94450-22f7-40fc-95e9-07bd9314e654", "AQAAAAEAACcQAAAAEPmVY4jMN9x6bYM3SFYS4yGKglzjJTRUXOjM8MxRyxSvmjDo7ef0euK7AganPXeeog==", "41a7907e-ae96-4560-954c-e3cfec84cadf" });
        }
    }
}
