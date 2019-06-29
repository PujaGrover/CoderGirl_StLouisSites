using Microsoft.EntityFrameworkCore.Migrations;

namespace CoderGirl_StLouisSites.Data.Migrations
{
    public partial class AddValidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationRateAndReview_Locations_LocationId",
                table: "LocationRateAndReview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationRateAndReview",
                table: "LocationRateAndReview");

            migrationBuilder.RenameTable(
                name: "LocationRateAndReview",
                newName: "RateAndReviews");

            migrationBuilder.RenameIndex(
                name: "IX_LocationRateAndReview_LocationId",
                table: "RateAndReviews",
                newName: "IX_RateAndReviews_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RateAndReviews",
                table: "RateAndReviews",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RateAndReviews_Locations_LocationId",
                table: "RateAndReviews",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RateAndReviews_Locations_LocationId",
                table: "RateAndReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RateAndReviews",
                table: "RateAndReviews");

            migrationBuilder.RenameTable(
                name: "RateAndReviews",
                newName: "LocationRateAndReview");

            migrationBuilder.RenameIndex(
                name: "IX_RateAndReviews_LocationId",
                table: "LocationRateAndReview",
                newName: "IX_LocationRateAndReview_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationRateAndReview",
                table: "LocationRateAndReview",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationRateAndReview_Locations_LocationId",
                table: "LocationRateAndReview",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
