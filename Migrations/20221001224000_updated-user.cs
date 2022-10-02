using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthQues.Migrations
{
    public partial class updateduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CreatedByID",
                table: "AspNetUsers",
                column: "CreatedByID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_CreatedByID",
                table: "AspNetUsers",
                column: "CreatedByID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_CreatedByID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CreatedByID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "AspNetUsers");
        }
    }
}
