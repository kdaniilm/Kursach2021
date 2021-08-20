import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Route } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

  constructor(public router: Router) { }
  canActivate(): boolean{
    let token = sessionStorage.getItem('jwt');
    if (token != null) {
      this.router.navigate(['login']);
      return true;
    }
    else {
      return false;
    }
    }
}
