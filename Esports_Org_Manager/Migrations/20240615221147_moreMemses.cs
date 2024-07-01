using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Esports_Org_Manager.Migrations
{
    /// <inheritdoc />
    public partial class moreMemses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "id", "adress", "channels", "email", "employeeTypeDiscriminator", "lastName", "name", "nick", "numberOfHoursStreamingPerWeek", "numberOfVideosPerWeek", "organizationName", "placementBonuses", "procentageOfWinnings", "status", "wage" },
                values: new object[,]
                {
                    { 9, "{\"cityName\":\"Bruss\",\"streetName\":\"RuEmieSteeno\",\"number\":12}", "[\"youtube.com\"]", "jan.kajszczak@gmail.com", "ContentCreator", "Soy", "Adam", "Zen", 1, 3, "karmine corp", null, null, "available", 1120.0 },
                    { 10, "{\"cityName\":\"Brels\",\"streetName\":\"Reno\",\"number\":12}", "[\"youtube.com\"]", "jan.kajszczak@gmail.com", "ContentCreator", "oyez", "Ttan", "Flip", 4, 2, "karmine corp", null, null, "available", 1120.0 },
                    { 11, "{\"cityName\":\"sels\",\"streetName\":\"Re Steeno\",\"number\":12}", "[\"youtube.com\"]", "jan.kajszczak@gmail.com", "ContentCreator", "Sez", "opoon", "chaotic", 5, 2, "karmine corp", null, null, "unavailable", 1120.0 },
                    { 12, "{\"cityName\":\"Brusse\",\"streetName\":\"Rue Emino\",\"number\":12}", "[\"youtube.com\"]", "jan.kajszczak@gmail.com", "ContentCreator", "Soy", "Trst", "chaser", 3, 2, "karmine corp", null, null, "available", 1120.0 }
                });

            migrationBuilder.UpdateData(
                table: "Tourneys",
                keyColumn: "id",
                keyValue: 1,
                column: "date",
                value: new DateTime(2024, 5, 27, 0, 11, 47, 263, DateTimeKind.Local).AddTicks(6211));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "id", "employeeId", "endDate", "startDate", "teamId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
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
    }
}
