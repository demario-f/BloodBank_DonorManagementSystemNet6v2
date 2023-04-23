using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodBank_DonorManagementSystem.Web.Data.Migrations
{
    public partial class AddedDonorsDonationsBloodTypesBloodStocksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BloodType_BloodTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BloodType",
                table: "BloodType");

            migrationBuilder.RenameTable(
                name: "BloodType",
                newName: "BloodTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BloodTypes",
                table: "BloodTypes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BloodStocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodTypeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodStocks_BloodTypes_BloodTypeId",
                        column: x => x.BloodTypeId,
                        principalTable: "BloodTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodGroupNameId = table.Column<int>(type: "int", nullable: false),
                    LastDonationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donors_BloodTypes_BloodGroupNameId",
                        column: x => x.BloodGroupNameId,
                        principalTable: "BloodTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonorId = table.Column<int>(type: "int", nullable: false),
                    DonationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BloodTypeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donations_BloodTypes_BloodTypeId",
                        column: x => x.BloodTypeId,
                        principalTable: "BloodTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Donations_Donors_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Donors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodStocks_BloodTypeId",
                table: "BloodStocks",
                column: "BloodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_BloodTypeId",
                table: "Donations",
                column: "BloodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_DonorId",
                table: "Donations",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Donors_BloodGroupNameId",
                table: "Donors",
                column: "BloodGroupNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BloodTypes_BloodTypeId",
                table: "AspNetUsers",
                column: "BloodTypeId",
                principalTable: "BloodTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BloodTypes_BloodTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BloodStocks");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "Donors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BloodTypes",
                table: "BloodTypes");

            migrationBuilder.RenameTable(
                name: "BloodTypes",
                newName: "BloodType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BloodType",
                table: "BloodType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BloodType_BloodTypeId",
                table: "AspNetUsers",
                column: "BloodTypeId",
                principalTable: "BloodType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
