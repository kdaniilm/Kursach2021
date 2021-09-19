import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainComponent } from './main/main.component';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { JwtInterceptorService } from './interceptors/jwt-interceptor.service';
import { LoginComponent } from './login/login.component';
import { GetAllProductsComponent } from './product-module/get-all-products/get-all-products.component';
import { AddProductComponent } from './product-module/add-product/add-product.component';
@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptorService, multi: true }
  ],
  bootstrap: [AppComponent],
  entryComponents: [
    GetAllProductsComponent, AddProductComponent, LoginComponent
  ]
})
export class AppModule { }
