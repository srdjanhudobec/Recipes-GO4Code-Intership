import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map, tap } from 'rxjs';
import { LogInRequest } from 'src/models/LogInRequest.model';
import { LogInResponse } from 'src/models/LogInResponse.model';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  rootUrl: string = 'http://localhost:5121/api/Auth/';
  user: BehaviorSubject<LogInResponse | null> = new BehaviorSubject<LogInResponse | null>(null);

  constructor(private http: HttpClient,public router:Router) { }

  login(logInRequest: LogInRequest) : Observable<LogInResponse> {

    var url = this.rootUrl + 'login';
    var body = logInRequest;

    return this.http.post<any>(url, body).pipe(
      map((response:LogInResponse) => {
        localStorage.setItem('loggedInUser', JSON.stringify(response));
        var user = new LogInResponse(response.token,response.expiration,response.roles);
        this.user.next(user);
        console.log(response);
        return response;
      })
    )
  }

  register_user(data: {username: string, email: string, password: string}) {
    let registerUrl = this.rootUrl + 'register-user';
    return this.http.post<any>(registerUrl, data);
  }

  register_cook(data: {username: string, email: string, password: string}) {
    let registerUrl = 'http://localhost:5121/api/User/register-cook';
    return this.http.post<any>(registerUrl, data);
  }

  loginAuto() {
    let user = localStorage.getItem('loggedInUser');
    if(user){
      let userJson = JSON.parse(user);//moze se raditi validacija dal je tipa User
      this.user.next(userJson);
    }
  }

  logOut(){
    localStorage.removeItem('loggedInUser');
    this.user.next(null);//da ocistimo i iz behavior subjecta
    // this.router.navigateByUrl('http://localhost:4200/login');
  }
}
