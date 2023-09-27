import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { AuthService } from './auth.service';
import { Observable, take, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardAdminService implements CanActivate{

  constructor(private authService:AuthService,private router:Router) {

  }

  canActivate(router: ActivatedRouteSnapshot, state: RouterStateSnapshot):boolean|UrlTree|Observable<boolean |UrlTree>| Promise<boolean | UrlTree>{
    return this.authService.user.pipe(
      take(1),
      map((user) => {
        if(!user){
          return this.router.createUrlTree(['/login'])
        }
        if(user.roles[0] == "Admin"){
          return true;
        }
        else{
          return this.router.createUrlTree(['/recipes'])
        }
      })
    )
  }
}
