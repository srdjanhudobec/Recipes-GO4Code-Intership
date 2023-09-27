using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipes.Migrations
{
    /// <inheritdoc />
    public partial class BookMark2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Bookmarks_UserBookmarkUserUsername",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_UserBookmarkUserUsername",
                table: "Recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "UserBookmarkUserUsername",
                table: "Recipes");

            migrationBuilder.AlterColumn<string>(
                name: "UserUsername",
                table: "Bookmarks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Bookmarks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Bookmarks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RecipeName",
                table: "Bookmarks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_RecipeId",
                table: "Bookmarks",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Recipes_RecipeId",
                table: "Bookmarks",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Recipes_RecipeId",
                table: "Bookmarks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks");

            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_RecipeId",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "RecipeName",
                table: "Bookmarks");

            migrationBuilder.AddColumn<string>(
                name: "UserBookmarkUserUsername",
                table: "Recipes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserUsername",
                table: "Bookmarks",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks",
                column: "UserUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserBookmarkUserUsername",
                table: "Recipes",
                column: "UserBookmarkUserUsername");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Bookmarks_UserBookmarkUserUsername",
                table: "Recipes",
                column: "UserBookmarkUserUsername",
                principalTable: "Bookmarks",
                principalColumn: "UserUsername");
        }
    }
}
