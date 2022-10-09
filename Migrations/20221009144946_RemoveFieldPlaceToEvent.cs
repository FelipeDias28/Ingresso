using Microsoft.EntityFrameworkCore.Migrations;

namespace Ingresso.Migrations
{
    public partial class RemoveFieldPlaceToEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Place",
                table: "Events");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "Events",
                type: "TEXT",
                nullable: true);
        }
    }
}
