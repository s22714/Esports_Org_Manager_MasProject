using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esports_Org_Manager.Migrations
{
    /// <inheritdoc />
    public partial class playsTourneys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "EmployeesPlayTourneys",
                columns: table => new
                {
                    teamsid = table.Column<int>(type: "INTEGER", nullable: false),
                    tourneysPlayedid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesPlayTourneys", x => new { x.teamsid, x.tourneysPlayedid });
                    table.ForeignKey(
                        name: "FK_EmployeesPlayTourneys_Employees_teamsid",
                        column: x => x.teamsid,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeesPlayTourneys_Tourneys_tourneysPlayedid",
                        column: x => x.tourneysPlayedid,
                        principalTable: "Tourneys",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamsPlayTourneys",
                columns: table => new
                {
                    teamsid = table.Column<int>(type: "INTEGER", nullable: false),
                    tourneysid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsPlayTourneys", x => new { x.teamsid, x.tourneysid });
                    table.ForeignKey(
                        name: "FK_TeamsPlayTourneys_Teams_teamsid",
                        column: x => x.teamsid,
                        principalTable: "Teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamsPlayTourneys_Tourneys_tourneysid",
                        column: x => x.tourneysid,
                        principalTable: "Tourneys",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesPlayTourneys_tourneysPlayedid",
                table: "EmployeesPlayTourneys",
                column: "tourneysPlayedid");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsPlayTourneys_tourneysid",
                table: "TeamsPlayTourneys",
                column: "tourneysid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesPlayTourneys");

            migrationBuilder.DropTable(
                name: "TeamsPlayTourneys");

            migrationBuilder.DropColumn(
                name: "SoloTourneyModel_placements",
                table: "Tourneys");

            migrationBuilder.DropColumn(
                name: "placements",
                table: "Tourneys");
        }
    }
}
