using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipes.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientWithQuantity",
                table: "IngredientWithQuantity");

            migrationBuilder.AlterColumn<string>(
                name: "IngredientName",
                table: "IngredientWithQuantity",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "IngredientWithQuantity",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientWithQuantity",
                table: "IngredientWithQuantity",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientWithQuantity",
                table: "IngredientWithQuantity");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "IngredientWithQuantity");

            migrationBuilder.AlterColumn<string>(
                name: "IngredientName",
                table: "IngredientWithQuantity",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientWithQuantity",
                table: "IngredientWithQuantity",
                column: "IngredientName");
        }
    }
}
