using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebProject.Infrastructure.Migrations
{
    public partial class addbooflag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UserPicture",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "630d5dda-7255-4ce9-a658-0eedfb698a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01fc4a2f-a158-4dd0-8a03-df7408f1d073", "AQAAAAEAACcQAAAAEIxDmjcGMeTsWFP6+Q0ox/eg62fDZPKkgScG98xQ8YXjA/2K/wdtma3fISGrpxtcIA==", "ed978d2e-b513-463e-a600-0c16fd9e54e2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UserPicture");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "630d5dda-7255-4ce9-a658-0eedfb698a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23ab9726-a7a6-4280-ba01-6b9b3dcc438f", "AQAAAAEAACcQAAAAEAfFOEnS66Mhai+Gk3sOE07RrcECXjtgPMI2jetYcJm5IKA75BMMf8OydxjqbvS/fA==", "1dd1b9be-7afb-4b18-a7bc-fb8f9e573177" });
        }
    }
}
