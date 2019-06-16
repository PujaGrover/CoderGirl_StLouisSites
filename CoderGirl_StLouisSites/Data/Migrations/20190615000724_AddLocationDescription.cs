using Microsoft.EntityFrameworkCore.Migrations;

namespace CoderGirl_StLouisSites.Data.Migrations
{
    public partial class AddLocationDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Locations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Locations");
        }
    }
}
