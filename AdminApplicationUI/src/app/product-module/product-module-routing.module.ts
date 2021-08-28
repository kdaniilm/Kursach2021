import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuardService } from 'src/app/guards/auth-guard.service';
import { AddProductComponent } from './add-product/add-product.component';
import { GetAllProductsComponent } from './get-all-products/get-all-products.component';

const routes: Routes = [
  { path: '', component: GetAllProductsComponent, canActivate: [AuthGuardService] },
  { path: 'add', component: AddProductComponent, canActivate: [AuthGuardService] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class ProductsRoutingModule { }
