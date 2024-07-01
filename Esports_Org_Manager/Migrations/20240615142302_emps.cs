using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Esports_Org_Manager.Migrations
{
    /// <inheritdoc />
    public partial class emps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "id", "adress", "channels", "email", "employeeTypeDiscriminator", "lastName", "name", "nick", "numberOfHoursStreamingPerWeek", "numberOfVideosPerWeek", "organizationName", "placementBonuses", "procentageOfWinnings", "status", "wage" },
                values: new object[,]
                {
                    { 1, "{\"cityName\":\"Paris\",\"streetName\":\"d'trance\",\"number\":23}", null, "jan.kajszczak@gmail.com", "Player", "Touret", "Axel", "Vatira", null, null, "karmine corp", null, 23, "available", 1200.0 },
                    { 2, "{\"cityName\":\"Lisbon\",\"streetName\":\"R. Luis Monteiro\",\"number\":4}", null, "jan.kajszczak@gmail.com", "Player", "Ferguson", "Finley", "Rise", null, null, "karmine corp", null, 25, "available", 1120.0 },
                    { 3, "{\"cityName\":\"Brussels\",\"streetName\":\"Rue Emile Steeno\",\"number\":12}", null, "jan.kajszczak@gmail.com", "Player", "Soyez", "Tristan", "Atow", null, null, "karmine corp", null, 25, "unavailable", 1120.0 }
                });

            migrationBuilder.UpdateData(
                table: "Tourneys",
                keyColumn: "id",
                keyValue: 1,
                column: "date",
                value: new DateTime(2024, 5, 26, 16, 23, 1, 925, DateTimeKind.Local).AddTicks(4241));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Tourneys",
                keyColumn: "id",
                keyValue: 1,
                column: "date",
                value: new DateTime(2024, 5, 26, 16, 22, 0, 967, DateTimeKind.Local).AddTicks(4281));
        }
    }
}
