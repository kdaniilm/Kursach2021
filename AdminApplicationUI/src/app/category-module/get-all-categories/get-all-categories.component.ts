import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CategoryModel } from 'src/app/models/categoryModel';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-get-all-categories',
  templateUrl: './get-all-categories.component.html',
  styleUrls: ['./get-all-categories.component.css']
})
export class GetAllCategoriesComponent implements OnInit {

  public categoryList!: Array<CategoryModel>;
  
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.GetCategories();
  }

  public GetCategories() {
    this.http.get<any>(environment.serverPath + "/apiProduct/getAllCategories").subscribe((res: any) => {
      this.categoryList = res;
    });
  }
}
