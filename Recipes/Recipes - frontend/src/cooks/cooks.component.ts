import { Component } from '@angular/core';
import { Cook } from 'src/models/Cook.model';
import { BMandCooksService } from 'src/services/bmand-cooks.service';

@Component({
  selector: 'app-cooks',
  templateUrl: './cooks.component.html',
  styleUrls: ['./cooks.component.css']
})
export class CooksComponent {
  cooks: Cook [] = [];
  clicked:boolean = false;
  constructor(public bmandcooks:BMandCooksService){}

  getAllCooksOnSubmit(){
    this.clicked = true;
    this.bmandcooks.getAllRecipes().subscribe({
      next:(data:Cook[])=> {
        data.forEach(element => {
          this.cooks.push(element);
        });
        console.log(this.cooks);
      }
    })
  }
}
