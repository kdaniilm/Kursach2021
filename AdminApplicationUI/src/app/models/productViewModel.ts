import { CharacteristicModel } from "./characteristicModel";
import { ProductModel } from "./productModel";

export class ProductViewModel {
    public productModel!: ProductModel;
    public characteristicModel!: Array<CharacteristicModel>;
}