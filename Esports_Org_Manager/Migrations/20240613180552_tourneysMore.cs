using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esports_Org_Manager.Migrations
{
    /// <inheritdoc />
    public partial class tourneysMore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cityName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "number",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "streetName",
                table: "Employees",
                newName: "adress");

            migrationBuilder.AddColumn<int>(
                name: "independentOrganizerId",
                table: "Tourneys",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "IndependentContractors",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    price = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndependentContractors", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tourneys_independentOrganizerId",
                table: "Tourneys",
                column: "independentOrganizerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tourneys_IndependentContractors_independentOrganizerId",
                table: "Tourneys",
                column: "independentOrganizerId",
                principalTable: "IndependentContractors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tourneys_IndependentContractors_independentOrganizerId",
                table: "Tourneys");

            migrationBuilder.DropTable(
                name: "IndependentContractors");

            migrationBuilder.DropIndex(
                name: "IX_Tourneys_independentOrganizerId",
                table: "Tourneys");

            migrationBuilder.DropColumn(
                name: "independentOrganizerId",
                table: "Tourneys");

            migrationBuilder.RenameColumn(
                name: "adress",
                table: "Employees",
                newName: "streetName");

            migrationBuilder.AddColumn<string>(
                name: "cityName",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "number",
                table: "Employees",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
