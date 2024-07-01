using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esports_Org_Manager.Migrations
{
    /// <inheritdoc />
    public partial class TeamsTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamModel_Organizations_organizationName",
                table: "TeamModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamModel",
                table: "TeamModel");

            migrationBuilder.RenameTable(
                name: "TeamModel",
                newName: "Teams");

            migrationBuilder.RenameIndex(
                name: "IX_TeamModel_organizationName",
                table: "Teams",
                newName: "IX_Teams_organizationName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Organizations_organizationName",
                table: "Teams",
                column: "organizationName",
                principalTable: "Organizations",
                principalColumn: "name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Organizations_organizationName",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "TeamModel");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_organizationName",
                table: "TeamModel",
                newName: "IX_TeamModel_organizationName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamModel",
                table: "TeamModel",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamModel_Organizations_organizationName",
                table: "TeamModel",
                column: "organizationName",
                principalTable: "Organizations",
                principalColumn: "name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
