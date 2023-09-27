import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { BookmarkRecipe } from 'src/models/BookmarkRecipe.model';
import { Recipe } from 'src/models/Recipe.model';
import { RecipeSearch } from 'src/models/RecipeSearch.model';
import { BMandCooksService } from 'src/services/bmand-cooks.service';
import { RecipeService } from 'src/services/recipe.service';

@Component({
  selector: 'app-recipe',
  templateUrl: './recipe.component.html',
  styleUrls: ['./recipe.component.css']
})
export class RecipeComponent {
  user:boolean = false;
  name:string = ""
  ingredientSearch:string = "";
  recipeName: string = "";
  recipes: Recipe [] = [];

  constructor(public recipeService:RecipeService,public bookmarkService:BMandCooksService){}

  ngOnInit(){
    this.recipeService.getAllRecipes().subscribe({
      next:(data:Recipe[])=> {
        data.forEach(element => {
          this.recipes.push(element);
        });
      }
    })
    var rola = localStorage.getItem('loggedInUser');
    if (rola !== null) {
      rola = JSON.parse(rola).roles;
    } else {
      
    }
    if(rola != null){
      if(rola[0] == "User"){
        this.user = true;
      }
    }
   
  }

  onBookmarkSubmit(){
    this.bookmarkService.bookmarkRecipe(new BookmarkRecipe(this.recipeName)).subscribe({
      next:()=>{}
    })
  }

  getBookmarkSubmit(){
    this.recipes = [];
    this.bookmarkService.getAllBookmarks().subscribe({
      next:(data:Recipe[])=> {
        data.forEach(element => {
          this.recipes.push(element);
        });
      }
    })
  }

  searchOnSubmit(){
    this.recipes = [];
    if(this.name == "" && this.ingredientSearch == ""){
      this.ngOnInit()
    }else{
    this.recipeService.getSearchedRecipes(new RecipeSearch(this.name,this.ingredientSearch)).subscribe({
      next:(data:Recipe[])=> {
        data.forEach(element => {
          this.recipes.push(element);
        });
      }
    })
  }}
}
