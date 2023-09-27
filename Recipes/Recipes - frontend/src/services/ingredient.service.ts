import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, map } from 'rxjs';
import { Ingredient } from 'src/models/Ingredient.model';
import { PostIngredient } from 'src/models/PostIngredient.model';

@Injectable({
  providedIn: 'root'
})
export class IngredientService {
  rootUrl: string = 'http://localhost:5121/api/Ingredient/';
   
  constructor(private http: HttpClient,public router:Router) { }

  getAllIngredients() {
    let recipesUrl = this.rootUrl + 'get-all-ingredients';
    return this.http.get<Ingredient[]>(recipesUrl);
  }

  createIngredient(recipe: PostIngredient) : Observable<PostIngredient> {
    var url = this.rootUrl + 'create-ingredient';
    var body = recipe;

    return this.http.post<PostIngredient>(url, body).pipe(
      map(response => {
        console.log(response);
        return new PostIngredient(response.name,response.measurementUnit);
      })
    )
  }

  deleteIngredient(recipe: string) : Observable<Ingredient> {
    var url = this.rootUrl + "delete-ingredient?name=" + recipe;

    return this.http.delete<Ingredient>(url);
  }
}
