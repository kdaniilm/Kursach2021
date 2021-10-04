import { Injectable } from '@angular/core';
import { HttpHeaders, HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class JwtInterceptorService implements HttpInterceptor {

  constructor() { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    let token = sessionStorage.getItem('jwt');


    request = request.clone({ setHeaders: { Authorization: `Bearer ${token}` } });

    return next.handle(request);
  }
}
