import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable, take, map } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardCookService implements CanActivate{

  constructor(private authService:AuthService,private router:Router) {

  }

  canActivate(router: ActivatedRouteSnapshot, state: RouterStateSnapshot):boolean|UrlTree|Observable<boolean |UrlTree>| Promise<boolean | UrlTree>{
    return this.authService.user.pipe(
      take(1),
      map((user) => {
        if(!user){
          return this.router.createUrlTree(['/login'])
        }
        if(user.roles[0] == "Cook"){
          return true;
        }
        else{
          return this.router.createUrlTree(['/recipes'])
        }
      })
    )
  }
}
