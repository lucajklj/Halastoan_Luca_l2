using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Halastoan_Luca_l2.Migrations
{
    /// <inheritdoc />
    public partial class FinalAuthorSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_Publisher_PublisherID",
                table: "book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_book",
                table: "book");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "book");

            migrationBuilder.RenameTable(
                name: "book",
                newName: "Book");

            migrationBuilder.RenameIndex(
                name: "IX_book_PublisherID",
                table: "Book",
                newName: "IX_Book_PublisherID");

            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorID",
                table: "Book",
                column: "AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorID",
                table: "Book",
                column: "AuthorID",
                principalTable: "Author",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Publisher_PublisherID",
                table: "Book",
                column: "PublisherID",
                principalTable: "Publisher",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorID",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Publisher_PublisherID",
                table: "Book");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_AuthorID",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "book");

            migrationBuilder.RenameIndex(
                name: "IX_Book_PublisherID",
                table: "book",
                newName: "IX_book_PublisherID");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_book",
                table: "book",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_book_Publisher_PublisherID",
                table: "book",
                column: "PublisherID",
                principalTable: "Publisher",
                principalColumn: "ID");
        }
    }
}
