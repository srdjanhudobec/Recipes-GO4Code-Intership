import { Component, Input } from '@angular/core';
import { IngredientDTO } from 'src/models/IngredientDTO.model';
import { PostRecipe } from 'src/models/PostRecipe.model';
import { Recipe } from 'src/models/Recipe.model';
import { RecipeService } from 'src/services/recipe.service';

@Component({
  selector: 'app-create-recipe',
  templateUrl: './create-recipe.component.html',
  styleUrls: ['./create-recipe.component.css']
})
export class CreateRecipeComponent {
  name:string = "";
  ingredientName:string = "";
  quantity:number = 0;
  description: string = "";


  constructor(private recipeService:RecipeService){}
  createOnSubmit() {
    var recipe = new PostRecipe(this.name,[new IngredientDTO(this.quantity,this.ingredientName)],this.description);

    this.recipeService.createRecipe(recipe).subscribe({
      next: (data) => {
        console.log(data);
      }
    })
  }
}
