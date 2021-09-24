import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { FormControl, FormGroup, Validators } from '@angular/forms';
import { environment } from '../../../environments/environment';
import { ProductModel } from 'src/app/models/productModel';
import { CharacteristicModel } from 'src/app/models/characteristicModel';
import { ProductViewModel } from 'src/app/models/productViewModel';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  public productModel = new ProductModel();
  public characteristicModels = Array<CharacteristicModel>();
  public productViewModel = new ProductViewModel();

  public productImages = Array<File>();

  public productFormGroup = new FormGroup({
    productName: new FormControl('', Validators.required),
    productPrice: new FormControl('', Validators.required),
    characteristicName: new FormControl(''),
    characteristicValue: new FormControl('')
  });

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
  }

  chooseFile(files: FileList) {
    if (files.length === 0) {
      return;
    }
    for (let i = 0; i < files.length; i++) {
      this.productImages.push(files[i]);
    }
  }

  public addProductSubmit() {
    if (this.productFormGroup.valid) {
      this.productModel = this.productFormGroup.value;
      
      this.productViewModel.productModel = this.productModel;
      this.productViewModel.charactristicModels = this.characteristicModels;

      this.productViewModel.productImages = this.productImages;

      this.http.post<any>(environment.serverPath + "/apiProduct/addProduct", this.productViewModel).subscribe((res: any) => {
        alert("asd");
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
