using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class PlanetMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlanetID",
                table: "Alien",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Planet",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanetName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planet", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alien_PlanetID",
                table: "Alien",
                column: "PlanetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Alien_Planet_PlanetID",
                table: "Alien",
                column: "PlanetID",
                principalTable: "Planet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alien_Planet_PlanetID",
                table: "Alien");

            migrationBuilder.DropTable(
                name: "Planet");

            migrationBuilder.DropIndex(
                name: "IX_Alien_PlanetID",
                table: "Alien");

            migrationBuilder.DropColumn(
                name: "PlanetID",
                table: "Alien");
        }
    }
}
