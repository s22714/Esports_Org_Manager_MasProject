using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Esports_Org_Manager.Migrations
{
    /// <inheritdoc />
    public partial class noModelTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Organizations_organizationName",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesPlayTourneys_Employees_teamsid",
                table: "EmployeesPlayTourneys");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Organizations_organizationName",
                table: "Teams");

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
                table: "Teams",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tourneys",
                keyColumn: "id",
                keyValue: 1);

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
                table: "IndependentContractors",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "name",
                keyValue: "karmine corp");

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "name",
                keyValue: "moist esports");

            migrationBuilder.DropColumn(
                name: "SoloTourneyModel_placements",
                table: "Tourneys");

            migrationBuilder.DropColumn(
                name: "placements",
                table: "Tourneys");

            migrationBuilder.RenameColumn(
                name: "teamsid",
                table: "EmployeesPlayTourneys",
                newName: "employeesid");

            migrationBuilder.AddColumn<string>(
                name: "timeUntill",
                table: "Tourneys",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "organizationName",
                table: "Teams",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Teams",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "organizationName",
                table: "Employees",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Organizations_organizationName",
                table: "Employees",
                column: "organizationName",
                principalTable: "Organizations",
                principalColumn: "name");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesPlayTourneys_Employees_employeesid",
                table: "EmployeesPlayTourneys",
                column: "employeesid",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Organizations_organizationName",
                table: "Teams",
                column: "organizationName",
                principalTable: "Organizations",
                principalColumn: "name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Organizations_organizationName",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesPlayTourneys_Employees_employeesid",
                table: "EmployeesPlayTourneys");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Organizations_organizationName",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "timeUntill",
                table: "Tourneys");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "employeesid",
                table: "EmployeesPlayTourneys",
                newName: "teamsid");

            migrationBuilder.AddColumn<string>(
                name: "SoloTourneyModel_placements",
                table: "Tourneys",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "placements",
                table: "Tourneys",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "organizationName",
                table: "Teams",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "organizationName",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "IndependentContractors",
                columns: new[] { "id", "email", "name", "price" },
                values: new object[] { 1, "MVL@gmail.com", "MVL sp z.o.o", 23000.0 });

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

            migrationBuilder.InsertData(
                table: "Tourneys",
                columns: new[] { "id", "adress", "awardPool", "competitionType", "date", "format", "independentOrganizerId", "name", "organizerDiscriminator", "placements", "playerChangePointsPenalty", "procentPerPlace", "state", "streamLinks", "ticketPrice", "viewTypeDiscriminator" },
                values: new object[] { 1, "{\"cityName\":\"Kopenhagen\",\"streetName\":\"Sankt Gertruds\",\"number\":12}", 200000.0, "team", new DateTime(2024, 5, 26, 14, 25, 5, 1, DateTimeKind.Local).AddTicks(9713), "NFL", 1, "Summer champions", "Independent", "{}", 12, "[50,30,20]", "Finished", null, 120.0, "[\"Offlie\"]" });

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "id", "employeeId", "endDate", "startDate", "teamId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 3, new DateTime(2025, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Organizations_organizationName",
                table: "Employees",
                column: "organizationName",
                principalTable: "Organizations",
                principalColumn: "name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesPlayTourneys_Employees_teamsid",
                table: "EmployeesPlayTourneys",
                column: "teamsid",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Organizations_organizationName",
                table: "Teams",
                column: "organizationName",
                principalTable: "Organizations",
                principalColumn: "name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
