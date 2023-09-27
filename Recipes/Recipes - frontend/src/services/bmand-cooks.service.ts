import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, map } from 'rxjs';
import { BookmarkRecipe } from 'src/models/BookmarkRecipe.model';
import { Cook } from 'src/models/Cook.model';
import { Recipe } from 'src/models/Recipe.model';

@Injectable({
  providedIn: 'root'
})
export class BMandCooksService {
  rootUrl:string = 'http://localhost:5121/api/User/'

  constructor(private http: HttpClient,public router:Router) { }
  getAllRecipes() {
    let cooksUrl = this.rootUrl + 'get-all-cooks';
    return this.http.get<Cook[]>(cooksUrl);
  }

  bookmarkRecipe(recipe: BookmarkRecipe) : Observable<Recipe> {
    var url = this.rootUrl + 'bookmark-recipe';
    var body = recipe;

    return this.http.post<Recipe>(url, body).pipe(
      map(response => {
        console.log(response);
        return response;
      })
    )
  }

  getAllBookmarks(){
    let bookmarkUrl = this.rootUrl + "get-bookmarked-recipes"
    return this.http.get<Recipe[]>(bookmarkUrl)
  }
}
