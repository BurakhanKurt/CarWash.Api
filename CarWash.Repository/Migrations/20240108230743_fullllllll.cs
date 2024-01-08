using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarWash.Repository.Migrations
{
    /// <inheritdoc />
    public partial class fullllllll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WashProcesses_WashPackages_WashPackageId",
                table: "WashProcesses");

            migrationBuilder.AlterColumn<int>(
                name: "WashPackageId",
                table: "WashProcesses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "EmployeeWashProcesses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EmployeeWashProcesses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "EmployeeWashProcesses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 8, 23, 7, 42, 691, DateTimeKind.Utc).AddTicks(3425), new DateTime(2024, 1, 8, 23, 7, 42, 691, DateTimeKind.Utc).AddTicks(3434) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 8, 23, 7, 42, 691, DateTimeKind.Utc).AddTicks(3443), new DateTime(2024, 1, 8, 23, 7, 42, 691, DateTimeKind.Utc).AddTicks(3443) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 8, 23, 7, 42, 691, DateTimeKind.Utc).AddTicks(3444), new DateTime(2024, 1, 8, 23, 7, 42, 691, DateTimeKind.Utc).AddTicks(3445) });

            migrationBuilder.AddForeignKey(
                name: "FK_WashProcesses_WashPackages_WashPackageId",
                table: "WashProcesses",
                column: "WashPackageId",
                principalTable: "WashPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WashProcesses_WashPackages_WashPackageId",
                table: "WashProcesses");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "EmployeeWashProcesses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EmployeeWashProcesses");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "EmployeeWashProcesses");

            migrationBuilder.AlterColumn<int>(
                name: "WashPackageId",
                table: "WashProcesses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 8, 20, 30, 34, 440, DateTimeKind.Utc).AddTicks(5113), new DateTime(2024, 1, 8, 20, 30, 34, 440, DateTimeKind.Utc).AddTicks(5118) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 8, 20, 30, 34, 440, DateTimeKind.Utc).AddTicks(5133), new DateTime(2024, 1, 8, 20, 30, 34, 440, DateTimeKind.Utc).AddTicks(5134) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 8, 20, 30, 34, 440, DateTimeKind.Utc).AddTicks(5135), new DateTime(2024, 1, 8, 20, 30, 34, 440, DateTimeKind.Utc).AddTicks(5136) });

            migrationBuilder.AddForeignKey(
                name: "FK_WashProcesses_WashPackages_WashPackageId",
                table: "WashProcesses",
                column: "WashPackageId",
                principalTable: "WashPackages",
                principalColumn: "Id");
        }
    }
}
