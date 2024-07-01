using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esports_Org_Manager.Migrations
{
    /// <inheritdoc />
    public partial class castersOrganizers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeTourneysCasters",
                columns: table => new
                {
                    castersid = table.Column<int>(type: "INTEGER", nullable: false),
                    tourneyCastsid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTourneysCasters", x => new { x.castersid, x.tourneyCastsid });
                    table.ForeignKey(
                        name: "FK_EmployeeTourneysCasters_Employees_castersid",
                        column: x => x.castersid,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTourneysCasters_Tourneys_tourneyCastsid",
                        column: x => x.tourneyCastsid,
                        principalTable: "Tourneys",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTourneysOrganised",
                columns: table => new
                {
                    ownOrganizersid = table.Column<int>(type: "INTEGER", nullable: false),
                    tourneyParticipationsid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTourneysOrganised", x => new { x.ownOrganizersid, x.tourneyParticipationsid });
                    table.ForeignKey(
                        name: "FK_EmployeeTourneysOrganised_Employees_ownOrganizersid",
                        column: x => x.ownOrganizersid,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTourneysOrganised_Tourneys_tourneyParticipationsid",
                        column: x => x.tourneyParticipationsid,
                        principalTable: "Tourneys",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTourneysCasters_tourneyCastsid",
                table: "EmployeeTourneysCasters",
                column: "tourneyCastsid");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTourneysOrganised_tourneyParticipationsid",
                table: "EmployeeTourneysOrganised",
                column: "tourneyParticipationsid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTourneysCasters");

            migrationBuilder.DropTable(
                name: "EmployeeTourneysOrganised");
        }
    }
}
