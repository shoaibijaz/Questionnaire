using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthQues.Migrations
{
    public partial class add_questionnaires : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AspNetUsers_PatientId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AspNetUsers_PhysicianId",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "PhysicianId",
                table: "Patients",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "Patients",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Questionnaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionnaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questionnaires_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questionnaires_CreatedById",
                table: "Questionnaires",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_AspNetUsers_PatientId",
                table: "Patients",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_AspNetUsers_PhysicianId",
                table: "Patients",
                column: "PhysicianId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AspNetUsers_PatientId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AspNetUsers_PhysicianId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "Questionnaires");

            migrationBuilder.AlterColumn<string>(
                name: "PhysicianId",
                table: "Patients",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "Patients",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_AspNetUsers_PatientId",
                table: "Patients",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_AspNetUsers_PhysicianId",
                table: "Patients",
                column: "PhysicianId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
