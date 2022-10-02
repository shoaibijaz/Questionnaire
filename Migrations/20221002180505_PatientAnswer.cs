using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthQues.Migrations
{
    public partial class PatientAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientQuestionnaireId = table.Column<int>(type: "int", nullable: false),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientAnswers_PatientQuestionnaires_PatientQuestionnaireId",
                        column: x => x.PatientQuestionnaireId,
                        principalTable: "PatientQuestionnaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientAnswers_QuestionAnswers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "QuestionAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientAnswers_AnswerId",
                table: "PatientAnswers",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAnswers_PatientQuestionnaireId",
                table: "PatientAnswers",
                column: "PatientQuestionnaireId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientAnswers");
        }
    }
}
