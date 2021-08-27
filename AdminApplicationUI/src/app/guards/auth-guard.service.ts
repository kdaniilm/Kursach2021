import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

  constructor(public router: Router) { }
  canActivate(): boolean{
    let token = sessionStorage.getItem('jwt');
    if (token != null) {
      return true;
    }
    else {
      this.router.navigate(['/login']);
      return false;
    }
    }
}
