using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Esports_Org_Manager.Migrations
{
    /// <inheritdoc />
    public partial class placements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SoloTourney_placements",
                table: "Tourneys",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "placements",
                table: "Tourneys",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "id", "employeeId", "endDate", "startDate", "teamId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 2, 2, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, 3, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, 9, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, 10, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 11, 11, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, 12, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.UpdateData(
                table: "Tourneys",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "date", "placements" },
                values: new object[] { new DateTime(2024, 5, 27, 0, 25, 23, 721, DateTimeKind.Local).AddTicks(3677), "{}" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "SoloTourney_placements",
                table: "Tourneys");

            migrationBuilder.DropColumn(
                name: "placements",
                table: "Tourneys");

            migrationBuilder.UpdateData(
                table: "Tourneys",
                keyColumn: "id",
                keyValue: 1,
                column: "date",
                value: new DateTime(2024, 5, 27, 0, 13, 5, 436, DateTimeKind.Local).AddTicks(9631));
        }
    }
}
