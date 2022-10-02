using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthQues.Migrations
{
    public partial class PatientQuestionnaires : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ScorePoint",
                table: "QuestionAnswers",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "PatientQuestionnaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    QuestionnaireId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<double>(type: "float", nullable: false),
                    Recommendations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientQuestionnaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientQuestionnaires_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientQuestionnaires_Questionnaires_QuestionnaireId",
                        column: x => x.QuestionnaireId,
                        principalTable: "Questionnaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientQuestionnaires_PatientId",
                table: "PatientQuestionnaires",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientQuestionnaires_QuestionnaireId",
                table: "PatientQuestionnaires",
                column: "QuestionnaireId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientQuestionnaires");

            migrationBuilder.AlterColumn<decimal>(
                name: "ScorePoint",
                table: "QuestionAnswers",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
