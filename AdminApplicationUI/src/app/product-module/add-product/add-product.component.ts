import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { FormControl, FormGroup, Validators } from '@angular/forms';
import { environment } from '../../../environments/environment';
import { ProductViewModel } from 'src/app/models/productViewModel';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  public productModel = new ProductViewModel();

  public productFormGroup = new FormGroup({
    productName: new FormControl('', Validators.required),
    productPrice: new FormControl('', Validators.required)
  });

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
  }
  public addProductSubmit() {
    if (this.productFormGroup.valid) {
      this.productModel = this.productFormGroup.value;
      this.http.post<any>(environment.serverPath + "/apiProduct/addProduct", this.productModel).subscribe((res: any) => {
        alert("asd");
      });
    }
  }
}
