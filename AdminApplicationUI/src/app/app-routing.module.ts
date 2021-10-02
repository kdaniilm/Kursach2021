import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuardService } from './guards/auth-guard.service';
import { LoginComponent } from './login/login.component';
import { MainComponent } from './main/main.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'main', component: MainComponent, canActivate: [AuthGuardService] },
  { path: 'products', loadChildren: () => import('src/app/product-module/product-module.module').then(m => m.ProductModuleModule) },
  { path: 'categories', loadChildren: () => import("src/app/category-module/category-module.module").then(m => m.CategoryModuleModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
