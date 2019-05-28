using Microsoft.EntityFrameworkCore.Migrations;

namespace AGP2P.Data.Migrations
{
    public partial class AddBusinessProfileIdToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusinessProfileId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BusinessProfileId",
                table: "AspNetUsers",
                column: "BusinessProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BusinessProfiles_BusinessProfileId",
                table: "AspNetUsers",
                column: "BusinessProfileId",
                principalTable: "BusinessProfiles",
                principalColumn: "BusinessProfileId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BusinessProfiles_BusinessProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BusinessProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BusinessProfileId",
                table: "AspNetUsers");
        }
    }
}
