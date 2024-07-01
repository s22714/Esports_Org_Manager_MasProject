using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esports_Org_Manager.Migrations
{
    /// <inheritdoc />
    public partial class seedMore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "IndependentContractors",
                columns: new[] { "id", "email", "name", "price" },
                values: new object[] { 1, "MVL@gmail.com", "MVL sp z.o.o", 23000.0 });

            migrationBuilder.InsertData(
                table: "Tourneys",
                columns: new[] { "id", "adress", "awardPool", "competitionType", "date", "format", "independentOrganizerId", "name", "organizerDiscriminator", "placements", "playerChangePointsPenalty", "procentPerPlace", "state", "streamLinks", "ticketPrice", "viewTypeDiscriminator" },
                values: new object[] { 1, "{\"cityName\":\"Kopenhagen\",\"streetName\":\"Sankt Gertruds\",\"number\":12}", 200000.0, "team", new DateTime(2024, 5, 26, 0, 55, 45, 624, DateTimeKind.Local).AddTicks(9651), "NFL", 1, "Summer champions", "Independent", "{}", 12, "[50,30,20]", "Finished", null, 120.0, "[\"Offlie\"]" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tourneys",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IndependentContractors",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
