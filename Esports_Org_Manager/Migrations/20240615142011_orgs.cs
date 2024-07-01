using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Esports_Org_Manager.Migrations
{
    /// <inheritdoc />
    public partial class orgs : Migration
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

            migrationBuilder.UpdateData(
                table: "Tourneys",
                keyColumn: "id",
                keyValue: 1,
                column: "date",
                value: new DateTime(2024, 5, 26, 16, 20, 11, 93, DateTimeKind.Local).AddTicks(958));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "name",
                keyValue: "karmine corp");

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "name",
                keyValue: "moist esports");

            migrationBuilder.UpdateData(
                table: "Tourneys",
                keyColumn: "id",
                keyValue: 1,
                column: "date",
                value: new DateTime(2024, 5, 26, 16, 12, 9, 385, DateTimeKind.Local).AddTicks(9074));
        }
    }
}
