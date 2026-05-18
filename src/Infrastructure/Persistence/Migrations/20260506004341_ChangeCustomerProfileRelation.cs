using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace customer_profile_service.src.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCustomerProfileRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormAnswers_Customers_CustomerId",
                table: "FormAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_FormAnswers_QuestionForm_AnsweredFormId",
                table: "FormAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_FormAnswers_QuestionOptions_AnsweredQuestionOptionId",
                table: "FormAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_FormAnswers_Questions_AnsweredQuestionId",
                table: "FormAnswers");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_CustomerId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_FormAnswers_AnsweredFormId",
                table: "FormAnswers");

            migrationBuilder.DropIndex(
                name: "IX_FormAnswers_AnsweredQuestionId",
                table: "FormAnswers");

            migrationBuilder.DropIndex(
                name: "IX_FormAnswers_AnsweredQuestionOptionId",
                table: "FormAnswers");

            migrationBuilder.DropIndex(
                name: "IX_FormAnswers_CustomerId",
                table: "FormAnswers");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_CustomerId",
                table: "Profiles",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Profiles_CustomerId",
                table: "Profiles");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_CustomerId",
                table: "Profiles",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FormAnswers_AnsweredFormId",
                table: "FormAnswers",
                column: "AnsweredFormId");

            migrationBuilder.CreateIndex(
                name: "IX_FormAnswers_AnsweredQuestionId",
                table: "FormAnswers",
                column: "AnsweredQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_FormAnswers_AnsweredQuestionOptionId",
                table: "FormAnswers",
                column: "AnsweredQuestionOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_FormAnswers_CustomerId",
                table: "FormAnswers",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormAnswers_Customers_CustomerId",
                table: "FormAnswers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FormAnswers_QuestionForm_AnsweredFormId",
                table: "FormAnswers",
                column: "AnsweredFormId",
                principalTable: "QuestionForm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FormAnswers_QuestionOptions_AnsweredQuestionOptionId",
                table: "FormAnswers",
                column: "AnsweredQuestionOptionId",
                principalTable: "QuestionOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FormAnswers_Questions_AnsweredQuestionId",
                table: "FormAnswers",
                column: "AnsweredQuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
