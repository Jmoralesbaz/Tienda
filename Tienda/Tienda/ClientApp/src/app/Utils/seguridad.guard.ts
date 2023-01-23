import { Injectable } from '@angular/core';
import { CanActivate, CanActivateChild, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../Modelos/user';
import { LoginService } from '../Services/login.service';

@Injectable({
  providedIn: 'root'
})
export class SeguridadGuard implements CanActivate, CanActivateChild {
  constructor(private auth: LoginService, private router: Router) {
  }
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

      // if (!this.auth.IsLogin()) {
      //   return this.router.navigate(['/acceso']).then(() => false);
      // }
      // return true;
      this.auth.IsLogin(this.GetUser()).subscribe((d:boolean)=>{
        return (d)?true:this.LoginRoute();
      },()=>{
        return this.LoginRoute();
      });
      return this.LoginRoute();
  }
  canActivateChild(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      // if (!this.auth.IsLogin()) {
      //   return this.router.navigate(['/acceso']).then(() => false);
      // }
      // return true;

      this.auth.IsLogin(this.GetUser()).subscribe((d:boolean)=>{
        return (d)?true:this.LoginRoute();
      },()=>{
        return this.LoginRoute();
      });
      return this.LoginRoute();
  }
  private LoginRoute(){
    return this.router.navigate(['/acceso']).then(() => false);
  }
  private GetUser():User{
    return {user:localStorage.getItem(environment.luser),pwd:localStorage.getItem(environment.lkey)};
  }
}
