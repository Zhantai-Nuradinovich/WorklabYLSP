using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorBoilerplate.Storage.Migrations
{
    public partial class QuizItemMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirectionTitle = table.Column<string>(maxLength: 128, nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuizItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(nullable: false),
                    PicturePath = table.Column<string>(nullable: true),
                    Answers = table.Column<string>(nullable: false),
                    RightAnswer = table.Column<string>(nullable: false),
                    QuizId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizItems_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizItems_QuizId",
                table: "QuizItems",
                column: "QuizId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizItems");

            migrationBuilder.DropTable(
                name: "Quizzes");
        }
    }
}
