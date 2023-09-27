import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { RecipeService } from 'src/services/recipe.service';

@Component({
  selector: 'app-delete-recipe',
  templateUrl: './delete-recipe.component.html',
  styleUrls: ['./delete-recipe.component.css']
})
export class DeleteRecipeComponent {
    deleteName:string = "";

   constructor(private recipeService:RecipeService,public router:Router){}

   deleteOnSubmit(){  
      this.recipeService.deleteRecipe(this.deleteName).subscribe({
        next: (data) => {
          console.log(data);
        }
      })
      this.router.navigateByUrl("/");
   }
}
