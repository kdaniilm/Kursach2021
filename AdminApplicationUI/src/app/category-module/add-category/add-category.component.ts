import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnInit {
  constructor(private http: HttpClient) { }

  public categoryFormGroup = new FormGroup({
    categoryName: new FormControl('', Validators.required)
  });
  ngOnInit(): void {
  }

  public AddCategorySubmit(){
    let category = this.categoryFormGroup.value;
    this.http.post<any>(environment.serverPath + "/apiProduct/add-category", category).subscribe((res: any) => {
      alert("Category added");
    });
  }
}
