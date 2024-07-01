using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Esports_Org_Manager.Migrations
{
    /// <inheritdoc />
    public partial class orrr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "teams",
                table: "Organizations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "name", "creationDate", "logo" },
                values: new object[,]
                {
                    { "karmine corp", new DateTime(2012, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "\\Logos\\karmine-corp-2021.png" },
                    { "moist esports", new DateTime(2018, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "\\Logos\\mst.jpg" }
                });
        }
    }
}
