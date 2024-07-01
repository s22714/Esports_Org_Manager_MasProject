using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esports_Org_Manager.Migrations
{
    /// <inheritdoc />
    public partial class tourneysPleaseeeee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tourneys",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    state = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    format = table.Column<string>(type: "TEXT", nullable: false),
                    awardPool = table.Column<double>(type: "REAL", nullable: false),
                    procentPerPlace = table.Column<string>(type: "TEXT", nullable: false),
                    streamLinks = table.Column<string>(type: "TEXT", nullable: true),
                    ticketPrice = table.Column<double>(type: "REAL", nullable: true),
                    adress = table.Column<string>(type: "TEXT", nullable: true),
                    viewTypeDiscriminator = table.Column<string>(type: "TEXT", nullable: false),
                    organizerDiscriminator = table.Column<string>(type: "TEXT", nullable: false),
                    competitionType = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    allowCoaching = table.Column<bool>(type: "INTEGER", nullable: true),
                    playerChangePointsPenalty = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tourneys", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tourneys");
        }
    }
}
