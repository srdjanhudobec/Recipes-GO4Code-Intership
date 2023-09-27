import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { IngredientService } from 'src/services/ingredient.service';

@Component({
  selector: 'app-delete-ingredient',
  templateUrl: './delete-ingredient.component.html',
  styleUrls: ['./delete-ingredient.component.css']
})
export class DeleteIngredientComponent {
  deleteName:string = "";

  constructor(private ingredientService:IngredientService,public router:Router){}

  deleteOnSubmit(){  
     this.ingredientService.deleteIngredient(this.deleteName).subscribe({
       next: (data) => {
         console.log(data);
       }
     })
     this.router.navigateByUrl("/ingredients");
  }
}
