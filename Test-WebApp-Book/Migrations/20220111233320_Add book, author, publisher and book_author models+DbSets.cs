using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_WebApp_Book.Migrations
{
    public partial class Addbookauthorpublisherandbook_authormodelsDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_Authors_AuthorId",
                table: "Book_Author");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_Books_BookId",
                table: "Book_Author");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book_Author",
                table: "Book_Author");

            migrationBuilder.RenameTable(
                name: "Book_Author",
                newName: "Books_Authors");

            migrationBuilder.RenameIndex(
                name: "IX_Book_Author_BookId",
                table: "Books_Authors",
                newName: "IX_Books_Authors_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_Author_AuthorId",
                table: "Books_Authors",
                newName: "IX_Books_Authors_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books_Authors",
                table: "Books_Authors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_Authors_AuthorId",
                table: "Books_Authors",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_Books_BookId",
                table: "Books_Authors",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_Authors_AuthorId",
                table: "Books_Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_Books_BookId",
                table: "Books_Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books_Authors",
                table: "Books_Authors");

            migrationBuilder.RenameTable(
                name: "Books_Authors",
                newName: "Book_Author");

            migrationBuilder.RenameIndex(
                name: "IX_Books_Authors_BookId",
                table: "Book_Author",
                newName: "IX_Book_Author_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_Authors_AuthorId",
                table: "Book_Author",
                newName: "IX_Book_Author_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book_Author",
                table: "Book_Author",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_Authors_AuthorId",
                table: "Book_Author",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_Books_BookId",
                table: "Book_Author",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
