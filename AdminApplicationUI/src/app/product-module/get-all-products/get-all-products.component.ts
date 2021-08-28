import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { ProductModel } from '../../models/productModel';

@Component({
  selector: 'app-get-all-products',
  templateUrl: './get-all-products.component.html',
  styleUrls: ['./get-all-products.component.css']
})
export class GetAllProductsComponent implements OnInit {

  constructor(private http: HttpClient) { }
  public productList!: Array<ProductModel>;
  ngOnInit(): void {
    this.getProducts();
  }

  public getProducts() {
    this.http.get<any>(environment.serverPath + "/apiProduct/getAllProducts").subscribe((res: any) => {
      this.productList = res;
    });
  }
}
