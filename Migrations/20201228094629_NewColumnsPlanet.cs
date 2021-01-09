using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class NewColumnsPlanet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NrOfSatellites",
                table: "Planet",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PlanetArea",
                table: "Planet",
                type: "decimal(6, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NrOfSatellites",
                table: "Planet");

            migrationBuilder.DropColumn(
                name: "PlanetArea",
                table: "Planet");
        }
    }
}
