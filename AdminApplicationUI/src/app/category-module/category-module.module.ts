import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddCategoryComponent } from './add-category/add-category.component';
import { CategoryRoutingModule } from './category-module-routing.module';
import { GetAllCategoriesComponent } from './get-all-categories/get-all-categories.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AddCategoryComponent,
    GetAllCategoriesComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CategoryRoutingModule
  ]
})
export class CategoryModuleModule { }
