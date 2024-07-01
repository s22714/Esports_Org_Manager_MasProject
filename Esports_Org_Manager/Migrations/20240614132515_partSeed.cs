using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Esports_Org_Manager.Migrations
{
    /// <inheritdoc />
    public partial class partSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "name", "creationDate", "logo" },
                values: new object[,]
                {
                    { "karmine corp", new DateTime(2012, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "\\Esports_Org_Manager\\Logos\\karmine-corp-2021.png" },
                    { "moist esports", new DateTime(2018, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "\\Esports_Org_Manager\\Logos\\mst.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "id", "adress", "channels", "email", "employeeTypeDiscriminator", "lastName", "name", "nick", "numberOfHoursStreamingPerWeek", "numberOfVideosPerWeek", "organizationName", "placementBonuses", "procentageOfWinnings", "status", "wage" },
                values: new object[,]
                {
                    { 1, "{\"cityName\":\"Paris\",\"streetName\":\"d'trance\",\"number\":23}", null, "jan.kajszczak@gmail.com", "Player", "Touret", "Axel", "Vatira", null, null, "karmine corp", null, 23, "available", 1200.0 },
                    { 2, "{\"cityName\":\"Lisbon\",\"streetName\":\"R. Luis Monteiro\",\"number\":4}", null, "jan.kajszczak@gmail.com", "Player", "Ferguson", "Finley", "Rise", null, null, "karmine corp", null, 25, "available", 1120.0 },
                    { 3, "{\"cityName\":\"Brussels\",\"streetName\":\"Rue Emile Steeno\",\"number\":12}", null, "jan.kajszczak@gmail.com", "Player", "Soyez", "Tristan", "Atow", null, null, "karmine corp", null, 25, "unavailable", 1120.0 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "id", "creationDate", "gamePlayed", "logo", "minimalAgeEligibility", "minimalNumberOfPlayers", "name", "organizationName", "region" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "rocket league", null, 16, 3, "mst rl", "moist esports", "NA" },
                    { 2, new DateTime(2020, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "valorant", null, 16, 5, "mst valo", "moist esports", "NA" },
                    { 3, new DateTime(2015, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "valorant", null, 16, 5, "kc rant", "moist esports", "NA" }
                });
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

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "name",
                keyValue: "karmine corp");

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "name",
                keyValue: "moist esports");
        }
    }
}
