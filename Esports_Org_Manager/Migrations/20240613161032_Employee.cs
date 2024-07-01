using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esports_Org_Manager.Migrations
{
    /// <inheritdoc />
    public partial class Employee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "employeeId",
                table: "Memberships",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    lastName = table.Column<string>(type: "TEXT", nullable: false),
                    nick = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    cityName = table.Column<string>(type: "TEXT", nullable: false),
                    streetName = table.Column<string>(type: "TEXT", nullable: false),
                    number = table.Column<int>(type: "INTEGER", nullable: false),
                    wage = table.Column<double>(type: "REAL", nullable: false),
                    status = table.Column<string>(type: "TEXT", nullable: false),
                    employeeTypeDiscriminator = table.Column<string>(type: "TEXT", nullable: false),
                    channels = table.Column<string>(type: "TEXT", nullable: true),
                    numberOfVideosPerWeek = table.Column<int>(type: "INTEGER", nullable: true),
                    numberOfHoursStreamingPerWeek = table.Column<int>(type: "INTEGER", nullable: true),
                    placementBonuses = table.Column<string>(type: "TEXT", nullable: true),
                    procentageOfWinnings = table.Column<int>(type: "INTEGER", nullable: true),
                    organizationName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                    table.ForeignKey(
                        name: "FK_Employees_Organizations_organizationName",
                        column: x => x.organizationName,
                        principalTable: "Organizations",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_employeeId",
                table: "Memberships",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_organizationName",
                table: "Employees",
                column: "organizationName");

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Employees_employeeId",
                table: "Memberships",
                column: "employeeId",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Employees_employeeId",
                table: "Memberships");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Memberships_employeeId",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "employeeId",
                table: "Memberships");
        }
    }
}
