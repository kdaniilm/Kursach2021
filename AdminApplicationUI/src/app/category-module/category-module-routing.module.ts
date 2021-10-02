import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuardService } from 'src/app/guards/auth-guard.service';
import { AddCategoryComponent } from './add-category/add-category.component';
import { GetAllCategoriesComponent } from './get-all-categories/get-all-categories.component';

const routes: Routes = [
  { path: '', component: GetAllCategoriesComponent, canActivate: [AuthGuardService] },
  { path: 'add', component: AddCategoryComponent, canActivate: [AuthGuardService] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class CategoryRoutingModule { }
