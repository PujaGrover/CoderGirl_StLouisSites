using Microsoft.EntityFrameworkCore.Migrations;

namespace CoderGirl_StLouisSites.Data.Migrations
{
    public partial class AddLocationRateAndReview2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "LocationRateAndReview");

            migrationBuilder.CreateIndex(
                name: "IX_LocationRateAndReview_LocationId",
                table: "LocationRateAndReview",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationRateAndReview_Locations_LocationId",
                table: "LocationRateAndReview",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationRateAndReview_Locations_LocationId",
                table: "LocationRateAndReview");

            migrationBuilder.DropIndex(
                name: "IX_LocationRateAndReview_LocationId",
                table: "LocationRateAndReview");

            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "LocationRateAndReview",
                nullable: true);
        }
    }
}
