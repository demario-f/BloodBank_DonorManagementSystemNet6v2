using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodBank_DonorManagementSystem.Web.Data.Migrations
{
    public partial class AddedDefaultUserAndRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aa382f62-0a46-4de6-bef5-539fd28c82d0", "4f8dc366-0e2d-4073-9055-77277dcb03ac", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aa745f62-0a46-4de6-bef5-539bb28c83d0", "5fec57a3-7d85-4234-9556-3d1ea7db799c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastDonationDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "aa382e62-0a64-4de6-bef5-539fc21c89d0", 0, "8cb57d99-d7bc-4a2a-aeab-4cdd7d1a0eb0", "admin@test.com", false, "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test", false, null, "ADMIN@TEST.COM", null, "AQAAAAEAACcQAAAAENvJ51KiJ8BL3bH9PF2GD2fonw6BZJdtsoAch7WuhX+6h7s1zFv/YhMXzSe5Ap6iKA==", null, false, "4c031a1d-88ae-4169-872d-1d59e3f8aa9d", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "aa382f62-0a46-4de6-bef5-539fd28c82d0", "aa382e62-0a64-4de6-bef5-539fc21c89d0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa745f62-0a46-4de6-bef5-539bb28c83d0");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "aa382f62-0a46-4de6-bef5-539fd28c82d0", "aa382e62-0a64-4de6-bef5-539fc21c89d0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa382f62-0a46-4de6-bef5-539fd28c82d0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa382e62-0a64-4de6-bef5-539fc21c89d0");

            migrationBuilder.AddColumn<int>(
                name: "BloodTypeId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            
        }
    }
}
