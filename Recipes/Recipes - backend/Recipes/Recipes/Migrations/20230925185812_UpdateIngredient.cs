using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipes.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIngredient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientWithQuantity_Ingredients_IngredientId",
                table: "IngredientWithQuantity");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientWithQuantity_Recipes_RecipeId",
                table: "IngredientWithQuantity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientWithQuantity",
                table: "IngredientWithQuantity");

            migrationBuilder.RenameTable(
                name: "IngredientWithQuantity",
                newName: "IngredientWithQuantities");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientWithQuantity_RecipeId",
                table: "IngredientWithQuantities",
                newName: "IX_IngredientWithQuantities_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientWithQuantity_IngredientId",
                table: "IngredientWithQuantities",
                newName: "IX_IngredientWithQuantities_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientWithQuantities",
                table: "IngredientWithQuantities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientWithQuantities_Ingredients_IngredientId",
                table: "IngredientWithQuantities",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientWithQuantities_Recipes_RecipeId",
                table: "IngredientWithQuantities",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientWithQuantities_Ingredients_IngredientId",
                table: "IngredientWithQuantities");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientWithQuantities_Recipes_RecipeId",
                table: "IngredientWithQuantities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientWithQuantities",
                table: "IngredientWithQuantities");

            migrationBuilder.RenameTable(
                name: "IngredientWithQuantities",
                newName: "IngredientWithQuantity");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientWithQuantities_RecipeId",
                table: "IngredientWithQuantity",
                newName: "IX_IngredientWithQuantity_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientWithQuantities_IngredientId",
                table: "IngredientWithQuantity",
                newName: "IX_IngredientWithQuantity_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientWithQuantity",
                table: "IngredientWithQuantity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientWithQuantity_Ingredients_IngredientId",
                table: "IngredientWithQuantity",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientWithQuantity_Recipes_RecipeId",
                table: "IngredientWithQuantity",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
