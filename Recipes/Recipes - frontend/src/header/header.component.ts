import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  isAuthenticated: boolean = false;
  role: string = "";
  userSub: Subscription = new Subscription()

  constructor(private authService: AuthService,public router:Router) {}

  ngOnInit(): void {
    this.userSub = this.authService.user.subscribe({
      next: (data) => {
        this.isAuthenticated = data ? true : false;
        if(data?.roles[0] == "Admin"){
          this.role = "Admin"
        }
        else if(data?.roles[0] == "Cook"){
          this.role = "Cook";
        }
        else if(data?.roles[0] == "User"){
          this.role = "User";
        }
        
      }
    })
  }

  logout(){
    this.role = "";
    this.authService.logOut();
    this.router.navigateByUrl('/login');
  }

  goToLogIn(){
    this.router.navigateByUrl('/login');
  }

  goToRegister(){
    this.router.navigateByUrl('/register');
  }

  goToCreateRecipe(){
    this.router.navigateByUrl('/create-recipe');
  }

  goToDeleteRecipe(){
    this.router.navigateByUrl('/delete-recipe');
  }

  goToGetAllCooks(){
    this.router.navigateByUrl('/get-all-cooks');
  }

  goToRegisterCook(){
    this.router.navigateByUrl('/register-cook');
  }

  goToDeleteIngredient(){
    this.router.navigateByUrl('/delete-ingredient');
  }

  goToGetAllIngredients(){
    this.router.navigateByUrl('/ingredients')
  }

  goToCreateIngredient(){
    this.router.navigateByUrl('/create-ingredient')
  }
}
