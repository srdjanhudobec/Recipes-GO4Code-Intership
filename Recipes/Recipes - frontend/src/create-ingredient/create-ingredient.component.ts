import { Component, Input } from '@angular/core';
import { PostIngredient } from 'src/models/PostIngredient.model';
import { IngredientService } from 'src/services/ingredient.service';

@Component({
  selector: 'app-create-ingredient',
  templateUrl: './create-ingredient.component.html',
  styleUrls: ['./create-ingredient.component.css']
})
export class CreateIngredientComponent {
  name:string = "";
  measurementUnit: string = "";
  

  @Input() recipe: PostIngredient = new PostIngredient('','');

  constructor(private ingredientService:IngredientService){}
  
  createOnSubmit() {
    var ingredient = new PostIngredient(this.name,this.measurementUnit);

    this.ingredientService.createIngredient(ingredient).subscribe({
      next: (data) => {
        console.log(data);
      }
    })
  }
}
