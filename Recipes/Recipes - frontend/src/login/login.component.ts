import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { LogInRequest } from 'src/models/LogInRequest.model';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  
  Username:string ="";
    Password:string = "";
    @Input() logInRequest: LogInRequest = new LogInRequest('', '');

    constructor(private authService:AuthService,public router:Router){}

    LogInSubmit(){

      var logInRequest = new LogInRequest(this.Username,this.Password);
      this.authService.login(logInRequest).subscribe({
      next: (data) => {
        console.log(data);
        this.router.navigateByUrl('/recipes');
      },
      error:() => {
        console.log("Invalid data entered.");
      }
    })
    }

    goToRegister(){
      this.router.navigateByUrl('/register');
    }

}
