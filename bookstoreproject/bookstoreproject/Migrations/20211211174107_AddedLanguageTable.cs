using Microsoft.EntityFrameworkCore.Migrations;

namespace bookstoreproject.Migrations
{
    public partial class AddedLanguageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "books");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_languages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_LanguageId",
                table: "books",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_languages_LanguageId",
                table: "books",
                column: "LanguageId",
                principalTable: "languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_languages_LanguageId",
                table: "books");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropIndex(
                name: "IX_books_LanguageId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "books");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "books",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
