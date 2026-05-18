using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace customer_profile_service.src.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class IncludeCustomerIdInProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Profiles_ProfileId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionForm_QuestionFormId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ProfileId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Customers");

            migrationBuilder.AlterColumn<Guid>(
                name: "QuestionFormId",
                table: "Questions",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Profiles",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_CustomerId",
                table: "Profiles",
                column: "CustomerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Customers_CustomerId",
                table: "Profiles",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestionForm_QuestionFormId",
                table: "Questions",
                column: "QuestionFormId",
                principalTable: "QuestionForm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Customers_CustomerId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionForm_QuestionFormId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_CustomerId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Profiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "QuestionFormId",
                table: "Questions",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileId",
                table: "Customers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ProfileId",
                table: "Customers",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Profiles_ProfileId",
                table: "Customers",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestionForm_QuestionFormId",
                table: "Questions",
                column: "QuestionFormId",
                principalTable: "QuestionForm",
                principalColumn: "Id");
        }
    }
}
