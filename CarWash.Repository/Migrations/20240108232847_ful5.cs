using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarWash.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ful5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 8, 23, 28, 47, 577, DateTimeKind.Utc).AddTicks(2181), new DateTime(2024, 1, 8, 23, 28, 47, 577, DateTimeKind.Utc).AddTicks(2185) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 8, 23, 28, 47, 577, DateTimeKind.Utc).AddTicks(2193), new DateTime(2024, 1, 8, 23, 28, 47, 577, DateTimeKind.Utc).AddTicks(2194) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 8, 23, 28, 47, 577, DateTimeKind.Utc).AddTicks(2195), new DateTime(2024, 1, 8, 23, 28, 47, 577, DateTimeKind.Utc).AddTicks(2195) });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_VehicleId",
                table: "Appointments",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Vehicles_VehicleId",
                table: "Appointments",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Vehicles_VehicleId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_VehicleId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Appointments");

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
        }
    }
}
