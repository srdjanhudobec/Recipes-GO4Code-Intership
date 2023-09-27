import { Component, Input } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Register } from 'src/models/Register.model';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-register-cook',
  templateUrl: './register-cook.component.html',
  styleUrls: ['./register-cook.component.css']
})
export class RegisterCookComponent {
  username = new FormControl('', [Validators.required]);
  password = new FormControl('', [Validators.required]);

  // FirstName = new FormControl('', [Validators.required]);
  // LastName = new FormControl('', [Validators.required]);
  // Email = new FormControl('', [Validators.required]);
  // Roles = new FormControl('',[Validators.required]);
  getErrorMessage() {
    if (this.username.hasError('required')) {
      return 'You must enter value in username field.';
    }
    if(this.password.hasError('required')){
      return 'You must enter value in password field.'
    }
    return null;
  }
  hide = true;

  Username:string = "";
  Password:string = "";
  Email:string = "";
  @Input() register: Register = new Register('', '','');
  
  constructor(private authService:AuthService, public router:Router){}

  RegisterOnSubmit(){
    
    var registerRequest = new Register(this.Email,this.Username,this.Password);
    // if(this.rol == "Admin"){}
    this.authService.register_cook(registerRequest).subscribe({
    next: () => {
      // console.log(data);
      console.log("Uspesna registracija!");
      this.router.navigateByUrl('/login');
    },
    error:() => {
      console.log("Invalid data entered.");
    }
  })
  }
}
