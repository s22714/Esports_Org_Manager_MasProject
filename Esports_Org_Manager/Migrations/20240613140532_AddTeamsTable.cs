using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esports_Org_Manager.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamModel",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    creationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    logo = table.Column<string>(type: "TEXT", nullable: false),
                    minimalAgeEligibility = table.Column<int>(type: "INTEGER", nullable: false),
                    minimalNumberOfPlayers = table.Column<int>(type: "INTEGER", nullable: false),
                    region = table.Column<string>(type: "TEXT", nullable: false),
                    status = table.Column<string>(type: "TEXT", nullable: false),
                    organizationName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamModel", x => x.id);
                    table.ForeignKey(
                        name: "FK_TeamModel_Organizations_organizationName",
                        column: x => x.organizationName,
                        principalTable: "Organizations",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamModel_organizationName",
                table: "TeamModel",
                column: "organizationName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamModel");
        }
    }
}
