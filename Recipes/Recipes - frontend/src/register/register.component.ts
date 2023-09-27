import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Register } from 'src/models/Register.model';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  Username:string = "";
  Password:string = "";
  Email:string = "";
  @Input() register: Register = new Register('', '','');

  constructor(private authService:AuthService,public router: Router){}

  RegisterOnSubmit(){
    
    var registerRequest = new Register(this.Email,this.Username,this.Password);
    // if(this.rol == "Admin"){}
    this.authService.register_user(registerRequest).subscribe({
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

  ResetForm(){
    this.register
  }
}
