using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class AlienTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AlienTeam",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlienID = table.Column<int>(nullable: false),
                    TeamID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlienTeam", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AlienTeam_Alien_AlienID",
                        column: x => x.AlienID,
                        principalTable: "Alien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlienTeam_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlienTeam_AlienID",
                table: "AlienTeam",
                column: "AlienID");

            migrationBuilder.CreateIndex(
                name: "IX_AlienTeam_TeamID",
                table: "AlienTeam",
                column: "TeamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlienTeam");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
