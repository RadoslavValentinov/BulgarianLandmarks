using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebProject.Infrastructure.Migrations
{
    public partial class sets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "LandMarkId", "TownId", "UrlImgAddres" },
                values: new object[] { 9, null, 1, "https://maxmediabg.com/wp-content/uploads/2020/03/1chubi34-390x260.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "LandMarkId", "TownId", "UrlImgAddres" },
                values: new object[] { 1, null, 1, "https://maxmediabg.com/wp-content/uploads/2020/03/1chubi34-390x260.jpg" });
        }
    }
}
