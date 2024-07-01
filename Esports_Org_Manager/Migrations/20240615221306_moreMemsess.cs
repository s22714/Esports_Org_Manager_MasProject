using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esports_Org_Manager.Migrations
{
    /// <inheritdoc />
    public partial class moreMemsess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tourneys",
                keyColumn: "id",
                keyValue: 1,
                column: "date",
                value: new DateTime(2024, 5, 27, 0, 13, 5, 436, DateTimeKind.Local).AddTicks(9631));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tourneys",
                keyColumn: "id",
                keyValue: 1,
                column: "date",
                value: new DateTime(2024, 5, 27, 0, 11, 47, 263, DateTimeKind.Local).AddTicks(6211));
        }
    }
}
