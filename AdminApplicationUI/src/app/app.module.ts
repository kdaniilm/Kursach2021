import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainComponent } from './main/main.component';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AuthGuardService } from 'src/app/guards/auth-guard.service';
import { JwtInterceptorService } from './interceptors/jwt-interceptor.service';
import { RouterModule } from '@angular/router';
@NgModule({
  declarations: [
    AppComponent,
    MainComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule,
    RouterModule.forRoot([
      { path: 'main', component: MainComponent, canActivate: ['AuthGuardService'] }])
  ],
  providers: [AuthGuardService
    /*{ provide: HTTP_INTERCEPTORS, useClass: JwtInterceptorService, multi: true }*/
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
