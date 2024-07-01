using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Esports_Org_Manager.Migrations
{
    /// <inheritdoc />
    public partial class mems2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "id", "employeeId", "endDate", "startDate", "teamId" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, 3, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.UpdateData(
                table: "Tourneys",
                keyColumn: "id",
                keyValue: 1,
                column: "date",
                value: new DateTime(2024, 5, 26, 16, 31, 24, 423, DateTimeKind.Local).AddTicks(4174));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Tourneys",
                keyColumn: "id",
                keyValue: 1,
                column: "date",
                value: new DateTime(2024, 5, 26, 16, 29, 37, 734, DateTimeKind.Local).AddTicks(8966));
        }
    }
}
