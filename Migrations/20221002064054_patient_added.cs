using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthQues.Migrations
{
    public partial class patient_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_CreatedByID",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CreatedByID",
                table: "AspNetUsers",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_CreatedByID",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_CreatedById");

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhysicianId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_AspNetUsers_PhysicianId",
                        column: x => x.PhysicianId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_CreatedById",
                table: "Patients",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PatientId",
                table: "Patients",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PhysicianId",
                table: "Patients",
                column: "PhysicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_CreatedById",
                table: "AspNetUsers",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_CreatedById",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "AspNetUsers",
                newName: "CreatedByID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_CreatedById",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_CreatedByID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_CreatedByID",
                table: "AspNetUsers",
                column: "CreatedByID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
