import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ProductViewModel } from 'src/app/models/productViewModel';
import { environment } from '../../../environments/environment';
import { ProductModel } from '../../models/productModel';

@Component({
  selector: 'app-get-all-products',
  templateUrl: './get-all-products.component.html',
  styleUrls: ['./get-all-products.component.css']
})
export class GetAllProductsComponent implements OnInit {

  constructor(private http: HttpClient) { }
  public productList!: Array<ProductViewModel>;
  ngOnInit(): void {
    this.getProducts();
  }

  public getProducts() {
    this.http.get<any>(environment.serverPath + "/apiProduct/getAllProducts").subscribe((res: any) => {
      this.productList = res;
    });
  }

  public generateServerPath(serverPath: string){
    return `environment.serverPath/${serverPath}`;
  }
}
