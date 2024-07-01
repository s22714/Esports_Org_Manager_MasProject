using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esports_Org_Manager.Migrations
{
    /// <inheritdoc />
    public partial class part : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "Teams",
                newName: "gamePlayed");

            migrationBuilder.AlterColumn<string>(
                name: "logo",
                table: "Teams",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "gamePlayed",
                table: "Teams",
                newName: "status");

            migrationBuilder.AlterColumn<string>(
                name: "logo",
                table: "Teams",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
