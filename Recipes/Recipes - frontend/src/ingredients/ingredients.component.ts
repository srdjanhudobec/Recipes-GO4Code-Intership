import { Component } from '@angular/core';
import { Ingredient } from 'src/models/Ingredient.model';
import { IngredientService } from 'src/services/ingredient.service';

@Component({
  selector: 'app-ingredients',
  templateUrl: './ingredients.component.html',
  styleUrls: ['./ingredients.component.css']
})
export class IngredientsComponent {
  ingredients: Ingredient [] = [];

  constructor(public ingredientService:IngredientService){}

  ngOnInit(){
    this.ingredientService.getAllIngredients().subscribe({
      next:(data:Ingredient[])=> {
        data.forEach(element => {
          this.ingredients.push(element);
        });
        console.log(this.ingredients)
      }
    })
  }
}
