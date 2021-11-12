using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC2.Migrations
{
    public partial class PersonLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguage_Languages_LanguageId",
                table: "PersonLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguage_People_PersonId",
                table: "PersonLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonLanguage",
                table: "PersonLanguage");

            migrationBuilder.RenameTable(
                name: "PersonLanguage",
                newName: "PersonLanguages");

            migrationBuilder.RenameIndex(
                name: "IX_PersonLanguage_LanguageId",
                table: "PersonLanguages",
                newName: "IX_PersonLanguages_LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonLanguages",
                table: "PersonLanguages",
                columns: new[] { "PersonId", "LanguageId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguages_Languages_LanguageId",
                table: "PersonLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguages_People_PersonId",
                table: "PersonLanguages",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguages_Languages_LanguageId",
                table: "PersonLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguages_People_PersonId",
                table: "PersonLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonLanguages",
                table: "PersonLanguages");

            migrationBuilder.RenameTable(
                name: "PersonLanguages",
                newName: "PersonLanguage");

            migrationBuilder.RenameIndex(
                name: "IX_PersonLanguages_LanguageId",
                table: "PersonLanguage",
                newName: "IX_PersonLanguage_LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonLanguage",
                table: "PersonLanguage",
                columns: new[] { "PersonId", "LanguageId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguage_Languages_LanguageId",
                table: "PersonLanguage",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguage_People_PersonId",
                table: "PersonLanguage",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
