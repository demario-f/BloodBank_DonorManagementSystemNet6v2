using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodBank_DonorManagementSystem.Web.Data.Migrations
{
    public partial class AddedDefaultUserAndUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa382f62-0a46-4de6-bef5-539fd28c82d0",
                column: "ConcurrencyStamp",
                value: "3392f6ba-efc3-46f3-bae8-c03574c8d49c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa745f62-0a46-4de6-bef5-539bb28c83d0",
                column: "ConcurrencyStamp",
                value: "3a7e1a88-571a-43b7-ab60-c0a7e96e8d68");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa382e62-0a64-4de6-bef5-539fc21c89d0",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "6faaed54-dbaf-4a02-8a84-002cc9610690", true, "ADMIN@TEST.COM", "AQAAAAEAACcQAAAAEMpDDp0Bdix/OlQkju5fxwkFbtqZCWhusEB3HWlzI2KikX+P56KUc0nEn//jtCgfCw==", "01adcfb2-b5b2-4041-92cf-a1b4707cffad", "admin@test.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa382f62-0a46-4de6-bef5-539fd28c82d0",
                column: "ConcurrencyStamp",
                value: "4f8dc366-0e2d-4073-9055-77277dcb03ac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa745f62-0a46-4de6-bef5-539bb28c83d0",
                column: "ConcurrencyStamp",
                value: "5fec57a3-7d85-4234-9556-3d1ea7db799c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa382e62-0a64-4de6-bef5-539fc21c89d0",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "8cb57d99-d7bc-4a2a-aeab-4cdd7d1a0eb0", false, null, "AQAAAAEAACcQAAAAENvJ51KiJ8BL3bH9PF2GD2fonw6BZJdtsoAch7WuhX+6h7s1zFv/YhMXzSe5Ap6iKA==", "4c031a1d-88ae-4169-872d-1d59e3f8aa9d", null });
        }
    }
}
