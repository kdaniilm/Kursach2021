import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { FormControl, FormGroup, Validators } from '@angular/forms';
import { environment } from '../../../environments/environment';
import { ProductModel } from 'src/app/models/productModel';
import { CharacteristicModel } from 'src/app/models/characteristicModel';
import { ProductViewModel } from 'src/app/models/productViewModel';
import { ImageModel } from 'src/app/models/ImageModel';
import { CategoryModel } from 'src/app/models/categoryModel';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  public productModel = new ProductModel();
  public characteristicModels = Array<CharacteristicModel>();
  public productViewModel = new ProductViewModel();
  public productImages = Array<ImageModel>();
  public categoryModel = new CategoryModel();

  public categoryModels!: Array<CategoryModel>;

  public productFormGroup = new FormGroup({
    productName: new FormControl('', Validators.required),
    productPrice: new FormControl('', Validators.required),
    characteristicName: new FormControl(''),
    characteristicValue: new FormControl(''),
    category: new FormControl('', Validators.required)
  });

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.getCategories();
  }


  public getCategories(){
    this.http.get<any>(environment.serverPath + "/apiProduct/getAllCategories").subscribe((res: any) => {
      this.categoryModels = res;
    });
  }

  public addProductSubmit() {
    if (this.productFormGroup.valid) {

      this.productModel = this.productFormGroup.value;
      
      this.productViewModel.productModel = this.productModel;
      this.productViewModel.charactristicModels = this.characteristicModels;

      this.categoryModel.id = this.productFormGroup.value.category;

      this.productViewModel.categoryModel = this.categoryModel;

      this.http.post<any>(environment.serverPath + "/apiProduct/addProduct", this.productViewModel).subscribe((res: any) => {
        alert("Product added");
      });
    }
  }

  public addCharacteristic(){
    let characteristicNameFromForm = prompt('Insert characteristic name', 'New characteristic');
    let characteristicValueFromForm = prompt('Insert characteristic value', 'Default value');

    if(characteristicNameFromForm != null && characteristicValueFromForm != null){
      let characteristicModel = new CharacteristicModel();

      characteristicModel.characteristicName = characteristicNameFromForm;
      characteristicModel.characteristicValue = characteristicValueFromForm;

      this.characteristicModels.push(characteristicModel);
    }
  }
}
