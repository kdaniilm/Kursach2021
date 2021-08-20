import { Component } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { environment } from 'src/environments/environment';

import { LoginModel } from './models/loginModel';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'AdminApplicationUI';
  public loginModel = new LoginModel();
  public loginFormGroup = new FormGroup({
    login: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required)
  });
  constructor(private http: HttpClient, private router: Router) {

  }
  public loginSubmit() {
    if (this.loginFormGroup.valid) {
      this.loginModel = this.loginFormGroup.value;

      this.http.post<any>(environment.serverPath + "/apiAuth/login", this.loginModel).subscribe((res: any) => {
        const token = (<any>res).token;
        sessionStorage.setItem('jwt', token);
        this.router.navigate(['/main']);
      });
    }
    else {
    }
  }
}
