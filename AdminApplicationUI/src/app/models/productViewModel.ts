import { CharacteristicModel } from "./characteristicModel";
import { ProductModel } from "./productModel";

export class ProductViewModel {
    public productModel!: ProductModel;
    public charactristicModels!: Array<CharacteristicModel>;
    public productImages!: Array<File>;
}