import { HttpClient } from '@angular/common/http';
import { Injectable, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, map } from 'rxjs';
import { IngredientDTO } from 'src/models/IngredientDTO.model';
import { PostRecipe } from 'src/models/PostRecipe.model';
import { Recipe } from 'src/models/Recipe.model';
import { RecipeSearch } from 'src/models/RecipeSearch.model';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {

  rootUrl:string = 'http://localhost:5121/api/Recipe/';

  constructor(private http: HttpClient,public router:Router) { }

  getAllRecipes() {
    let recipesUrl = this.rootUrl + 'get-all-recipes';
    return this.http.get<Recipe[]>(recipesUrl);
  }

  createRecipe(recipe: PostRecipe) : Observable<PostRecipe> {
    var url = this.rootUrl + 'create-recipe';
    var body = recipe;

    return this.http.post<any>(url, body).pipe(
      map(response => {
        console.log(response);
        return new PostRecipe(response.name,response.ingredients,response.description);
      })
    )
  }

  deleteRecipe(recipe: string) : Observable<IngredientDTO> {
    var url = this.rootUrl + "delete-recipe?name=" + recipe;

    return this.http.delete<IngredientDTO>(url);
  }

  getSearchedRecipes(recipe:RecipeSearch){
    var url = "http://localhost:5121/api/Recipe/get-searched-recipes?name=" + recipe.name + "&ingredientname=" + recipe.ingredientSeach;
    return this.http.get<Recipe[]>(url);
  }
}
