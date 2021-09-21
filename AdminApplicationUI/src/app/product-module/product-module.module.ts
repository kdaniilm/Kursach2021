import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GetAllProductsComponent } from './get-all-products/get-all-products.component';
import { ProductsRoutingModule } from './product-module-routing.module';
import { AddProductComponent } from './add-product/add-product.component';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    GetAllProductsComponent,
    AddProductComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ProductsRoutingModule
  ]
})
export class ProductModuleModule { }
