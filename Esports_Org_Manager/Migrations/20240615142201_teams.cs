using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Esports_Org_Manager.Migrations
{
    /// <inheritdoc />
    public partial class teams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "name",
                keyValue: "karmine corp",
                column: "logo",
                value: "\\Logos\\karmine-corp-2021.png");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "name",
                keyValue: "moist esports",
                column: "logo",
                value: "\\Logos\\mst.jpg");

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "id", "creationDate", "gamePlayed", "logo", "minimalAgeEligibility", "minimalNumberOfPlayers", "name", "organizationName", "region", "status" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "rocket league", null, 16, 3, "mst rl", "moist esports", "NA", "available" },
                    { 2, new DateTime(2020, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "valorant", null, 16, 5, "mst valo", "moist esports", "NA", "available" },
                    { 3, new DateTime(2015, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "valorant", null, 16, 5, "kc rant", "karmine corp", "NA", "available" }
                });

            migrationBuilder.UpdateData(
                table: "Tourneys",
                keyColumn: "id",
                keyValue: 1,
                column: "date",
                value: new DateTime(2024, 5, 26, 16, 22, 0, 967, DateTimeKind.Local).AddTicks(4281));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "name",
                keyValue: "karmine corp",
                column: "logo",
                value: "\\Esports_Org_Manager\\Logos\\karmine-corp-2021.png");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "name",
                keyValue: "moist esports",
                column: "logo",
                value: "\\Esports_Org_Manager\\Logos\\mst.jpg");

            migrationBuilder.UpdateData(
                table: "Tourneys",
                keyColumn: "id",
                keyValue: 1,
                column: "date",
                value: new DateTime(2024, 5, 26, 16, 20, 11, 93, DateTimeKind.Local).AddTicks(958));
        }
    }
}
