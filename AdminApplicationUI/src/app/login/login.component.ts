import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { environment } from 'src/environments/environment';

import { LoginModel } from 'src/app/models/loginModel';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

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
        localStorage.setItem('jwt', token);
        this.router.navigate(['/main']);
      });
    }
  }
  ngOnInit(): void {
  }

}
